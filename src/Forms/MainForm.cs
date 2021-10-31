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
        private DataTable _trackedProcs; // Contains db information of procs for listView display
        private List<string> _runningTrackedProcs; // List of running processes using program_name strings from db

        public MainForm() {
            InitializeComponent();

            Utils.Database.Init();

            updateProcFields();
            // Update this.trackingList UI
            this.trackingList.repopulateListView(_trackedProcs);
            this.trackingList.updateRunningColors(_runningTrackedProcs);

            printToProgramConsole("Welcome to trakr\r\n");
        }
        #endregion

        #region LocalEventHandlers
        private void addButton_Click(object sender, EventArgs e) {
            using (AddProgramsForm addProgramsForm = new AddProgramsForm()) {
                addProgramsForm.ShowDialog();
            }
        }

        // Runs whenever CheckRunningProcsTimer elapses
        private void CheckRunningProcsTimer_Tick(object sender, EventArgs e) {
            Utils.SysCalls.Print("Tick");

            // Only update _runningTrackedProcs
            this._runningTrackedProcs = Utils.SysCalls.GetRunningTrackedProcList(); // [Fix Memory Leak]
            this.trackingList.updateRunningColors(_runningTrackedProcs);
        }
        #endregion

        #region Methods
        // Updates both this._trackedProcs and this._runningTrackedProcs with current info
        private void updateProcFields() {
            this._trackedProcs = Utils.Database.GetDataTable();
            this._runningTrackedProcs = Utils.SysCalls.GetRunningTrackedProcList();
        }

        // Prints msg with a timestamp to MainForm's programConsole
        private void printToProgramConsole(string msg) {
            string currTime = DateTime.Now.ToString("h:mm:ss");
            this.programConsole.AppendText(String.Format("[{0}] {1}\r\n", currTime, msg));
        }
        #endregion
    }
}
