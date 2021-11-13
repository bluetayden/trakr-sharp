using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trakr_sharp {
    public partial class MainForm : Form {
        #region Init
        private ProcMonitor _procMonitor;
        private UserSettings _userSettings;
        private KeyboardListener _keyListener = null;

        private readonly Keys _screenshotKey = Keys.F12;
        private FormWindowState _lastWindowState;
        private bool _forceClose = false;

        public MainForm() {
            InitializeComponent();

            // Database and UserSettings init
            Utils.Database.Init();
            Utils.SysCalls.InitUserSettings();

            // Proc monitor instance init
            _procMonitor = new ProcMonitor();
            _procMonitor.OnTrackedProcEvent += procMonitor_OnTrackedProcEvent;

            // Get current user settings
            _userSettings = Utils.SysCalls.ReadUserSettings();

            // Init screenshots folder and setup keyboard listener if needed
            Utils.SysCalls.InitScreenshots();
            handleKeyboardListenerSetup();

            // this.trackingList init
            this.trackingList.InitListView(Utils.Database.GetProcDataList(), this._procMonitor.GetRunningProcs());
            this.trackingList.RequestDBWrite += trackingList_OnRequestDBWrite;
            this.trackingList.OnItemSelected += trackingList_OnItemSelected;
            this.trackingList.RequestProcStop += trackingList_OnRequestProcStop;
            handleShowingUtilCols();

            // Update this.trackingSummary
            updateTrackingSummary();

            // Get current window state for use in this.listView resizing later
            this._lastWindowState = this.WindowState;

            // Print greeting to programConsole
            printToProgramConsole("Welcome to trakr");
            printToProgramConsole(_procMonitor.GetStartupString() + "\r\n");
        }
        #endregion

        #region PublicEventHandlers
        private void procMonitor_OnTrackedProcEvent(ProcMonitor sender, string msg) {
            this.BeginInvoke((MethodInvoker)(() => {
                Utils.SysCalls.Print(msg);
                printToProgramConsole(msg);

                // Update running colours of this.trackingList and this.trackingSummary
                this.trackingList.UpdateRunningStates(this._procMonitor.GetRunningProcs());
                // Update this.trackingSummary
                updateTrackingSummary();
            }));
        }

        private void trackingList_OnRequestDBWrite(Controls.TrackingList sender, Dictionary<string, long> procTimePairs) {
            Utils.Database.UpdateTotalTimes(procTimePairs);

            string msg = string.Format("Updated times for {0} database record(s)", procTimePairs.Count);
            this.BeginInvoke((MethodInvoker)(() => printToProgramConsole(msg)));
        }

        private void trackingList_OnItemSelected(Controls.TrackingList sender, int selectedCount) {
            if (selectedCount == 1) {
                this.deleteButton.Enabled = true;
                this.editButton.Enabled = true;
            }
            else if (selectedCount > 1) {
                this.deleteButton.Enabled = true;
                this.editButton.Enabled = false;
            }
            else {
                this.deleteButton.Enabled = false;
                this.editButton.Enabled = false;
            }
        }

        private void trackingList_OnRequestProcStop(Controls.TrackingList sender, List<string> procNames) {
            _procMonitor.ForceCountsToZero(procNames);
            this.trackingList.UpdateRunningStates(_procMonitor.GetRunningProcs());
        }

        private void addRecordsForm_OnDBUpdate(AddRecordsForm sender, string msg) {
            this.BeginInvoke((MethodInvoker)(() => {
                // Print msg that entries were added to db
                Utils.SysCalls.Print(msg);
                printToProgramConsole(msg);

                // Update _procMonitor
                _procMonitor.UpdateTrackingFields();
                // Update this.trackingList
                addUniqueTrackingListItems();
                // Update this.trackingSummary
                updateTrackingSummary();
            }));
        }

        private void addRecordsForm_FormClosed(object sender, FormClosedEventArgs e) {
            this.addButton.Enabled = true;
        }
        #endregion

        #region WindowEventHandlers
        // Called when the main form truly closes
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            // Unsubscribe from trackingList db requests
            this.trackingList.RequestDBWrite -= trackingList_OnRequestDBWrite;

            // Write information from all running procs in trackingList to db
            Dictionary<string, long> procTimePairs = this.trackingList.GetRunningProcTimePairs();
            Utils.Database.UpdateTotalTimes(procTimePairs);

            // Stop application completely
            Application.Exit();
        }

        // Called when the main form is closed (will either hide the form or close it depending on user preference)
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            // If user settings choose to minimize instead of close, and the close request didn't come from 'Quit trakr'
            if (_userSettings.OnClose == UserSettings.CloseBehaviour.Minimize && !_forceClose) {
                // Cancel close event
                e.Cancel = true;
                // Hide Main Form
                this.Hide();
            }
        }

        // Called when the form is finished resizing
        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            if (this.WindowState != FormWindowState.Minimized) {
                this.trackingList.ResizeColumnHeaders();
            }
        }

        // Called whenever form is resized, but only applied when form is maximized or unmaximized
        private void MainForm_Resize(object sender, EventArgs e) {
            if (this.WindowState != _lastWindowState && this.WindowState != FormWindowState.Minimized) {
                this.trackingList.ResizeColumnHeaders();
                _lastWindowState = this.WindowState;
            }
        }

        // Called when the trakr tray icon is clicked (the main form is shown again)
        private void sysTrayIcon_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                WindowState = FormWindowState.Normal;
                this.Show();
            }
        }

        // Called when the quit button on the tray icon tool strip is clicked
        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            // Set flag to force close in case MainForm is currently in normal state
            this._forceClose = true;
            this.Close();
        }

        // Called on any keypress
        private void _keyListener_KeyDown(Keys key) {
            if (key == _screenshotKey) {
                Utils.SysCalls.Print("Screenshot key pressed (F12)");

                string msg = Utils.SysCalls.TakeScreenshot();
                printToProgramConsole(msg);
            }
        }
        #endregion

        #region LocalEventHandlers
        private void addButton_Click(object sender, EventArgs e) {
            // Disable add button
            this.addButton.Enabled = false;

            // Create addRecordsForm
            AddRecordsForm addRecordsForm = new AddRecordsForm();
            // Subscribe to events
            addRecordsForm.OnDBUpdate += addRecordsForm_OnDBUpdate;
            addRecordsForm.FormClosed += addRecordsForm_FormClosed;
            // Execute form
            addRecordsForm.Show();
        }

        private void editButton_Click(object sender, EventArgs e) {
            string recordName = this.trackingList.GetSelectedItems()[0];
            EditRecordForm editRecordForm = new EditRecordForm(recordName);
            editRecordForm.ShowDialog();

            if (editRecordForm.DialogResult == DialogResult.Cancel) {
                ProcData newData = Utils.Database.GetProcData(recordName);
                this.trackingList.UpdateLVItem(newData);
                updateTrackingSummary();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            // Get selected items
            List<string> selectedItems = trackingList.GetSelectedItems();

            // Generate confirmation msg
            string confirmationMsg = "The following records will be deleted: \r\n\r\n\t" +
                                     string.Join("\r\n\t", selectedItems) +
                                     "\r\n\r\nThis process cannot be undone. Continue?\r\n";
            // User confirmation before deletion
            DialogResult userResp = MessageBox.Show(confirmationMsg, "Confirm record deletion",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (userResp == DialogResult.OK) {
                // Update db
                Utils.Database.DeleteProcs(selectedItems);

                // Update _procMonitor
                _procMonitor.UpdateTrackingFields();
                // Update this.trackingList
                deleteTrackingListItems();
                // Update this.trackingSummary
                updateTrackingSummary();

                // Print msg
                string msg = String.Format("Deleted {0} record(s) from database", selectedItems.Count);
                Utils.SysCalls.Print(msg);
                printToProgramConsole(msg);

                // Disable delete button
                this.deleteButton.Enabled = false;
            }
        }

        private void settingsButton_Click(object sender, EventArgs e) {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();

            // When settingsForm closed, update _userSettings
            if (settingsForm.DialogResult == DialogResult.Cancel) {
                _userSettings = Utils.SysCalls.ReadUserSettings();

                // Show util cols if setting enabled
                handleShowingUtilCols();

                // Disable/Enable screenshots if setting changed
                handleKeyboardListenerSetup();
            }
        }

        private void programConsole_Enter(object sender, EventArgs e) {
            this.trackingList.ClearSelections();
        }
        #endregion

        #region Methods
        // Prints msg with a timestamp to MainForm's programConsole
        private void printToProgramConsole(string msg) {
            // Clear console if getting close to character limit
            if (this.programConsole.Text.Length >= 32000) {
                this.programConsole.Text = "";
            }

            string currTime = Utils.Times.GetCurrTimeStamp();
            this.programConsole.AppendText(String.Format("[{0}] {1}\r\n", currTime, msg));
        }

        // Shows or hides the util cols of this.trackingList if user settings require it
        private void handleShowingUtilCols() {
            if (_userSettings.ShowUtilCols) {
                this.trackingList.ShowUtilCols();
            }
            else {
                this.trackingList.HideUtilCols();
            }
        }

        // Creates keyboard listener or disables it depending on user settings
        private void handleKeyboardListenerSetup() {
            // If screenshots enabled and _keyListener not assigned to an object yet
            if (_userSettings.EnableScreenshots && _keyListener == null) {
                _keyListener = new KeyboardListener();
                _keyListener.KeyDown += _keyListener_KeyDown;
            }
            // Otherwise if screenshots disabled and _keyListener not null
            else if (!_userSettings.EnableScreenshots && _keyListener != null) {
                _keyListener.KeyDown -= _keyListener_KeyDown;
                _keyListener.Dispose();
                _keyListener = null;
            }
        }

        // Updates the TrackedCount and RunningCount fields of this.trackingSummary (also updates the system tray icon text)
        private void updateTrackingSummary() {
            if (this.trackingSummary.ProcIcon != null) {
                this.trackingSummary.ProcIcon.Dispose();
            }

            string mostRecentProc = this.trackingList.GetShortestRunningProc();
            this.trackingSummary.ProcIcon = Utils.SysCalls.GetIconFromCache(mostRecentProc);
            this.trackingSummary.ProcName = mostRecentProc;
            this.trackingSummary.TrackedCount = _procMonitor.GetTrackedCount();
            this.trackingSummary.RunningCount = _procMonitor.GetRunningCount();
            this.trackingSummary.RerenderFields();

            updateSysTrayIconText();
        }

        private void updateSysTrayIconText() {
            string msg = string.Format("Tracking: {0}\r\nRunning: {1}\r\n\r\nRecent:\r\n{2}",
                this.trackingSummary.TrackedCount, this.trackingSummary.RunningCount, this.trackingSummary.ProcName);

            if (msg.Length > 64) {
                msg = msg.Substring(0, 63);
            }

            this.sysTrayIcon.Text = msg;
        }

        // Invokes an update of this.trackingList where only new db items are added
        private void addUniqueTrackingListItems() {
            this.trackingList.AddUniqueLVItems(Utils.Database.GetProcDataList());
            this.trackingList.UpdateRunningStates(this._procMonitor.GetRunningProcs());

            this.trackingList.ResizeColumnHeaders();
        }

        // Invokes an update of this.trackingList where selected items are deleted
        private void deleteTrackingListItems() {
            this.trackingList.DeleteSelectedLVItems();
            this.trackingList.UpdateRunningStates(this._procMonitor.GetRunningProcs());

            this.trackingList.ResizeColumnHeaders();
        }
        #endregion
    }
}
