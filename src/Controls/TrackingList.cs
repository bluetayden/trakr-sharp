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
        public TrackingList() {
            InitializeComponent();
        }

        // Returns list of selected values in the "Process_Name" column of this.listView
        public List<string> GetSelectedItems() {
            List<string> selectedProcNames = new List<string>();

            foreach (ListViewItem selectedItem in this.listView.SelectedItems) {
                selectedProcNames.Add(selectedItem.SubItems[6].Text);
            }

            return selectedProcNames;
        }

        // Updates the _trackedTable field and repopulates this.listView with it
        public void repopulateListView(DataTable trackedTable) {
            if (trackedTable.Rows.Count != this.listView.Items.Count) {
                this.listView.BeginUpdate();
                this.listView.Items.Clear();

                // Loop through each row in DataTable
                foreach (DataRow row in trackedTable.Rows) {
                    // Create a new LVItem (skip adding data to first column)
                    ListViewItem item = new ListViewItem();

                    // Add values from DataTable to each column in the LV item
                    // Keep in mind the last column (index 6) contains proc_names but isn't visible in the UI
                    for (int i = 0; i < trackedTable.Columns.Count; i++) {
                        item.SubItems.Add(row[i].ToString());
                    }

                    // Add the item to this.listView
                    listView.Items.Add(item);
                }

                this.listView.EndUpdate();
            }
        }

        // Uses a list to shade items in this.listView that are running green
        public void updateRunningColors(List<string> running) {
            foreach (ListViewItem lv_item in this.listView.Items) {
                // Keep in mind index 6 contains proc_names but isn't visible in the UI
                if (running.Contains(lv_item.SubItems[6].Text)) {
                    lv_item.BackColor = Color.PaleGreen;
                }
                else {
                    lv_item.BackColor = Color.White;
                }
            }
        }

        // Resizes columns using fixed proportions
        public void resizeColumnHeaders() {
            int width = this.listView.Width - 26;

            listView.Columns[0].Width = 24;
            listView.Columns[1].Width = (int)(width * 0.3);
            for (int i = 2; i < this.listView.Columns.Count; i++) {
                listView.Columns[i].Width = (int)(width * 0.175);
            }
        }
    }
}
