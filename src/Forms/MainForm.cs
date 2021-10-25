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
        public MainForm() {
            InitializeComponent();
            printToProgramConsole("Welcome to trakr\r\n");
        }

        /// <summary>
        /// Prints msg with a timestamp to MainForm's programConsole
        /// </summary>
        private void printToProgramConsole(string msg) {
            string currTime = DateTime.Now.ToString("h:mm:ss");
            this.programConsole.AppendText(String.Format("[{0}] {1}\r\n", currTime, msg));
        }

        /// <summary>
        /// Launch addProgramsForm when addButton clicked
        /// </summary>
        private void addButton_Click(object sender, EventArgs e) {
            using (AddProgramsForm addProgramsForm = new AddProgramsForm()) {
                addProgramsForm.ShowDialog();
            }
        }
    }
}
