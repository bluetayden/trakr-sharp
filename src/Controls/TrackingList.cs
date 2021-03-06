using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace TrakrSharp.Controls {
    public partial class TrackingList : UserControl {
        #region Constants
        private const int Program_Name_i = 1;
        private const int Elapsed_Time_i = 2;
        private const int Date_Opened_i = 3;
        private const int Total_Time_i = 4;
        private const int Date_Added_i = 5;
        private const int Process_Name_i = 6;
        private const int Process_Path_i = 7;
        private const int Is_Running_i = 8;
        private const int Start_Time_i = 9;

        private const int IconColWidth = 28;
        private const int OneMin = 60;
        #endregion

        #region Public Event Raisers
        public delegate void RequestDBWriteDelegate(TrackingList sender, Dictionary<string, long> procTimePairs);
        public event RequestDBWriteDelegate RequestDBWrite;
        public delegate void OnItemSelectedDelegate(TrackingList sender, int selectedCount);
        public event OnItemSelectedDelegate OnItemSelected;
        public delegate void RequestProcStopDelegate(TrackingList sender, List<string> procNames);
        public event RequestProcStopDelegate RequestProcStop;
        #endregion

        #region Init
        private ListViewColumnSorter _lvColumnSorter;
        private int _numImages = 0; // tracks number of icons in this.listView.smallImageList

        public TrackingList() {
            InitializeComponent();

            this.listView.DoubleBuffering(true);
            updateElapsedCol_Timer.Start();
        }

        public void InitListView(List<ProcData> procDataList, List<string> running) {
            // Add all items from db to this.listView and update running states
            InitListItems(procDataList);
            UpdateRunningStates(running, false);
            // Assign a LVColumnSorter to this.listView for column sorting when needed
            _lvColumnSorter = new ListViewColumnSorter();
            this.listView.ListViewItemSorter = _lvColumnSorter;
            // Fit column headers to current window size
            ResizeColumnHeaders();
        }
        #endregion

        #region Local Event Handlers
        /// <summary>
        /// Rerenders the values in the elapsed column every tick of the internal timer
        /// </summary>
        private void updateElapsedCol_Timer_Tick(object sender, EventArgs e) {
            updateElapsedCol_Timer.Stop();
            UpdateElapsedCol();
            updateElapsedCol_Timer.Start();
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            OnItemSelected?.Invoke(this, this.GetSelectedItems().Count);
        }

        /// <summary>
        /// Opens the right-click context menu when an item in this.listView is right clicked
        /// </summary>
        private void listView_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var focusedItem = this.listView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location)) {
                    lvRowContextMenu.Show(Cursor.Position);
                }
            }
        }

        /// <summary>
        /// Called whenever a column in this.listView is clicked. Sorts items depending on column content.
        /// </summary>
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e) {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvColumnSorter.SortColumn) {
                // Reverse the current sort direction for this column.
                if (_lvColumnSorter.Order == SortOrder.Ascending) {
                    _lvColumnSorter.Order = SortOrder.Descending;
                }
                else {
                    _lvColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else {
                // Set the column number that is to be sorted; default to ascending.
                _lvColumnSorter.SortColumn = e.Column;
                _lvColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView.Sort();
        }

        // Raises public event requesting procMonitor to mark the selected procs that are marked running, as closed
        private void stopLoggingToolStripMenuItem_Click(object sender, EventArgs e) {
            List<string> runningProcNames = new List<string>();

            foreach (ListViewItem lv_row in this.listView.Items) {
                if (RowIsMarkedRunning(lv_row) && this.listView.SelectedItems.Contains(lv_row)) {
                    runningProcNames.Add(lv_row.SubItems[Process_Name_i].Text);
                }
            }
            RequestProcStop?.Invoke(this, runningProcNames);
        }
        #endregion

        #region Util
        /// <summary>
        /// Returns a list of selected values in the "Process_Name" column of this.listView
        /// </summary>
        public List<string> GetSelectedItems() {
            List<string> selectedProcNames = new List<string>();
            foreach (ListViewItem selectedItem in this.listView.SelectedItems) {
                selectedProcNames.Add(selectedItem.SubItems[Process_Name_i].Text);
            }
            return selectedProcNames;
        }

        // A Dict containing proc names and the amount of time the proc has been open
        public Dictionary<string, long> GetRunningProcTimePairs() {
            Dictionary<string, long> procTimePairs = new Dictionary<string, long>();

            foreach (ListViewItem lv_row in this.listView.Items) {
                if (RowIsMarkedRunning(lv_row)) {
                    long elapsedTime = CalcElapsedRowTime(lv_row);
                    procTimePairs.Add(lv_row.SubItems[Process_Name_i].Text, elapsedTime);
                }
            }

            return procTimePairs;
        }

        // Gets the name of the process that has been running for the shortest amount of time
        // If no procs are in the list returns "NO_PROC"
        public string GetShortestRunningProc() {
            try {
                string name = "NO_PROC";
                long shortest_time = 0;

                foreach (ListViewItem lv_row in this.listView.Items) {
                    if (RowIsMarkedRunning(lv_row)) {
                        shortest_time = (long)lv_row.SubItems[Start_Time_i].Tag;
                    }
                }

                foreach (ListViewItem lv_row in this.listView.Items) {
                    if (RowIsMarkedRunning(lv_row)) {
                        long row_time = CalcElapsedRowTime(lv_row);

                        if (row_time < shortest_time) {
                            shortest_time = row_time;
                            name = lv_row.SubItems[Process_Name_i].Text;
                        }
                    }
                }

                return name;
            }
            catch (ArgumentOutOfRangeException) {
                return "NO_PROC";
            }
        }

        /// <summary>
        /// Resizes columns using fixed proportions (based on current window size)
        /// </summary>
        public void ResizeColumnHeaders() {
            int endMargin = this.listView.Items.Count > 9 ? 20 : 3;
            int width = this.listView.Width - (IconColWidth + endMargin);

            listView.Columns[0].Width = IconColWidth;
            listView.Columns[1].Width = (int)(width * 0.3);
            // -4 to avoid scaling utility cols
            for (int i = 2; i < this.listView.Columns.Count - 4; i++) {
                listView.Columns[i].Width = (int)(width * 0.175);
            }
        }

        /// <summary>
        /// Hides the Process_Name, Is_Running and Start_Time cols
        /// </summary>
        public void HideUtilCols() {
            this.listView.Columns[Process_Name_i].Width = 0;
            this.listView.Columns[Process_Path_i].Width = 0;
            this.listView.Columns[Is_Running_i].Width = 0;
            this.listView.Columns[Start_Time_i].Width = 0;
        }

        /// <summary>
        /// Shows the Process_Name, Is_Running and Start_Time cols
        /// </summary>
        public void ShowUtilCols() {
            this.listView.Columns[Process_Name_i].Width = -2;
            this.listView.Columns[Process_Path_i].Width = -2;
            this.listView.Columns[Is_Running_i].Width = -2;
            this.listView.Columns[Start_Time_i].Width = -2;
        }

        private bool LVContainsProcName(string proc_name) {
            foreach (ListViewItem lv_row in this.listView.Items) {
                if (lv_row.SubItems[Process_Name_i].Text == proc_name) {
                    return true;
                }
            }
            return false;
        }

        private bool RowIsMarkedRunning(ListViewItem lv_row) {
            // If the Is_Running value for the row is 1 return true, else false
            return (bool)lv_row.SubItems[Is_Running_i].Tag;
        }

        private long CalcElapsedRowTime(ListViewItem lv_row) {
            return (Utils.Times.GetUTCNow() - (long)lv_row.SubItems[Start_Time_i].Tag);
        }

        /// <summary>
        /// Clears the rows that have been selected by the user with (Ctrl +) Left Click
        /// </summary>
        public void ClearSelections() {
            this.listView.SelectedItems.Clear();
        }
        #endregion

        #region Macro
        /// <summary>
        /// Clears and updates this.listView using db values, used during initialisation only
        /// </summary>
        /// <param name="procDataList"></param>
        private void InitListItems(List<ProcData> procDataList) {
            // Init SmallImageList to an empty ImageList with dimensions of 18,18
            ImageList smallImgList = new ImageList {
                ImageSize = new Size(18, 18)
            };
            this.listView.SmallImageList = smallImgList;

            // Add all items from procDataList to this.listView
            this.listView.BeginUpdate();

            foreach (ProcData procData in procDataList) {
                AddLVItem(procData);
            }

            this.listView.EndUpdate();
        }

        // Adds new (unique) entries to this.listView from the db
        public void AddUniqueLVItems(List<ProcData> procDataList) {
            this.listView.BeginUpdate();

            // Loop through each row in DataTable
            foreach (ProcData procData in procDataList) {
                if (!LVContainsProcName(procData.ProcessName)) {
                    AddLVItem(procData);
                }
            }

            this.listView.EndUpdate();
        }

        /// <summary>
        /// Deletes items selected by the user in this.listView
        /// </summary>
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

        /// <summary>
        /// Updates the values in the Elapsed_Time col using the time between now and the last updateElapsedCol_Timer_Tick call
        /// </summary>
        private void UpdateElapsedCol() {
            this.listView.BeginUpdate();

            foreach (ListViewItem lv_row in this.listView.Items) {
                if (RowIsMarkedRunning(lv_row)) {
                    // Handle Elapsed_Time col
                    lv_row.SubItems[Elapsed_Time_i].Tag = (long)lv_row.SubItems[Elapsed_Time_i].Tag + OneMin;
                    lv_row.SubItems[Elapsed_Time_i].Text = Utils.Times.SecsToHMSString((long)lv_row.SubItems[Elapsed_Time_i].Tag);
                }
            }

            this.listView.EndUpdate();
        }
        /// <summary>
        /// Updates the values in a single row of this.listView (called from EditRecordForm)
        /// TODO: Rewrite this later
        /// </summary>
        public void UpdateLVItem(ProcData newProcData) {
            this.listView.BeginUpdate();

            // Find the lv item that matches the name of newProcData
            ListViewItem recordRow = new ListViewItem();
            foreach (ListViewItem lv_row in this.listView.Items) {
                if (lv_row.SubItems[Process_Name_i].Text == newProcData.ProcessName) {
                    recordRow = lv_row;
                    break;
                }
            }

            // Icon
            Bitmap resizedIcon = new Bitmap(newProcData.Icon, 18, 18);
            this.listView.SmallImageList.Images[recordRow.ImageIndex] = resizedIcon;
            resizedIcon.Dispose();
            // Prog name
            recordRow.SubItems[Program_Name_i].Text = newProcData.ProgramName;
            // Opened
            if (!RowIsMarkedRunning(recordRow)) {
                recordRow.SubItems[Date_Opened_i].Text = Utils.Times.ISOToLogicalDateString(newProcData.DateOpened);
            }
            // Total
            recordRow.SubItems[Total_Time_i].Text = Utils.Times.SecsToHMSString(newProcData.TotalTime);
            recordRow.SubItems[Total_Time_i].Tag = newProcData.TotalTime;
            // Added
            recordRow.SubItems[Date_Added_i].Text = Utils.Times.ISOToShortDateString(newProcData.DateAdded);
            // Path
            recordRow.SubItems[Process_Path_i].Text = newProcData.ProcessPath;

            this.listView.EndUpdate();
        }
        #endregion

        #region Micro
        /// <summary>
        /// Adds a proc data object to this.listView as a new row
        /// </summary>
        private void AddLVItem(ProcData procData) {
            ListViewItem lv_row = procData.ToLVItem();
            // Set lv_row's ImageIndex, and inc _imgIndex for the next row
            lv_row.ImageIndex = _numImages;
            _numImages++;
            // Add icon from procData to this.listView.SmallImageList
            this.listView.SmallImageList.Images.Add(procData.Icon);
            // Add the new row to this.listView
            this.listView.Items.Add(lv_row);
        }

        /// <summary>
        /// Uses a list of running procs (from ProcMonitor) to shade items in this.listView green
        /// TODO: Rewrite this later
        /// </summary>
        public void UpdateRunningStates(List<string> running, bool raiseDBRequests = true) {
            Dictionary<string, long> procTimePairs = new Dictionary<string, long>();

            foreach (ListViewItem lv_row in this.listView.Items) {
                // If an item in running is present in this.listView
                if (running.Contains(lv_row.SubItems[Process_Name_i].Text)) {
                    // Set bg colour in this.listView to green
                    lv_row.BackColor = Color.PaleGreen;

                    // If the process wasn't marked as running in this.listView yet
                    if (!RowIsMarkedRunning(lv_row)) {
                        // Update Elapsed_Time text to 0
                        lv_row.SubItems[Elapsed_Time_i].Text = "0m";
                        lv_row.SubItems[Elapsed_Time_i].Tag = (long)0;
                        // Change Opened To "Today"
                        lv_row.SubItems[Date_Opened_i].Text = "Today";
                        // Set Is_Running to 1
                        lv_row.SubItems[Is_Running_i].Text = "true";
                        lv_row.SubItems[Is_Running_i].Tag = true;
                        // Save Start_Time
                        lv_row.SubItems[Start_Time_i].Text = Utils.Times.GetUTCNow().ToString();
                        lv_row.SubItems[Start_Time_i].Tag = Utils.Times.GetUTCNow();
                    }
                }
                else {
                    // Set bg colour in this.listView to white
                    lv_row.BackColor = Color.White;

                    // If lv_row was marked Is_Running, add process name and elapsed time to procTimePairs
                    if (raiseDBRequests && RowIsMarkedRunning(lv_row)) {
                        long elapsedTime = CalcElapsedRowTime(lv_row);
                        procTimePairs.Add(lv_row.SubItems[Process_Name_i].Text, elapsedTime);

                        // Update Total_Time to contain time the proc was running till now
                        lv_row.SubItems[Total_Time_i].Tag = (long)lv_row.SubItems[Total_Time_i].Tag + elapsedTime;
                        lv_row.SubItems[Total_Time_i].Text = Utils.Times.SecsToHMSString((long)lv_row.SubItems[Total_Time_i].Tag);
                    }
                    // Reset Elapsed_Time to default
                    lv_row.SubItems[Elapsed_Time_i].Text = "-";
                    lv_row.SubItems[Elapsed_Time_i].Tag = (long)-1;
                    // Reset Start_Time to default
                    lv_row.SubItems[Start_Time_i].Text = "null";
                    lv_row.SubItems[Start_Time_i].Tag = (long)-1;
                    // Reset Is_Running to default
                    lv_row.SubItems[Is_Running_i].Tag = false;
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

    #region Double Buffer Fix
    /// <summary>
    /// Reflection class required to prevent flickering during resize events
    /// </summary>
    public static class ControlExtensions {
        public static void DoubleBuffering(this Control control, bool enable) {
            PropertyInfo doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }
    }
    #endregion
}
