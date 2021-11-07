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

            // Get current window state for use in this.listView resizing later
            this._lastWindowState = this.WindowState;

            // Print greeting to programConsole
            printToProgramConsole("Welcome to trakr");
            printToProgramConsole(_procMonitor.GetStartupString() + "\r\n");
        }
        #endregion

        #region PublicEventHandlers
        private void procMonitor_OnTrackedProcEvent(ProcMonitor sender, string msg) {
            Utils.SysCalls.Print(msg);
            this.BeginInvoke((MethodInvoker)(() => printToProgramConsole(msg)));

            // Only running colours need to be updated on this event
            this.BeginInvoke((MethodInvoker)(() => this.trackingList.updateRunningStates(this._procMonitor.GetRunningProcs())));
        }

        private void trackingList_OnRequestDBWrite(Controls.TrackingList sender, Dictionary<string, Int32> procTimePairs) {
            Utils.Database.UpdateRecordTimes(procTimePairs);

            string msg = String.Format("Updated times for {0} database record(s)", procTimePairs.Count);
            this.BeginInvoke((MethodInvoker)(() => printToProgramConsole(msg)));
        }

        private void addProgramsForm_OnDBUpdate(AddProgramsForm sender, string msg) {
            // Print msg that entries were added to db
            Utils.SysCalls.Print(msg);
            this.BeginInvoke((MethodInvoker)(() => printToProgramConsole(msg)));

            // Update _procMonitor
            _procMonitor.UpdateTrackingFields();

            // Update this.trackingList
            addUniqueTrackingListItemsInvoke();
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

                // Update this.trackingList
                deleteTrackingListItemsInvoke();

                // Update _procMonitor
                _procMonitor.UpdateTrackingFields();

                // Print msg
                string msg = String.Format("Deleted {0} record(s) from the database", selectedItems.Count);
                Utils.SysCalls.Print(msg);
                printToProgramConsole(msg);
            }
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
            string currTime = DateTime.Now.ToString("h:mm:ss");
            this.programConsole.AppendText(String.Format("[{0}] {1}\r\n", currTime, msg));
        }

        // Invokes an update of this.trackingList where only new db items are added
        private void addUniqueTrackingListItemsInvoke() {
            using (DataTable trackedTable = Utils.Database.GetDataTable()) {
                this.BeginInvoke((MethodInvoker)(() => this.trackingList.AddUniqueListViewItems(trackedTable)));
            }
            this.BeginInvoke((MethodInvoker)(() => this.trackingList.updateRunningStates(this._procMonitor.GetRunningProcs())));
        }

        // Invokes an update of this.trackingList where selected items are deleted
        private void deleteTrackingListItemsInvoke() {
            this.BeginInvoke((MethodInvoker)(() => this.trackingList.DeleteListViewItems()));
            this.BeginInvoke((MethodInvoker)(() => this.trackingList.updateRunningStates(this._procMonitor.GetRunningProcs())));
        }
        #endregion
    }
}
