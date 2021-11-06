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
            this.trackingList.resizeColumnHeaders();
            updateTrackingList();

            // Get current window state for use in this.listView resizing later
            this._lastWindowState = this.WindowState;

            // Print greeting to programConsole
            printToProgramConsole("Welcome to trakr");
            printToProgramConsole(_procMonitor.GetStartupString() + "\r\n");
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
                updateTrackingListInvoke();

                // Print msg
                string msg = String.Format("Deleted {0} entries from the database", selectedItems.Count);
                Utils.SysCalls.Print(msg);
                printToProgramConsole(msg);
            }
        }

        // Called when the form is finished resizing
        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            this.trackingList.resizeColumnHeaders();
        }

        // Called whenever form is resized, but only applied when form is maximized or unmaximized
        private void MainForm_Resize(object sender, EventArgs e) {
            if (this.WindowState != _lastWindowState) {
                this.trackingList.resizeColumnHeaders();
                _lastWindowState = this.WindowState;
            }
        }
        #endregion

        #region PublicEventHandlers
        private void procMonitor_OnTrackedProcEvent(ProcMonitor sender, string msg) {
            Utils.SysCalls.Print(msg);
            this.BeginInvoke((MethodInvoker)(() => printToProgramConsole(msg)));

            // Only running colours need to be updated on this event
            this.BeginInvoke((MethodInvoker)(() => this.trackingList.updateRunningColors(this._procMonitor.GetRunningProcs())));
        }

        private void addProgramsForm_OnDBUpdate(AddProgramsForm sender, string msg) {
            // Print msg that entries were added to db
            Utils.SysCalls.Print(msg);
            this.BeginInvoke((MethodInvoker)(() => printToProgramConsole(msg)));

            // Update _procMonitor
            _procMonitor.UpdateTrackingFields();

            // Update this.trackingList
            updateTrackingListInvoke();
        }
        #endregion

        #region Methods
        // Prints msg with a timestamp to MainForm's programConsole
        private void printToProgramConsole(string msg) {
            string currTime = DateTime.Now.ToString("h:mm:ss");
            this.programConsole.AppendText(String.Format("[{0}] {1}\r\n", currTime, msg));
        }


        // Update of this.trackingList (repopulation, updating running colours)
        private void updateTrackingList() {
            using (DataTable trackedTable = Utils.Database.GetDataTable()) {
                this.trackingList.repopulateListView(trackedTable);
            }
            this.trackingList.updateRunningColors(this._procMonitor.GetRunningProcs());
        }

        // Same as updateTrackingList but with cross thread call support
        private void updateTrackingListInvoke() {
            using (DataTable trackedTable = Utils.Database.GetDataTable()) {
                this.BeginInvoke((MethodInvoker)(() => this.trackingList.repopulateListView(trackedTable)));
            }
            this.BeginInvoke((MethodInvoker)(() => this.trackingList.updateRunningColors(this._procMonitor.GetRunningProcs())));
        }
        #endregion
    }
}
