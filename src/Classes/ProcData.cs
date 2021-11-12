using System;
using System.Windows.Forms;
using System.Drawing;

namespace trakr_sharp {
    public class ProcData {
        public readonly int Count = 10;

        #region Fields
        public Bitmap Icon { get; set; }
        public string Program_Name { get; set; }
        public long Elapsed_Time { get; set; }
        public string Date_Opened { get; set; } // ISO Format
        public long Total_Time { get; set; }
        public string Date_Added { get; set; } // ISO Format

        public string Process_Name { get; set; }
        public string Process_Path { get; set; }
        public bool Is_Running { get; set; }
        public long Start_Time { get; set; }
        #endregion

        #region Methods
        // Takes this ProcData instance and converts it to a ListViewItem
        public ListViewItem ToLVItem() {
            // Create new ListViewItem instance (skip populating Icon column with no constructor params)
            ListViewItem lv_item = new ListViewItem();

            // Handle Program_Name [1]
            lv_item.SubItems.Add(this.Program_Name);
            // Handle Elapsed_Time [2]
            lv_item.SubItems.Add(this.Elapsed_Time == 0 ? "-" : this.Elapsed_Time.ToString());
            lv_item.SubItems[2].Tag = this.Elapsed_Time;
            // Handle Date_Opened [3]
            lv_item.SubItems.Add(Utils.Times.ISOToLogicalDateString(this.Date_Opened));
            // Handle Total_Time [4]
            lv_item.SubItems.Add(Utils.Times.SecsToHMSString(this.Total_Time));
            lv_item.SubItems[4].Tag = this.Total_Time;
            // Handle Date_Added [5]
            lv_item.SubItems.Add(Utils.Times.ISOToShortDateString(this.Date_Added));

            // Handle Process_Name [6]
            lv_item.SubItems.Add(this.Process_Name);
            // Handle Process_Path [7]
            lv_item.SubItems.Add(this.Process_Path);
            // Handle Is_Running [8]
            lv_item.SubItems.Add(this.Is_Running.ToString());
            lv_item.SubItems[8].Tag = this.Is_Running;
            // Handle Start_Time [9]
            lv_item.SubItems.Add(this.Start_Time == -1 ? "null" : this.Start_Time.ToString());
            lv_item.SubItems[9].Tag = this.Start_Time;

            return lv_item;
        }
        #endregion
    }
}
