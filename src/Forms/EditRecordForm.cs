using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trakr_sharp {
    public partial class EditRecordForm : Form {
        #region Init
        private ProcRecord record { get; set; }
        private Bitmap tempProcIcon { get; set; }

        public EditRecordForm(string proc_name) {
            InitializeComponent();

            this.record = Utils.Database.GetProcRecord(proc_name);
            SetTextBoxesToDefault();

            this.progNameTextBox.Select();
            SubscribeToValueChanges();
        }
        #endregion

        #region LocalEventHandlers
        private void EditRecordForm_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (Control c in this.Controls) {
                c.Dispose();
            }

            this.Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void applyButton_Click(object sender, EventArgs e) {
            // Disable Apply button
            this.applyButton.Enabled = false;

            // Get values from controls, store in this.record
            record.program_name = this.progNameTextBox.Text;
            record.total_time = (long)((this.hoursCounter.Value * 3600) + (this.minsCounter.Value * 60));
            record.date_opened = this.dateOpenedTimePicker.Value.ToString("o");
            record.date_added = this.dateAddedTimePicker.Value.ToString("o");

            try {
                // Changing proc icon and path
                if (record.proc_path != this.procPathTextBox.Text) {
                    // Save new path to record instance
                    record.proc_path = this.procPathTextBox.Text;

                    // Cache the icon from the selected file to disk
                    Dictionary<string, string> temp = new Dictionary<string, string>() {
                    { record.proc_name, this.procPathTextBox.Text } };
                    Utils.SysCalls.CacheIconsToDisk(temp, true);
                }

                // Write the new record to db
                Utils.Database.UpdateRecord(this.record);
                
                // Show success message
                MessageBox.Show(this.record.proc_name + " record has been updated", "Record successfuly saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.cancelButton.PerformClick();
            }
            catch (Exception ex) {
                // Show error message
                MessageBox.Show(ex.ToString(), "Error saving edits",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reenable Apply button
                this.applyButton.Enabled = true;
            }
        }

        private void browseButton_Click(object sender, EventArgs e) {
            // Let user pick an exe file
            this.openFileDialog.ShowDialog();

            // If a file was picked
            if (this.openFileDialog.FileName != "") {
                // Set procPathTextBox to the selected file
                this.procPathTextBox.Text = this.openFileDialog.FileName;
                this.openFileDialog.FileName = "";

                // Attempt to get icon from selected path
                tempProcIcon = Utils.SysCalls.GetIconFromPath(procPathTextBox.Text).ToBitmap();
                // Set procIconBox to the newly loaded icon
                this.procIconBox.BackgroundImage.Dispose();
                this.procIconBox.BackgroundImage = tempProcIcon;
            }
        }

        private void onControlValueChanged(object sender, EventArgs e) {
            this.applyButton.Enabled = true;
        }
        #endregion

        #region Methods
        private void SetTextBoxesToDefault() {
            // Set name boxes
            this.progNameTextBox.Text = record.program_name;
            this.procNameTextBox.Text = record.proc_name;

            // Set total time pickers
            this.hoursCounter.Value = Math.Floor((decimal)(record.total_time / 3600));

            decimal mins = Math.Floor(record.total_time - (this.hoursCounter.Value * 3600)) / 60;
            if (mins > 59) {
                this.minsCounter.Value = 59;
            }
            else {
                this.minsCounter.Value = (int)mins;
            }

            // Set date pickers
            DateTime lastOpenedDate = DateTime.Parse(record.date_opened);
            this.dateOpenedTimePicker.Value = lastOpenedDate;
            DateTime addedDate = DateTime.Parse(record.date_added);
            this.dateAddedTimePicker.Value = addedDate;

            // Set proc/icon fields
            this.procPathTextBox.Text = record.proc_path;
            this.procIconBox.BackgroundImage = Utils.SysCalls.GetProcBitmap(record.proc_name);
        }

        private void SubscribeToValueChanges() {
            this.progNameTextBox.TextChanged += onControlValueChanged;

            this.hoursCounter.ValueChanged += onControlValueChanged;
            this.minsCounter.ValueChanged += onControlValueChanged;

            this.dateAddedTimePicker.ValueChanged += onControlValueChanged;
            this.dateOpenedTimePicker.ValueChanged += onControlValueChanged;

            this.procPathTextBox.TextChanged += onControlValueChanged;
        }
        #endregion
    }
}
