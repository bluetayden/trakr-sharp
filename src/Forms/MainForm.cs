using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TrakrSharp {
    public partial class MainForm : Form {
        #region Init
        private ProcMonitor _procMonitor;
        private UserSettings _userSettings;
        private KeyboardListener _keyListener = null;

        private FormWindowState _lastWindowState;
        private bool _forceClose = false;
        private const Keys _screenshotKey = Keys.F12;
        private const int ConsoleTextLimit = 32000;

        public MainForm() {
            InitializeComponent();

            // Database and UserSettings init
            Utils.Database.Init();
            Utils.SysCalls.InitUserSettings();

            // Proc monitor init
            _procMonitor = new ProcMonitor();
            _procMonitor.OnTrackedProcEvent += procMonitor_OnTrackedProcEvent;

            // Get current user settings
            _userSettings = Utils.SysCalls.ReadUserSettings();

            // Init screenshots folder and setup keyboard listener if needed
            Utils.SysCalls.InitScreenshotRootDir();
            HandleKeyboardListenerSetup();

            // Init trackingList
            this.trackingList.InitListView(Utils.Database.GetProcDataList(), this._procMonitor.GetRunningProcs());
            this.trackingList.RequestDBWrite += trackingList_OnRequestDBWrite;
            this.trackingList.OnItemSelected += trackingList_OnItemSelected;
            this.trackingList.RequestProcStop += trackingList_OnRequestProcStop;
            HandleShowingUtilCols();

            // Initial trackingSummary update
            UpdateTrackingSummary();

            // Get current window state for use in this.listView resizing later
            this._lastWindowState = this.WindowState;

            // Print greeting to programConsole
            PrintToProgramConsole("Welcome to trakr");
            PrintToProgramConsole(_procMonitor.GetStartupString() + "\r\n");
        }
        #endregion

        #region Public Event Handlers
        private void procMonitor_OnTrackedProcEvent(ProcMonitor sender, string msg) {
            this.BeginInvoke((MethodInvoker)(() => {
                Utils.SysCalls.Print(msg);
                PrintToProgramConsole(msg);

                // Update running colours of this.trackingList and this.trackingSummary
                this.trackingList.UpdateRunningStates(this._procMonitor.GetRunningProcs());
                // Update this.trackingSummary
                UpdateTrackingSummary();
            }));
        }

        private void trackingList_OnRequestDBWrite(Controls.TrackingList sender, Dictionary<string, long> procTimePairs) {
            Utils.Database.UpdateTotalTimes(procTimePairs);

            string msg = string.Format("Updated times for {0} database record(s)", procTimePairs.Count);
            this.BeginInvoke((MethodInvoker)(() => PrintToProgramConsole(msg)));
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
                PrintToProgramConsole(msg);

                // Update _procMonitor
                _procMonitor.UpdateTrackingFields();
                // Update this.trackingList
                AddUniqueTrackingListItems();
                // Update this.trackingSummary
                UpdateTrackingSummary();
            }));
        }

        private void addRecordsForm_FormClosed(object sender, FormClosedEventArgs e) {
            this.addButton.Enabled = true;
        }
        #endregion

        #region Window Event Handlers
        /// <summary>
        /// Called when the MainForm truly closes
        /// </summary>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            // Unsubscribe from trackingList db requests
            this.trackingList.RequestDBWrite -= trackingList_OnRequestDBWrite;

            // Write information from all running procs in trackingList to db
            Dictionary<string, long> procTimePairs = this.trackingList.GetRunningProcTimePairs();
            Utils.Database.UpdateTotalTimes(procTimePairs);

            // Stop application completely
            Application.Exit();
        }

        /// <summary>
        /// Called when the MainForm is attempting to close (will either hide the form or lead to an actual close
        /// depending on user preference)
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            // If user settings choose to minimize instead of close, and the close request didn't come from 'Quit trakr'
            if (_userSettings.OnClose == UserSettings.CloseBehaviour.Minimize && !_forceClose) {
                // Cancel close event (prevent MainForm_FormClosed)
                e.Cancel = true;
                // Hide MainForm (it will still remain the system tray)
                this.Hide();
            }
        }

        /// <summary>
        /// Called when the form is finished resizing
        /// </summary>
        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            if (this.WindowState != FormWindowState.Minimized) {
                this.trackingList.ResizeColumnHeaders();
            }
        }

        /// <summary>
        /// Called whenever form is resized, but only applied when form is maximized or unmaximized
        /// </summary>
        private void MainForm_Resize(object sender, EventArgs e) {
            if (this.WindowState != _lastWindowState && this.WindowState != FormWindowState.Minimized) {
                this.trackingList.ResizeColumnHeaders();
                _lastWindowState = this.WindowState;
            }
        }

        /// <summary>
        /// Called when the trakr tray icon is clicked (the MainForm is shown again)
        /// </summary>
        private void sysTrayIcon_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                WindowState = FormWindowState.Normal;
                this.Show();
            }
        }

        /// <summary>
        /// Called on any keypress, takes a screenshot if the relevant key is used.
        /// </summary>
        private void _keyListener_KeyDown(Keys key) {
            if (key == _screenshotKey) {
                Utils.SysCalls.Print("Screenshot key pressed (F12)");
                string msg = Utils.SysCalls.TakeScreenshot();
                PrintToProgramConsole(msg);
            }
        }
        #endregion

        #region Menu Event Handlers
        private void fileAddMenuBarItem_Click(object sender, EventArgs e) {
            addButton.PerformClick();
        }

        private void fileSettingsMenuBarItem_Click(object sender, EventArgs e) {
            settingsButton.PerformClick();
        }

        private void fileExitMenuBarItem_Click(object sender, EventArgs e) {
            quitToolStripMenuItem.PerformClick();
        }

        private void helpReadmeMenuBarItem_Click(object sender, EventArgs e) {
            bool success = Utils.SysCalls.OpenReadme();

            // Show error message if failed to open README file
            if (!success) {
                MessageBox.Show("README.md is either in use or could not be found.", "Failed to open Readme",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void helpAboutMenuBarItem_Click(object sender, EventArgs e) {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Called when the quit button on the tray icon tool strip is clicked
        /// </summary>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            // Set flag to force close in case MainForm is currently in normal state
            this._forceClose = true;
            this.Close();
        }
        #endregion

        #region Local Event Handlers
        private void addButton_Click(object sender, EventArgs e) {
            // Disable add button
            this.addButton.Enabled = false;

            // Create addRecordsForm
            AddRecordsForm addRecordsForm = new AddRecordsForm();
            // Subscribe to events from addRecordsForm
            addRecordsForm.OnDBUpdate += addRecordsForm_OnDBUpdate;
            addRecordsForm.FormClosed += addRecordsForm_FormClosed;
            // Show addRecordsForm
            addRecordsForm.Show();
        }

        private void editButton_Click(object sender, EventArgs e) {
            string recordName = this.trackingList.GetSelectedItems()[0];
            EditRecordForm editRecordForm = new EditRecordForm(recordName);
            editRecordForm.ShowDialog();

            if (editRecordForm.DialogResult == DialogResult.Cancel) {
                ProcData newData = Utils.Database.GetProcData(recordName);
                this.trackingList.UpdateLVItem(newData);
                UpdateTrackingSummary();
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

                // UI Updates
                DeleteTrackingListItems();
                UpdateTrackingSummary();
                // Print msg
                string msg = String.Format("Deleted {0} record(s) from database", selectedItems.Count);
                Utils.SysCalls.Print(msg);
                PrintToProgramConsole(msg);

                // Disable delete button again
                this.deleteButton.Enabled = false;
            }
        }

        private void settingsButton_Click(object sender, EventArgs e) {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();

            // When settingsForm closed, update _userSettings with any changes
            if (settingsForm.DialogResult == DialogResult.Cancel) {
                _userSettings = Utils.SysCalls.ReadUserSettings();
                // Show util cols if setting enabled
                HandleShowingUtilCols();
                // Disable/Enable screenshots if setting changed
                HandleKeyboardListenerSetup();
            }
        }

        private void programConsole_Enter(object sender, EventArgs e) {
            this.trackingList.ClearSelections();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Prints a message with a timestamp to MainForm's programConsole
        /// </summary>
        private void PrintToProgramConsole(string msg) {
            // Clear console if getting close to character limit
            if (this.programConsole.Text.Length >= ConsoleTextLimit) {
                this.programConsole.Text = "";
            }

            string currTime = Utils.Times.GetCurrTimeStamp();
            this.programConsole.AppendText(String.Format("[{0}] {1}\r\n", currTime, msg));
        }

        /// <summary>
        /// Shows or hides the util cols of this.trackingList if user settings require it
        /// </summary>
        private void HandleShowingUtilCols() {
            if (_userSettings.ShowUtilCols) {
                this.trackingList.ShowUtilCols();
            }
            else {
                this.trackingList.HideUtilCols();
            }
        }

        /// <summary>
        /// Creates keyboard listener or disables it depending on user settings
        /// </summary>
        private void HandleKeyboardListenerSetup() {
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

        /// <summary>
        /// Updates the TrackedCount and RunningCount fields of this.trackingSummary (also updates the system tray icon text)
        /// </summary>
        private void UpdateTrackingSummary() {
            if (this.trackingSummary.ProcIcon != null) {
                this.trackingSummary.ProcIcon.Dispose();
            }

            string mostRecentProc = this.trackingList.GetShortestRunningProc();
            this.trackingSummary.ProcIcon = Utils.SysCalls.GetIconFromCache(mostRecentProc);
            this.trackingSummary.ProcName = mostRecentProc;
            this.trackingSummary.TrackedCount = _procMonitor.GetTrackedCount();
            this.trackingSummary.RunningCount = _procMonitor.GetRunningCount();
            this.trackingSummary.RefreshFields();

            UpdateSysTrayIconText();
        }

        private void UpdateSysTrayIconText() {
            string msg = string.Format("Tracking: {0}\r\nRunning: {1}\r\n\r\nRecent:\r\n{2}",
                this.trackingSummary.TrackedCount, this.trackingSummary.RunningCount, this.trackingSummary.ProcName);

            if (msg.Length > 64) {
                msg = msg.Substring(0, 63);
            }

            this.sysTrayIcon.Text = msg;
        }

        /// <summary>
        /// Invokes an update of this.trackingList where only new db items are added
        /// </summary>
        private void AddUniqueTrackingListItems() {
            this.trackingList.AddUniqueLVItems(Utils.Database.GetProcDataList());
            this.trackingList.UpdateRunningStates(this._procMonitor.GetRunningProcs());

            this.trackingList.ResizeColumnHeaders();
        }

        /// <summary>
        /// Invokes an update of this.trackingList where selected items are deleted
        /// </summary>
        private void DeleteTrackingListItems() {
            this.trackingList.DeleteSelectedLVItems();
            this.trackingList.UpdateRunningStates(this._procMonitor.GetRunningProcs());

            this.trackingList.ResizeColumnHeaders();
        }
        #endregion
    }
}
