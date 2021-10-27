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
        private List<string> _checkedRunningProcs = new List<string>();
        private List<string> _selectedProcs = new List<string>();
        private List<string> _checkedSelectedProcs = new List<string>();

        // Constructor
        public AddProgramsForm() {
            InitializeComponent();

            // Get list of running systems procs
            this._runningProcs = Utils.SysCalls.getRunningProcList();
            // Store the lists in runningProcListBox
            populateProcListBoxes();
        }

        // Member functions
        private void cancelButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        // Called when this.searchBox raises a public valid query event
        private void searchBox_OnValidQuery(Controls.SearchBox sender, string query) {
            queryRunningProcListBox(query);
        }

        private void addButton_Click(object sender, EventArgs e) {
            // Update _runningProcs and _selectedProcs
            updateProcListFieldsForAddition();
            // Repopulate the list boxes with the updated fields
            populateProcListBoxes();

            // Clear searchBox
            this.searchBox.clearQueryBox();
        }

        private void removeButton_Click(object sender, EventArgs e) {
            // Update _runningProcs and _selectedProcs
            updateProcListFieldsForRemoval();
            // Repopulate the list boxes with the updated fields
            populateProcListBoxes();

            // Clear searchBox
            this.searchBox.clearQueryBox();
        }

        // Called whenever an item in runningProcListBox is checked
        private void runningProcList_ItemCheck(object sender, ItemCheckEventArgs e) {
            this.BeginInvoke((MethodInvoker)(() => updateCheckedRunningProcs(e.Index)));
            this.BeginInvoke((MethodInvoker)(() => handleButtonEnabling()));
        }

        // Called whenever an item in selectedProcListBox is checked
        private void selectedProcList_ItemCheck(object sender, ItemCheckEventArgs e) {
            this.BeginInvoke((MethodInvoker)(() => updateCheckedSelectedProcs(e.Index)));
            this.BeginInvoke((MethodInvoker)(() => handleButtonEnabling()));
        }

        // Updates _checkedRunningProcs using the state of the item at runningProcListBox.Items[cIndex]
        private void updateCheckedRunningProcs(int cIndex) {
            // Get the item at cIndex
            string changedItem = this.runningProcListBox.Items[cIndex].ToString();

            // If item exists in _checkedRunningProcs already, remove it
            if (_checkedRunningProcs.Contains(changedItem)) {
                _checkedRunningProcs.Remove(changedItem);
            }
            // else add it
            else {
                _checkedRunningProcs.Add(changedItem);
            }

            Utils.SysCalls.Print("Updated _checkedRunningProcs " + this._checkedRunningProcs.Count);
        }

        // Updates _checkedSelectedProcs using the state of the item at runningProcListBox.Items[cIndex]
        private void updateCheckedSelectedProcs(int cIndex) {
            // Get the item at cIndex
            string changedItem = this.selectedProcListBox.Items[cIndex].ToString();

            // If item exists in _checkedRunningProcs already, remove it
            if (_checkedSelectedProcs.Contains(changedItem)) {
                _checkedSelectedProcs.Remove(changedItem);
            }
            // else add it
            else {
                _checkedSelectedProcs.Add(changedItem);
            }

            Utils.SysCalls.Print("Updated _checkedSelectedProcs " + this._checkedSelectedProcs.Count);
        }

        // Updates _runningProcs and _selectedProcs for an addition action
        private void updateProcListFieldsForAddition() {
            // Update _selectedProcs to contain runningProcList's checked items
            this._selectedProcs.AddRange(this._checkedRunningProcs);
            // Update _runningProcs to not contain any of runningProcList's checked items 
            this._runningProcs = this._runningProcs.Where(proc => !this._checkedRunningProcs.Contains(proc)).ToList();
            // Clear _checkedRunningProcs
            this._checkedRunningProcs.Clear();

            Utils.SysCalls.Print("Updated proc list fields (addition)");
        }

        // Updates _runningProcs and _selectedProcs for a removal action
        private void updateProcListFieldsForRemoval() {
            // Update _selectedProcs to remove any of selectedProcList's checked items
            this._selectedProcs.RemoveAll(proc => this.selectedProcListBox.CheckedItems.Cast<string>().ToList().Contains(proc));
            // Update _runningProcs to contain selectedProcList's checked items
            this._runningProcs.AddRange(this.selectedProcListBox.CheckedItems.Cast<string>().ToList());
            // Clear _checkedSelectedProcs
            this._checkedSelectedProcs.Clear();

            Utils.SysCalls.Print("Updated proc list fields (removal)");
        }

        // Takes an optional procList (i.e. when user querying) and uses it to populate runningProcListBox.
        // Otherwise populates using _runningProcs. Also populates selectedProcListBox with _selectedProcs.
        private void populateProcListBoxes(IEnumerable<string> procList = default) {
            // Suppress listbox UI updates
            this.runningProcListBox.BeginUpdate();
            this.selectedProcListBox.BeginUpdate();

            // Clear all items
            this.runningProcListBox.Items.Clear();
            this.selectedProcListBox.Items.Clear();

            // Add items to runningProcListBox
            if (procList != default(IEnumerable<string>)) {
                this.runningProcListBox.Items.AddRange(procList.ToArray<string>());
            }
            else {
                this.runningProcListBox.Items.AddRange(this._runningProcs.ToArray<string>());
            }

            // Add items to selectedProcListBox
            this.selectedProcListBox.Items.AddRange(this._selectedProcs.ToArray<string>());

            // Restore checked states of listBoxes
            restoreRunningProcListBoxChecks();
            restoreSelectedProcListBoxChecks();

            // Re-enable listbox UI Updates
            this.runningProcListBox.EndUpdate();
            this.selectedProcListBox.EndUpdate();

            // Set button enabled properties
            handleButtonEnabling();

            Utils.SysCalls.Print("Repopulated procListBoxes");
        }

        // Filters the current items in runningProcListBox using an optional query
        private void queryRunningProcListBox(string query = "") {
            // Clear runningProcListBox
            this.runningProcListBox.Items.Clear();

            // Add each proc in _runningProcs to runningProcListBox if contains query
            if (query != "") {
                IEnumerable<string> filteredProcs = this._runningProcs.Where(proc => proc.ToLower().Contains(query));
                populateProcListBoxes(filteredProcs);
            }
            else {
                populateProcListBoxes();
            }

            Utils.SysCalls.Print("Queried runningProcListBox");
        }

        // Restores checked states of the runningProcListBox that were lost during search/repopulation
        private void restoreRunningProcListBoxChecks() {
            // Suppress listbox UI updates
            this.runningProcListBox.BeginUpdate();

            // Temporarily disable ItemChecked event
            this.runningProcListBox.ItemCheck -= this.runningProcList_ItemCheck;

            // Restore checks based on _checkedRunningProcs
            for (int i = 0; i < this.runningProcListBox.Items.Count; i++) {
                foreach (string checkedItem in this._checkedRunningProcs) {
                    if (this.runningProcListBox.Items[i].ToString() == checkedItem) {
                        this.runningProcListBox.SetItemChecked(i, true);
                    }
                }
            }

            // Re-enable ItemChecked event
            this.runningProcListBox.ItemCheck += this.runningProcList_ItemCheck;
            // Re-enable listbox UI Updates
            this.runningProcListBox.EndUpdate();

            Utils.SysCalls.Print("Restored runningProcListBox checks");
        }

        // Restores checked states of the selectedProcListBox that were lost during search/repopulation
        private void restoreSelectedProcListBoxChecks() {
            // Suppress listbox UI updates
            this.selectedProcListBox.BeginUpdate();

            // Temporarily disable ItemChecked event
            this.selectedProcListBox.ItemCheck -= this.selectedProcList_ItemCheck;

            // Restore checks based on _selectedRunningProcs
            for (int i = 0; i < this.selectedProcListBox.Items.Count; i++) {
                foreach (string checkedItem in this._checkedSelectedProcs) {
                    if (this.selectedProcListBox.Items[i].ToString() == checkedItem) {
                        this.selectedProcListBox.SetItemChecked(i, true);
                    }
                }
            }

            // Re-enable ItemChecked event
            this.selectedProcListBox.ItemCheck += this.selectedProcList_ItemCheck;
            // Re-enable listbox UI Updates
            this.selectedProcListBox.EndUpdate();

            Utils.SysCalls.Print("Restored selectedProcListBox checks");
        }

        // Controls enabling/disabling of buttons depending on listBox selections/population
        private void handleButtonEnabling() {
            // Add button
            this.addButton.Enabled = this._checkedRunningProcs.Count > 0;

            // Remove button
            this.removeButton.Enabled = this._checkedSelectedProcs.Count > 0;

            // Apply button
            this.applyButton.Enabled = this.selectedProcListBox.Items.Count > 0;
        }
    }
}
