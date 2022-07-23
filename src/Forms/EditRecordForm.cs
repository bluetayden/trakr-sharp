using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrakrSharp {
    public partial class EditRecordForm : Form {
        private ProcRecord _record { get; set; }
        private Image _tempProcIcon { get; set; }

        #region Init
        public EditRecordForm(string proc_name) {
            InitializeComponent();

            this._record = Utils.Database.GetProcRecord(proc_name);
            SetControlValuesToOriginal();
            this.progNameTextBox.Select();
            SubscribeToValueChanges();
        }
        #endregion

        #region Local Event Handlers
        private void EditRecordForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (this._tempProcIcon != null) {
                this._tempProcIcon.Dispose();
            }
            if (this.procIconBox.BackgroundImage != null) {
                this.procIconBox.BackgroundImage.Dispose();
            }

            foreach (Control c in this.Controls) {
                c.Dispose();
            }
            this.Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void applyButton_Click(object sender, EventArgs e) {
            // Disable Apply button
            this.applyButton.Enabled = false;

            // Get values from controls, store in this.record
            _record.program_name = this.progNameTextBox.Text;
            _record.total_time = (long)((this.hoursCounter.Value * 3600) + (this.minsCounter.Value * 60));
            _record.date_opened = this.dateOpenedTimePicker.Value.ToString("o");
            _record.date_added = this.dateAddedTimePicker.Value.ToString("o");

            try {
                // Changing proc icon and path
                if (_record.proc_path != this.procPathTextBox.Text) {
                    // Save new path to record instance
                    _record.proc_path = this.procPathTextBox.Text;

                    // Cache the icon from the selected file to disk
                    Dictionary<string, string> temp = new Dictionary<string, string>() {
                    { _record.proc_name, this.procPathTextBox.Text } };
                    Utils.SysCalls.CacheIconsToDisk(temp, true);
                }

                // Write the new record to db
                Utils.Database.UpdateRecord(this._record);
                
                // Show success message
                MessageBox.Show(this._record.proc_name + " record has been updated", "Record successfuly saved",
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
            if (!string.IsNullOrWhiteSpace(this.openFileDialog.FileName)) {
                // Set procPathTextBox to the selected file
                this.procPathTextBox.Text = this.openFileDialog.FileName;
                this.openFileDialog.FileName = "";
                // Show the icon of the selected process in the form
                SetTempIconFromPath();
            }
        }

        private void detectButton_Click(object sender, EventArgs e) {
            Dictionary<string, string> procPathPair = 
                Utils.SysCalls.GetProcPathPairs(new List<string>() { this._record.proc_name });

            string path = procPathPair[_record.proc_name];

            if (!string.IsNullOrWhiteSpace(path)) {
                // Set procPathTextBox to the selected file
                this.procPathTextBox.Text = path;
                // Show the icon of the selected process in the form
                SetTempIconFromPath();
                // Show success message
                MessageBox.Show(this._record.proc_name + " found at\r\n" + path,
                    "Path found successfully",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                // Show error message
                MessageBox.Show("Path/File is innaccessible or " + _record.proc_name + " is not running.",
                    "Path could not be detected",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Called whenever a control value has changed. For enabling the apply button only once changes have ocurrred.
        /// </summary>
        private void OnControlValueChanged(object sender, EventArgs e) {
            this.applyButton.Enabled = true;
        }
        #endregion

        #region Methods
        private void SetControlValuesToOriginal() {
            // Set name boxes
            this.progNameTextBox.Text = _record.program_name;
            this.procNameTextBox.Text = _record.proc_name;

            // Set total time pickers
            this.hoursCounter.Value = Math.Floor((decimal)(_record.total_time / 3600));
            decimal mins = Math.Floor(_record.total_time - (this.hoursCounter.Value * 3600)) / 60;
            if (mins > 59) {
                this.minsCounter.Value = 59;
            }
            else {
                this.minsCounter.Value = (int)mins;
            }

            // Set date pickers
            DateTime lastOpenedDate = DateTime.Parse(_record.date_opened);
            this.dateOpenedTimePicker.Value = lastOpenedDate;
            DateTime addedDate = DateTime.Parse(_record.date_added);
            this.dateAddedTimePicker.Value = addedDate;

            // Set proc/icon fields
            this.procPathTextBox.Text = _record.proc_path;
            this.procIconBox.BackgroundImage = Utils.SysCalls.GetIconFromCache(_record.proc_name);
        }

        /// <summary>
        /// Make each control signal when one of its value has changed
        /// </summary>
        private void SubscribeToValueChanges() {
            this.progNameTextBox.TextChanged += OnControlValueChanged;
            this.progNameTextBox.KeyDown += OnControlValueChanged;

            this.hoursCounter.ValueChanged += OnControlValueChanged;
            this.hoursCounter.KeyDown += OnControlValueChanged;
            this.minsCounter.ValueChanged += OnControlValueChanged;
            this.minsCounter.KeyDown += OnControlValueChanged;

            this.dateAddedTimePicker.ValueChanged += OnControlValueChanged;
            this.dateOpenedTimePicker.ValueChanged += OnControlValueChanged;

            this.procPathTextBox.TextChanged += OnControlValueChanged;
            this.procIconBox.BackgroundImageChanged += OnControlValueChanged;
        }

        /// <summary>
        /// Shows the icon of the newly selected proc in the form using the provided path.
        /// "Temp" as the new icon will only persist if the user clicks "Apply".
        /// </summary>
        private void SetTempIconFromPath() {
            // Attempt to get icon from selected path
            if (_tempProcIcon != null) {
                _tempProcIcon.Dispose();
            }
            _tempProcIcon = Utils.SysCalls.GetIconFromPath(procPathTextBox.Text).ToBitmap();
            // Set procIconBox to the newly loaded icon
            this.procIconBox.BackgroundImage.Dispose();
            this.procIconBox.BackgroundImage = _tempProcIcon;
        }
        #endregion
    }
}
