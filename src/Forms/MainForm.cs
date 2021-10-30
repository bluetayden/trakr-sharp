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
        public MainForm() {
            InitializeComponent();

            Utils.Database.Init();
            this.trackingList.addTrackedProcs(Utils.Database.GetProcessNameList());

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
            // Update this.trackingList
            this.trackingList.addTrackedProcs(Utils.Database.GetProcessNameList());
            this.trackingList.updateRunningTrackedProcs(Utils.SysCalls.GetRunningProcList());
            this.trackingList.updateListBox();
        }
        #endregion

        #region Methods
        /// Prints msg with a timestamp to MainForm's programConsole
        private void printToProgramConsole(string msg) {
            string currTime = DateTime.Now.ToString("h:mm:ss");
            this.programConsole.AppendText(String.Format("[{0}] {1}\r\n", currTime, msg));
        }
        #endregion
    }
}
