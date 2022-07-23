using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrakrSharp {
    public partial class AddRecordsForm : Form {
        public delegate void OnDBUpdateDelegate(AddRecordsForm sender, string msg);
        public event OnDBUpdateDelegate OnDBUpdate;

        #region Init
        public AddRecordsForm() {
            InitializeComponent();

            // Initialise this.runningProcListBox
            this.runningProcList.SetProcs(Utils.SysCalls.GetRunningUntrackedProcNameList());
            // Repopulate both procListBoxes
            RepopulateProcListBoxes();
        }
        #endregion

        #region Public Event Handlers
        /// <summary>
        /// Called when this.searchBox raises a public "valid query" event
        /// </summary>
        private void searchBox_OnValidQuery(Controls.SearchBox sender, string query) {
            this.runningProcList.QueryItems(query);
        }

        /// <summary>
        /// Called whenever an item in runningProcListBox is checked
        /// </summary>
        private void runningProcList_OnItemCheck(Controls.ProcCheckedListBox sender, int changedIndex) {
            this.BeginInvoke((MethodInvoker)(() => HandleButtonEnabling()));
        }

        /// <summary>
        /// Called whenever an item in selectedProcListBox is checked
        /// </summary>
        private void selectedProcList_OnItemCheck(Controls.ProcCheckedListBox sender, int changedIndex) {
            this.BeginInvoke((MethodInvoker)(() => HandleButtonEnabling()));
        }
        #endregion

        #region Local Event Handlers
        private void AddRecordsForm_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (Control c in this.Controls) {
                c.Dispose();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e) {
            // Update _runningProcs and _selectedProcs
            UpdateProcListFieldsForAddition();
            // Repopulate the list boxes with their updated _procs fields
            RepopulateProcListBoxes();
            // Clear searchBox
            this.searchBox.clearQueryBox();
        }

        private void removeButton_Click(object sender, EventArgs e) {
            // Update _runningProcs and _selectedProcs
            UpdateProcListFieldsForRemoval();
            // Repopulate the list boxes with their updated _procs fields
            RepopulateProcListBoxes();
            // Clear searchBox
            this.searchBox.clearQueryBox();
        }

        /// <summary>
        /// Resets the contents of this.runningProcList and this.selectedProcList
        /// allows for this.runningProcList to contain an up to date list of running system procs
        /// </summary>
        private void refreshButton_Click(object sender, EventArgs e) {
            // Reset both proc lists
            this.runningProcList.ResetControl();
            this.selectedProcList.ResetControl();
            // Reinitialise this.runningProcListBox and repopulate both lists
            this.runningProcList.SetProcs(Utils.SysCalls.GetRunningUntrackedProcNameList());
            RepopulateProcListBoxes();
            // Clear searchBox
            this.searchBox.clearQueryBox();

            HandleButtonEnabling();
        }

        private void applyButton_Click(object sender, EventArgs e) {
            // Get dict of proc_name and proc_path and insert them into the db
            Dictionary<string, string> procPathPairs = Utils.SysCalls.GetProcPathPairs(this.selectedProcList.GetProcs());

            try {
                Utils.Database.InsertProcPathPairs(procPathPairs);
                Utils.SysCalls.CacheIconsToDisk(procPathPairs);

                // Raise public event that db was altered
                OnDBUpdate?.Invoke(this, "Added " + this.selectedProcList.GetProcs().Count + " record(s) to the database");

                // Show success message
                MessageBox.Show(this, "Added " + this.selectedProcList.GetProcs().Count + " " +
                    "record(s) to trakr", "Records successfully added",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Remove the items from _selectedProcs so they can't be accessed again
                this.selectedProcList.SetProcs(new List<string>());

                // Repopulate listboxes to reflect changes in _selectedProcs
                RepopulateProcListBoxes();
                // Enable/Disable buttons accordingly
                HandleButtonEnabling();
            }
            catch (Exception ex) {
                // Show error message
                MessageBox.Show(ex.ToString(), "Error adding records",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Reenable Apply button
                this.applyButton.Enabled = true;
            }
        }
        #endregion

        #region UI_Updates
        /// <summary>
        /// Updates _runningProcs and _selectedProcs for an addition action
        /// </summary>
        private void UpdateProcListFieldsForAddition() {
            // Update for selectedProcListBox._selectedProcs to contain runningProcListBox._selectedProcs
            this.selectedProcList.AddProcs(this.runningProcList.GetCheckedProcs());
            // Update _runningProcs to remove any of runningProcListBox's checked items 
            this.runningProcList.RemoveCheckedItemsFromProcs();

            Utils.SysCalls.Print("Updated proc list fields (addition)");
        }

        /// <summary>
        /// Updates _runningProcs and _selectedProcs for a removal action
        /// </summary>
        private void UpdateProcListFieldsForRemoval() {
            // Update for runningProcListBox._procs to contain selectedProcListBox._selectedProcs
            this.runningProcList.AddProcs(this.selectedProcList.GetCheckedProcs());
            // Update to remove any of selectedProcListBox's checked items
            this.selectedProcList.RemoveCheckedItemsFromProcs();

            Utils.SysCalls.Print("Updated proc list fields (removal)");
        }

        /// <summary>
        /// Repopulates this.runningProcList and this.selectedProcList with their _proc fields
        /// </summary>
        private void RepopulateProcListBoxes() {
            this.runningProcList.RepopulateListBox();
            this.selectedProcList.RepopulateListBox();

            HandleButtonEnabling();
        }

        /// <summary>
        /// Controls enabling/disabling of buttons depending on listBox selections/population
        /// </summary>
        private void HandleButtonEnabling() {
            this.addButton.Enabled = this.runningProcList.GetCheckedProcs().Count > 0;
            this.removeButton.Enabled = this.selectedProcList.GetCheckedProcs().Count > 0;
            this.applyButton.Enabled = this.selectedProcList.GetProcs().Count > 0;
        }
        #endregion
    }
}
