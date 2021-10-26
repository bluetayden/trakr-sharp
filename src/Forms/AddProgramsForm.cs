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
        private List<string> _runningProcs = new List<string>();
        private List<string> _selectedProcs = new List<string>();

        // Constructor
        public AddProgramsForm() {
            InitializeComponent();

            // Get list of running systems procs
            this._runningProcs = Utils.SysCalls.getRunningProcList();
            // Store the list in runningProcListBox
            queryRunningProcListBox();
        }

        // Member functions
        private void cancelButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        // Called when this.searchBox raises a public valid query event
        private void searchBox_OnValidQuery(Controls.SearchBox sender, string query) {
            queryRunningProcListBox(query);
        }

        // Called when an item in runningProcListBox has been checked
        private void runningProcListBox_ItemCheck(object sender, ItemCheckEventArgs e) {
            this.BeginInvoke((MethodInvoker)(() => updateProcListFields()));
        }

        // Updates _runningProcs and _selectedProcs from runningProcListBox's checked items
        // and selectedProcListBox's unchecked items then populates the relevant list boxes
        private void updateProcListFields() {
            List<string> checkedItems = this.runningProcListBox.CheckedItems.Cast<string>().ToList();

            // Update _runningProcs to not contain any of runningProcList's checked items 
            this._runningProcs = this._runningProcs.Where(proc => !checkedItems.Contains(proc)).ToList();
            // Update _selectedProcs to contain the checked items
            this._selectedProcs.AddRange(checkedItems);

            // Repopulate procListBoxes
            populateProcListBoxes();
        }

        // Takes an optional procList and uses it to populate runningProcListBox
        // otherwise populates using this._runningProcs. Also populates selectedProcListBox.
        private void populateProcListBoxes(IEnumerable<string> procList = default) {
            this.runningProcListBox.Items.Clear();
            this.selectedProcListBox.Items.Clear();

            // runningProcListBox
            if (procList != default(IEnumerable<string>)) {
                this.runningProcListBox.Items.AddRange(procList.ToArray<string>());
            }
            else {
                this.runningProcListBox.Items.AddRange(this._runningProcs.ToArray<string>());
            }

            // selectedProcListBox
            this.selectedProcListBox.Items.AddRange(this._selectedProcs.ToArray<string>());
        }

        // Filters the current items in runningProcListBox using an optional query
        private void queryRunningProcListBox(string query = "") {
            // Clear runningProcListBox
            this.runningProcListBox.Items.Clear();

            // Add each proc in _runningProcs to runningProcListBox if contains query
            if (query != "") {
                IEnumerable<string> filteredProcs = this._runningProcs.Where(proc => proc.Contains(query));
                populateProcListBoxes(filteredProcs);
            }
            else {
                populateProcListBoxes();
            }
        }
    }
}
