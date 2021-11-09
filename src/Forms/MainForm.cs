using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace trakr_sharp {
    public partial class MainForm : Form {
        #region Init
        private ProcMonitor _procMonitor;
        private FormWindowState _lastWindowState;

        public MainForm() {
            InitializeComponent();

            // Database init
            Utils.Database.Init();

            // Proc monitor instance init
            _procMonitor = new ProcMonitor();
            _procMonitor.OnTrackedProcEvent += procMonitor_OnTrackedProcEvent;

            // this.trackingList init
            this.trackingList.InitListView(Utils.Database.GetDataTable(), this._procMonitor.GetRunningProcs());
            this.trackingList.RequestDBWrite += trackingList_OnRequestDBWrite;

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
                this.trackingList.updateRunningStates(this._procMonitor.GetRunningProcs());
                // Update this.trackingSummary
                updateTrackingSummary();
            }));
        }

        private void trackingList_OnRequestDBWrite(Controls.TrackingList sender, Dictionary<string, long> procTimePairs) {
            Utils.Database.UpdateTotalTimes(procTimePairs);

            string msg = String.Format("Updated times for {0} database record(s)", procTimePairs.Count);
            this.BeginInvoke((MethodInvoker)(() => printToProgramConsole(msg)));
        }

        private void addProgramsForm_OnDBUpdate(AddProgramsForm sender, string msg) {
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
        #endregion

        #region LocalEventHandlers
        private void addButton_Click(object sender, EventArgs e) {
            AddProgramsForm addProgramsForm = new AddProgramsForm();
            addProgramsForm.Show();
            addProgramsForm.OnDBUpdate += addProgramsForm_OnDBUpdate;
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            List<string> selectedItems = trackingList.GetSelectedItems();

            if (selectedItems.Count > 0) {
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
            }
        }

        // Called before the form closes (saves any time information from this.trackingList to db)
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.trackingList.RequestDBWrite -= trackingList_OnRequestDBWrite;

            Dictionary<string, long> procTimePairs = this.trackingList.GetRunningProcTimePairs();
            Utils.Database.UpdateTotalTimes(procTimePairs);

            string msg = String.Format("Updated times for {0} database record(s)", procTimePairs.Count);
            this.BeginInvoke((MethodInvoker)(() => printToProgramConsole(msg)));
        }

        // Called when the form is finished resizing
        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            this.trackingList.ResizeColumnHeaders();
        }

        // Called whenever form is resized, but only applied when form is maximized or unmaximized
        private void MainForm_Resize(object sender, EventArgs e) {
            if (this.WindowState != _lastWindowState) {
                this.trackingList.ResizeColumnHeaders();
                _lastWindowState = this.WindowState;
            }
        }
        #endregion

        #region Methods
        // Prints msg with a timestamp to MainForm's programConsole
        private void printToProgramConsole(string msg) {
            string currTime = Utils.Times.GetCurrTimeStamp();
            this.programConsole.AppendText(String.Format("[{0}] {1}\r\n", currTime, msg));
        }

        // Updates the TrackedCount and RunningCount fields of this.trackingSummary
        private void updateTrackingSummary() {
            if (this.trackingSummary.ProcIcon != null) {
                this.trackingSummary.ProcIcon.Dispose();
            }
            this.trackingSummary.ProcIcon = Utils.SysCalls.GetProcImage(this.trackingList.GetShortestRunningProc());
            this.trackingSummary.TrackedCount = _procMonitor.GetTrackedCount();
            this.trackingSummary.RunningCount = _procMonitor.GetRunningCount();
            this.trackingSummary.RerenderFields();
        }

        // Invokes an update of this.trackingList where only new db items are added
        private void addUniqueTrackingListItems() {
            using (DataTable trackedTable = Utils.Database.GetDataTable()) {
                this.trackingList.AddUniqueListViewItems(trackedTable);
            }
            this.trackingList.updateRunningStates(this._procMonitor.GetRunningProcs());
        }

        // Invokes an update of this.trackingList where selected items are deleted
        private void deleteTrackingListItems() {
            this.trackingList.DeleteSelectedLVItems();
            this.trackingList.updateRunningStates(this._procMonitor.GetRunningProcs());
        }
        #endregion
    }
}
