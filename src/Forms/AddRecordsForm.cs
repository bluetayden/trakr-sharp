﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trakr_sharp {
    public partial class AddRecordsForm : Form {
        #region Init
        public delegate void OnDBUpdateDelegate(AddRecordsForm sender, string msg); // Create delegator for public OnDBUPdate event
        public event OnDBUpdateDelegate OnDBUpdate; // Create instance of that event from delegator

        public AddRecordsForm() {
            InitializeComponent();

            // Initialise this.runningProcListBox
            this.runningProcList.setProcs(Utils.SysCalls.GetRunningUntrackedProcNameList());

            // Repopulate both procListBoxes
            repopulateProcListBoxes();
        }
        #endregion

        #region PublicEventHandlers
        // Called when this.searchBox raises a public valid query event
        private void searchBox_OnValidQuery(Controls.SearchBox sender, string query) {
            this.runningProcList.queryItems(query);
        }

        // Called whenever an item in runningProcListBox is checked
        private void runningProcList_OnItemCheck(Controls.ProcCheckedListBox sender, int changedIndex) {
            this.BeginInvoke((MethodInvoker)(() => handleButtonEnabling()));
        }

        // Called whenever an item in selectedProcListBox is checked
        private void selectedProcList_OnItemCheck(Controls.ProcCheckedListBox sender, int changedIndex) {
            this.BeginInvoke((MethodInvoker)(() => handleButtonEnabling()));
        }
        #endregion

        #region LocalEventHandlers
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
            updateProcListFieldsForAddition();
            // Repopulate the list boxes with their updated _procs fields
            repopulateProcListBoxes();

            // Clear searchBox
            this.searchBox.clearQueryBox();
        }

        private void removeButton_Click(object sender, EventArgs e) {
            // Update _runningProcs and _selectedProcs
            updateProcListFieldsForRemoval();
            // Repopulate the list boxes with their updated _procs fields
            repopulateProcListBoxes();

            // Clear searchBox
            this.searchBox.clearQueryBox();
        }

        // Resets the contents of this.runningProcList and this.selectedProcList
        // allows for this.runningProcList to contain an up to date list of running system procs
        private void refreshButton_Click(object sender, EventArgs e) {
            // Reset both proc lists
            this.runningProcList.resetControl();
            this.selectedProcList.resetControl();

            // Reinitialise this.runningProcListBox and repopulate both lists
            this.runningProcList.setProcs(Utils.SysCalls.GetRunningUntrackedProcNameList());
            repopulateProcListBoxes();

            // Clear searchBox
            this.searchBox.clearQueryBox();

            handleButtonEnabling();
        }

        private void applyButton_Click(object sender, EventArgs e) {
            // Get dict of proc_name and proc_path and insert them into the db
            Dictionary<string, string> procPathPairs = Utils.SysCalls.GetProcPathPairs(this.selectedProcList.getProcs());

            try {
                Utils.Database.InsertProcPathPairs(procPathPairs);
                Utils.SysCalls.CacheIconsToDisk(procPathPairs);

                // Raise public event that db was altered
                OnDBUpdate?.Invoke(this, "Added " + this.selectedProcList.getProcs().Count + " record(s) to the database");

                // Show success message
                MessageBox.Show(this, "Added " + this.selectedProcList.getProcs().Count + " " +
                    "record(s) to trakr", "Records successfully added",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Remove the items from _selectedProcs so they can't be accessed again
                this.selectedProcList.setProcs(new List<string>());

                // Repopulate listboxes to reflect changes in _selectedProcs
                repopulateProcListBoxes();
                // Enable/Disable buttons accordingly
                handleButtonEnabling();
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
        // Updates _runningProcs and _selectedProcs for an addition action
        private void updateProcListFieldsForAddition() {
            // Update for selectedProcListBox._selectedProcs to contain runningProcListBox._selectedProcs
            this.selectedProcList.addProcs(this.runningProcList.getCheckedProcs());
            // Update _runningProcs to remove any of runningProcListBox's checked items 
            this.runningProcList.removeCheckedItemsFromProcs();

            Utils.SysCalls.Print("Updated proc list fields (addition)");
        }

        // Updates _runningProcs and _selectedProcs for a removal action
        private void updateProcListFieldsForRemoval() {
            // Update for runningProcListBox._procs to contain selectedProcListBox._selectedProcs
            this.runningProcList.addProcs(this.selectedProcList.getCheckedProcs());
            // Update to remove any of selectedProcListBox's checked items
            this.selectedProcList.removeCheckedItemsFromProcs();

            Utils.SysCalls.Print("Updated proc list fields (removal)");
        }

        // Repopulates this.runningProcList and this.selectedProcList with their _proc fields
        private void repopulateProcListBoxes() {
            this.runningProcList.repopulateListBox();
            this.selectedProcList.repopulateListBox();

            handleButtonEnabling();
        }

        // Controls enabling/disabling of buttons depending on listBox selections/population
        private void handleButtonEnabling() {
            // Add button
            this.addButton.Enabled = this.runningProcList.getCheckedProcs().Count > 0;

            // Remove button
            this.removeButton.Enabled = this.selectedProcList.getCheckedProcs().Count > 0;

            // Apply button
            this.applyButton.Enabled = this.selectedProcList.getProcs().Count > 0;
        }
        #endregion
    }
}