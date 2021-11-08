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
    public partial class TrackingList : UserControl {
        #region Definitions
        private const int Elapsed_Time_i = 2;
        private const int Total_Time_i = 4;
        private const int Process_Name_i = 6;
        private const int Is_Running_i = 7;
        private const int Start_Time_i = 8;
        #endregion

        #region Init
        // Create delegator for public RequestDBWrite event
        public delegate void RequestDBWriteDelegate(TrackingList sender, Dictionary<string, long> procTimePairs);
        // Create instance of that event from delegator
        public event RequestDBWriteDelegate RequestDBWrite;
        private long _lastTickTime;

        public TrackingList() {
            InitializeComponent();

            updateElapsedCol_Timer.Start();
            _lastTickTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public void InitListView(DataTable trackedTable, List<string> running) {
            InitListItems(trackedTable);
            updateRunningStates(running, false);
            ResizeColumnHeaders();

            // HideUtilCols();
        }
        #endregion

        #region LocalEventHandlers
        private void updateElapsedCol_Timer_Tick(object sender, EventArgs e) {
            updateElapsedCol_Timer.Stop();
            updateElapsedCol();
            updateElapsedCol_Timer.Start();
        }
        #endregion

        #region Utility
        // Returns list of selected values in the "Process_Name" column of this.listView
        public List<string> GetSelectedItems() {
            List<string> selectedProcNames = new List<string>();

            foreach (ListViewItem selectedItem in this.listView.SelectedItems) {
                selectedProcNames.Add(selectedItem.SubItems[Process_Name_i].Text);
            }

            return selectedProcNames;
        }

        // Resizes columns using fixed proportions
        public void ResizeColumnHeaders() {
            int width = this.listView.Width - 26;

            listView.Columns[0].Width = 24;
            listView.Columns[1].Width = (int)(width * 0.3);
            for (int i = 2; i < this.listView.Columns.Count; i++) {
                listView.Columns[i].Width = (int)(width * 0.175);
            }
        }

        // Hides the Process_Name, Is_Running and Start_Time cols
        private void HideUtilCols() {
            this.listView.Columns[Process_Name_i].Width = 0;
            this.listView.Columns[Is_Running_i].Width = 0;
            this.listView.Columns[Start_Time_i].Width = 0;
        }

        private bool LVContainsProcName(string proc_name) {
            foreach (ListViewItem lv_row in this.listView.Items) {
                if (lv_row.SubItems[Process_Name_i].Text == proc_name) {
                    return true;
                }
            }

            return false;
        }

        private bool RowMarkedRunning(ListViewItem lv_row) {
            // If the Is_Running value for the row is 1 return true, else false
            return (int)lv_row.SubItems[Is_Running_i].Tag == 1;
        }

        // Return the time since _lastTickTime and updates its value for future use
        private long CalcElapsedTime() {
            long currTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            long elapsedTime = currTime - _lastTickTime;

            _lastTickTime = DateTimeOffset.Now.ToUnixTimeSeconds();

            return elapsedTime;
        }

        private long CalcElapsedRowTime(ListViewItem lv_row) {
            return (Utils.Times.GetUTCNow() - (long)lv_row.SubItems[Start_Time_i].Tag);
        }
        #endregion

        #region Macro
        // Clears and updates this.listView using db values, used during initialisation only
        public void InitListItems(DataTable trackedTable) {
            this.listView.BeginUpdate();
            this.listView.Items.Clear();

            // Loop through each row in DataTable
            foreach (DataRow data_row in trackedTable.Rows) {
                AddListViewItem(data_row);
            }

            this.listView.EndUpdate();
        }

        // Adds new (unique) entries to this.listView from the db
        public void AddUniqueListViewItems(DataTable trackedTable) {
            this.listView.BeginUpdate();

            // Loop through each row in DataTable
            foreach (DataRow data_row in trackedTable.Rows) {
                if (!LVContainsProcName(data_row["Process_Name"].ToString())) {
                    AddListViewItem(data_row);
                }
            }

            this.listView.EndUpdate();
        }

        // Deletes selected items in this.listView
        public void DeleteSelectedLVItems() {
            List<string> for_deletion = GetSelectedItems();
            this.listView.BeginUpdate();

            foreach (string to_delete in for_deletion) {
                foreach (ListViewItem lv_row in this.listView.Items) {
                    if (lv_row.SubItems[Process_Name_i].Text == to_delete) {
                        this.listView.Items.Remove(lv_row);
                    }
                }
            }

            this.listView.EndUpdate();
        }

        // Updates the values in the Elapsed_Time col using the time between now and the last updateElapsedCol_Timer_Tick call
        private void updateElapsedCol() {
            long elapsedTime = CalcElapsedTime();

            this.listView.BeginUpdate();

            foreach (ListViewItem lv_row in this.listView.Items) {
                if (RowMarkedRunning(lv_row)) {
                    // Handle Elapsed_Time col
                    lv_row.SubItems[Elapsed_Time_i].Tag = (long)lv_row.SubItems[Elapsed_Time_i].Tag + elapsedTime;
                    lv_row.SubItems[Elapsed_Time_i].Text = Utils.Times.SecsToHMSString((long)lv_row.SubItems[Elapsed_Time_i].Tag);
                }
            }

            this.listView.EndUpdate();
        }
        #endregion

        #region Micro
        private void AddListViewItem(DataRow data_row) {
            // Create a new LVItem instance
            ListViewItem lv_row = new ListViewItem(data_row[0].ToString());

            // Add values from DataTable to each column in the LV item
            for (int data_col = 1; data_col < this.listView.Columns.Count; data_col++) {
                // Handle Elapsed_Time
                if (data_col == Elapsed_Time_i) {
                    lv_row.SubItems.Add("-");
                    lv_row.SubItems[data_col].Tag = (long)0;
                }
                // Handle Total_Time
                else if (data_col == Total_Time_i) {
                    lv_row.SubItems.Add(Utils.Times.SecsToHMSString(long.Parse(data_row[data_col].ToString())));
                    lv_row.SubItems[data_col].Tag = long.Parse(data_row[data_col].ToString());
                }
                // Handle Is_Running
                else if (data_col == Is_Running_i) {
                    lv_row.SubItems.Add("false");
                    lv_row.SubItems[data_col].Tag = 0;
                }
                // Handle Start_Time
                else if (data_col == Start_Time_i) {
                    lv_row.SubItems.Add("null");
                    lv_row.SubItems[data_col].Tag = -1;
                }
                else {
                    lv_row.SubItems.Add(data_row[data_col].ToString());
                }
            }

            // Add the item to this.listView
            listView.Items.Add(lv_row);
        }

        // Uses list of running procs (from ProcMonitor) to shade items in this.listView green
        public void updateRunningStates(List<string> running, bool raiseDBRequests = true) {
            Dictionary<string, long> procTimePairs = new Dictionary<string, long>();

            foreach (ListViewItem lv_row in this.listView.Items) {
                // If an item in running is present in this.listView
                if (running.Contains(lv_row.SubItems[Process_Name_i].Text)) {
                    // Set bg colour green
                    lv_row.BackColor = Color.PaleGreen;

                    // If the process wasn't marked as running in this.listView yet
                    if (!RowMarkedRunning(lv_row)) {
                        // Update Elapsed_Time text to 0
                        lv_row.SubItems[Elapsed_Time_i].Text = "0m";

                        // Set Is_Running to 1
                        lv_row.SubItems[Is_Running_i].Text = "true";
                        lv_row.SubItems[Is_Running_i].Tag = 1;

                        // Save Start_Time
                        lv_row.SubItems[Start_Time_i].Text = Utils.Times.GetUTCNow().ToString();
                        lv_row.SubItems[Start_Time_i].Tag = Utils.Times.GetUTCNow();
                    }
                }
                else {
                    // Set bg colour white
                    lv_row.BackColor = Color.White;

                    // If lv_row was marked Is_Running, add process name and elapsed time to procTimePairs
                    if (raiseDBRequests && RowMarkedRunning(lv_row)) {
                        long elapsedTime = CalcElapsedRowTime(lv_row);
                        procTimePairs.Add(lv_row.SubItems[Process_Name_i].Text, elapsedTime);

                        // Update Total_Time to contain time the proc was running till now
                        lv_row.SubItems[Total_Time_i].Tag = (long)lv_row.SubItems[Total_Time_i].Tag + elapsedTime;
                        lv_row.SubItems[Total_Time_i].Text = Utils.Times.SecsToHMSString((long)lv_row.SubItems[Total_Time_i].Tag);
                    }

                    // Reset Elapsed_Time to default value
                    lv_row.SubItems[Elapsed_Time_i].Text = "-";
                    lv_row.SubItems[Elapsed_Time_i].Tag = (long)0;
                    // Reset Start_Time to default value
                    lv_row.SubItems[Start_Time_i].Text = "null";
                    lv_row.SubItems[Start_Time_i].Tag = -1;
                    // Reset Is_Running to default value
                    lv_row.SubItems[Is_Running_i].Tag = 0;
                    lv_row.SubItems[Is_Running_i].Text = "false";
                }
            }

            // If any procs were running and changed to closed, procTimePairs contains elapsed times
            // Make request for these times to be written to db
            if (procTimePairs.Count > 0) {
                RequestDBWrite?.Invoke(this, procTimePairs);
            }
        }
        #endregion
    }
}
