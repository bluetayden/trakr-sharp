using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace trakr_sharp.Controls {
    public partial class ProcCheckedListBox : UserControl {
        public delegate void OnItemCheckDelegate(ProcCheckedListBox sender, int changedIndex);
        public event OnItemCheckDelegate OnItemCheck;
        private List<string> _procs = new List<string>();
        private List<string> _checkedProcs = new List<string>();

        #region Init
        public ProcCheckedListBox() {
            InitializeComponent();
        }
        #endregion

        #region Get/Set
        public void SetProcs(List<string> procs) {
            this._procs = procs;
        }

        public List<string> GetProcs() {
            return this._procs;
        }

        /// <summary>
        /// Adds items from "extra_procs" to this._procs
        /// </summary>
        public void AddProcs(List<string> extraProcs) {
            this._procs.AddRange(extraProcs.Cast<string>());
        }

        /// <summary>
        /// Returns a list of processes that have been ticked/checked by the user
        /// </summary>
        /// <returns></returns>
        public List<string> GetCheckedProcs() {
            return this._checkedProcs;
        }

        /// <summary>
        /// Removes the items that were checked by the user both internally and from this.checkedListBox
        /// </summary>
        public void RemoveCheckedItemsFromProcs() {
            // Update _procs to not contain any of this.checkedListBox's checked items 
            this._procs = this._procs.Where(proc => !this._checkedProcs.Contains(proc)).ToList();
            this._checkedProcs.Clear();
        }
        #endregion

        #region Public Event Raisers
        /// <summary>
        /// Fires if an item in this.checkboxList is changed, e.Index/checkedIndex is the position of the affected item
        /// </summary>
        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e) {
            this.BeginInvoke((MethodInvoker)(() => this.UpdateCheckedProcs(e.Index)));
            OnItemCheck?.Invoke(this, e.Index);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Takes an optional list (i.e. when user is querying with a search box) and uses it to populate this.checkedListBox.
        /// Otherwise populates using this._procs.
        /// </summary>
        public void RepopulateListBox(IEnumerable<string> customList = default) {
            this.checkedListBox.BeginUpdate();

            // Clear all items
            this.checkedListBox.Items.Clear();
            // Add custom items to checkedListBox if provided
            if (customList != default(IEnumerable<string>)) {
                this.checkedListBox.Items.AddRange(customList.ToArray<string>());
            }
            // Otherwise populate with this._procs
            else {
                this.checkedListBox.Items.AddRange(this._procs.ToArray<string>());
            }

            // Restore items that were checked before this update
            RestoreCheckStates();

            this.checkedListBox.EndUpdate();
            Utils.SysCalls.Print("Repopulated checkedListBox");
        }

        /// <summary>
        /// Adds items to this.checkedListBox by using a provided item list and an optional query
        /// </summary>
        public void QueryItems(string query = "") {
            // Clear checkedListBox
            this.checkedListBox.Items.Clear();

            // Add each proc in _runningProcs to checkedListBox if contains query
            if (!string.IsNullOrWhiteSpace(query)) {
                IEnumerable<string> filteredProcs = this._procs.Where(proc => proc.ToLower().Contains(query));
                this.RepopulateListBox(filteredProcs);
            }
            else {
                this.RepopulateListBox();
            }

            Utils.SysCalls.Print("Queried checkedListBox");
        }

        /// <summary>
        /// Updates _checkedProcs using the state of the item at checkedListBox.Items[cIndex]
        /// </summary>
        public void UpdateCheckedProcs(int cIndex) {
            // Get the item at cIndex
            string changedItem = this.checkedListBox.Items[cIndex].ToString();

            // If item exists in _checkedRunningProcs already, remove it
            if (_checkedProcs.Contains(changedItem)) {
                _checkedProcs.Remove(changedItem);
            }
            // else add it
            else {
                _checkedProcs.Add(changedItem);
            }

            Utils.SysCalls.Print("Updated _checkedRunningProcs " + this._checkedProcs.Count);
        }

        /// <summary>
        /// Used to update checked states of the this.checkboxList, typically when states are lost during search/repopulation
        /// </summary>
        private void RestoreCheckStates() {
            // Suppress listbox UI updates
            this.checkedListBox.BeginUpdate();

            // Temporarily disable ItemChecked event
            this.checkedListBox.ItemCheck -= this.checkedListBox_ItemCheck;

            // Restore checks based on checkedItems list
            for (int i = 0; i < this.checkedListBox.Items.Count; i++) {
                foreach (string checkedItem in this._checkedProcs) {
                    if (this.checkedListBox.Items[i].ToString() == checkedItem) {
                        this.checkedListBox.SetItemChecked(i, true);
                    }
                }
            }

            // Re-enable ItemChecked event
            this.checkedListBox.ItemCheck += this.checkedListBox_ItemCheck;

            this.checkedListBox.EndUpdate();
            Utils.SysCalls.Print("Restored checkedListBox checks");
        }

        // Resets the values of the control
        public void ResetControl() {
            this._procs = new List<string>();
            this._checkedProcs = new List<string>();
            this.checkedListBox.Items.Clear(); // affects UI
        }
        #endregion
    }
}
