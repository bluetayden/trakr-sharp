using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trakr_sharp.Controls {
    public partial class ProcCheckedListBox : UserControl {
        #region Init
        public delegate void OnItemCheckDelegate(ProcCheckedListBox sender, int changedIndex); // Create delegator for public ItemCheck event
        public event OnItemCheckDelegate OnItemCheck; // Create instance of that event from delegator
        private List<string> _procs = new List<string>();
        private List<string> _checkedProcs = new List<string>();

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

        // Add items to this._procs from a list
        public void AddProcs(List<string> extraProcs) {
            this._procs.AddRange(extraProcs.Cast<string>());
        }

        public List<string> GetCheckedProcs() {
            return this._checkedProcs;
        }

        public void RemoveCheckedItemsFromProcs() {
            // Update _procs to not contain any of this.checkedListBox's checked items 
            this._procs = this._procs.Where(proc => !this._checkedProcs.Contains(proc)).ToList();
            // Clear _checkedProcs
            this._checkedProcs.Clear();
        }
        #endregion

        #region PublicEventRaisers
        /// Raises a public event if an item in this.checkboxList is changed, checkedIndex is the index of the item that was affected 
        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e) {
            this.BeginInvoke((MethodInvoker)(() => this.UpdateCheckedProcs(e.Index)));
            OnItemCheck?.Invoke(this, e.Index);
        }
        #endregion

        #region Methods
        // Takes an optional list (i.e. when user querying) and uses it to populate this.checkedListBox
        // Otherwise populates using this._procs
        public void RepopulateListBox(IEnumerable<string> customList = default) {
            // Suppress listbox UI updates
            this.checkedListBox.BeginUpdate();

            // Clear all items
            this.checkedListBox.Items.Clear();

            // Add custom items to checkedListBox if given
            if (customList != default(IEnumerable<string>)) {
                this.checkedListBox.Items.AddRange(customList.ToArray<string>());
            }
            // Otherwise populate with this._procs
            else {
                this.checkedListBox.Items.AddRange(this._procs.ToArray<string>());
            }

            // Restore checked states of this.checkedListBox
            RestoreCheckStates();

            // Re-enable listbox UI Updates
            this.checkedListBox.EndUpdate();

            Utils.SysCalls.Print("Repopulated checkedListBox");
        }

        // Adds items to this.checkedListBox by using a provided item list and an optional query
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

        // Updates _checkedProcs using the state of the item at checkedListBox.Items[cIndex]
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

        // Used to update checked states of the this.checkboxList, typically when states are lost during search/repopulation
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
            // Re-enable listbox UI Updates
            this.checkedListBox.EndUpdate();

            Utils.SysCalls.Print("Restored checkedListBox checks");
        }

        // Resets the values of the control
        public void ResetControl() {
            this._procs = new List<string>();
            this._checkedProcs = new List<string>();

            this.checkedListBox.Items.Clear();
        }
        #endregion
    }
}
