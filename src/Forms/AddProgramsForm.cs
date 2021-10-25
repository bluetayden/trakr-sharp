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
    public partial class AddProgramsForm : Form {
        // Fields
        private IEnumerable<string> _runningProcs;

        // Constructor
        public AddProgramsForm() {
            InitializeComponent();

            // Get list of running systems procs
            this._runningProcs = Utils.SysCalls.getRunningProcList();
            // Store the list in runningProcListBox
            populateRunningProcListBox();
        }

        // Member functions
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

        private void searchBox_OnValidQuery(Controls.SearchBox sender, string query) {
            populateRunningProcListBox(query);
        }

        private void populateRunningProcListBox(string query = "") {
            // Clear runningProcListBox
            this.runningProcListBox.Items.Clear();

            // Add each proc in _runningProcs to runningProcListBox if contains query
            if (query != "") {
                IEnumerable<string> filteredProcs = this._runningProcs.Where(proc => proc.Contains(query));
                this.runningProcListBox.Items.AddRange(filteredProcs.ToArray<string>());
            }
            else {
                this.runningProcListBox.Items.AddRange(_runningProcs.ToArray<string>());
            }
        }
    }
}
