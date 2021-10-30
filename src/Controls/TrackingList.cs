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
        #region Init
        private List<string> _trackedProcs = new List<string>(); // List of tracked procs from db
        private List<string> _runningTrackedProcs = new List<string>(); // List of procs that are running and in db

        public TrackingList() {
            InitializeComponent();
        }
        #endregion

        #region LocalEventHandlers
        // Called whenever a new item is added to this._trackedList, draws contents of _trackedProcs
        // and shades them green if they are also in _runningTrackedProcs
        private void listBox_DrawItem(object sender, DrawItemEventArgs e) {
            // Get item at e.Index from this.listBox
            string item = this.listBox.Items[e.Index].ToString();

            // Draw the background depending on if the proc is running
            if (_runningTrackedProcs.Contains(item)) {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), e.Bounds);
            }
            else {
                e.DrawBackground();
            }

            // If item is selected
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
                // Draw text with highlight colour
                e.Graphics.DrawString(item, this.Font, SystemBrushes.HighlightText, e.Bounds.Left, e.Bounds.Top);
            }
            // If item not selected
            else {
                // Draw regular text colour
                e.Graphics.DrawString(item, this.Font, SystemBrushes.ControlText, e.Bounds.Left, e.Bounds.Top);
            }
        }

        // On leaving listBox focus, disable item highlighting
        private void listBox_Leave(object sender, EventArgs e) {
            this.listBox.SelectedIndex = -1;
        }
        #endregion

        #region Methods
        // Handles listBox reflecting addition of new programs to the db during runtime
        public void addTrackedProcs(List<string> procs) {
            // Add procs to _trackedProcs that were not already there
            this._trackedProcs.AddRange(procs.Where(proc => !this._trackedProcs.Contains(proc)));
        }

        // Updates _runningTrackedProcs based on currently running system procs
        public void updateRunningTrackedProcs(List<string> runningProcs) {
            this._runningTrackedProcs.Clear();

            // Add every item in runningProcs that is in _trackedProcs to _runningTrackedProcs
            this._runningTrackedProcs = runningProcs.Where(proc => _trackedProcs.Contains(proc)).Cast<string>().ToList();
        }

        // Update this.listBox to reflect changes in _runningTrackedProcs
        public void updateListBox() {
            this.listBox.BeginUpdate();

            // Clear this.listBox
            this.listBox.Items.Clear();

            // Add values from _trackedProcs to this.listBox (implicitly calls listBox_DrawItem which handles green shading)
            foreach (string proc in this._trackedProcs) {
                this.listBox.Items.Add(proc);
            }

            // Remove highlighting of first item on update
            this.listBox.SelectedIndex = -1;

            this.listBox.EndUpdate();

            Utils.SysCalls.Print("Updated TrackingList ListBox");
        }
        #endregion
    }
}
