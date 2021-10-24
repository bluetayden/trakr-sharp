using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trakr_sharp.Forms {
    public partial class AddProgramsForm : Form {
        public AddProgramsForm() {
            InitializeComponent();

            // Get list of running procs and store in runningProcListBox
            IEnumerable<string> runningProcs = Utils.SysCalls.getRunningProcList();
            foreach (string proc in runningProcs) {
                this.runningProcListBox.Items.Add(proc);
            }

            // Prevent searchbox placeholder text from being highlighted on form start
            this.searchBox.SelectionStart = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void addButton_Click(object sender, EventArgs e) {
            // Loop through all checked items in runningProcListBox
            for (int i = 0; i < this.runningProcListBox.Items.Count; i++) {
                // If currItem is checked
                if (this.runningProcListBox.GetItemChecked(i)) {
                    object currItem = runningProcListBox.Items[i];

                    // Add it to selectedProcListBox and remove from runningProcListBox
                    selectedProcListBox.Items.Add(currItem);
                    runningProcListBox.Items.Remove(currItem);
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e) {
            // Loop through all checked items in selectedProcListBox
            for (int i = 0; i < this.selectedProcListBox.Items.Count; i++) {
                // If currItem is checked
                if (this.selectedProcListBox.GetItemChecked(i)) {
                    object currItem = selectedProcListBox.Items[i];

                    // Add it to runningProcListBox and remove from selectedProcListBox
                    runningProcListBox.Items.Add(currItem);
                    selectedProcListBox.Items.Remove(currItem);
                }
            }
        }
    }
}
