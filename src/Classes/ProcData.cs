using System;
using System.Windows.Forms;
using System.Drawing;

namespace TrakrSharp {
    /// <summary>
    /// An alternate representation of a database document for a tracked process with extra fields for use at runtime.
    /// i.e. ElapsedTime, IsRunning and StartTime
    /// </summary>
    public class ProcData {
        #region Constants
        public const int Count = 10;
        #endregion

        #region Fields
        public Bitmap Icon { get; set; }
        public string ProgramName { get; set; }
        public long ElapsedTime { get; set; }
        public string DateOpened { get; set; } // ISO Format
        public long TotalTime { get; set; }
        public string DateAdded { get; set; } // ISO Format

        public string ProcessName { get; set; }
        public string ProcessPath { get; set; }
        public bool IsRunning { get; set; }
        public long StartTime { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Converts this ProcData instance into a ListViewItem for use with WinForms
        /// </summary>
        public ListViewItem ToLVItem() {
            // Create new ListViewItem instance (skip populating Icon column with no constructor params)
            ListViewItem lvItem = new ListViewItem();

            // Program_Name [1]
            lvItem.SubItems.Add(this.ProgramName);
            // Elapsed_Time [2]
            lvItem.SubItems.Add(this.ElapsedTime == -1 ? "-" : this.ElapsedTime.ToString());
            lvItem.SubItems[2].Tag = this.ElapsedTime;
            // Date_Opened [3]
            lvItem.SubItems.Add(Utils.Times.ISOToLogicalDateString(this.DateOpened));
            // Total_Time [4]
            lvItem.SubItems.Add(Utils.Times.SecsToHMSString(this.TotalTime));
            lvItem.SubItems[4].Tag = this.TotalTime;

            // Date_Added [5]
            lvItem.SubItems.Add(Utils.Times.ISOToShortDateString(this.DateAdded));
            // Process_Name [6]
            lvItem.SubItems.Add(this.ProcessName);
            // Process_Path [7]
            lvItem.SubItems.Add(this.ProcessPath);
            // Is_Running [8]
            lvItem.SubItems.Add(this.IsRunning.ToString());
            lvItem.SubItems[8].Tag = this.IsRunning;
            // Start_Time [9]
            lvItem.SubItems.Add(this.StartTime == -1 ? "null" : this.StartTime.ToString());
            lvItem.SubItems[9].Tag = this.StartTime;

            return lvItem;
        }
        #endregion
    }
}
