using System;
using System.Windows.Forms;

namespace trakr_sharp {
    public partial class SettingsForm : Form {
        private UserSettings _userSettings;

        #region Init
        public SettingsForm() {
            InitializeComponent();

            _userSettings = Utils.SysCalls.ReadUserSettings();
            SetControlValuesToOriginal();
            SubscribeToValueChanges();
        }
        #endregion

        #region Local Event Handlers
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e) {
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
            this._userSettings.OnClose = (UserSettings.CloseBehaviour)this.closeBehaviourComboBox.SelectedIndex;
            this._userSettings.RunOnStartup = this.startupBehaviourCheckbox.Checked;
            this._userSettings.EnableScreenshots = this.enableScreenshotsCheckbox.Checked;
            this._userSettings.ShowUtilCols = this.showUtilityColsCheckbox.Checked;

            try {
                Utils.SysCalls.UpdateUserSettings(_userSettings);
                this.applyButton.Enabled = false;
                // Show success message
                MessageBox.Show("Settings updated successfully", "Save Succesful",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Close settings window
                cancelButton.PerformClick();
            }
            catch (Exception ex) {
                // Show error message
                MessageBox.Show(ex.ToString(), "Error saving",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OnControlValueChanged(object sender, EventArgs e) {
            this.applyButton.Enabled = true;
        }
        #endregion

        #region Methods
        private void SetControlValuesToOriginal() {
            this.closeBehaviourComboBox.SelectedIndex = (int)_userSettings.OnClose;
            this.startupBehaviourCheckbox.Checked = _userSettings.RunOnStartup;
            this.enableScreenshotsCheckbox.Checked = _userSettings.EnableScreenshots;
            this.showUtilityColsCheckbox.Checked = _userSettings.ShowUtilCols;
        }

        private void SubscribeToValueChanges() {
            this.closeBehaviourComboBox.SelectedValueChanged += OnControlValueChanged; 
            this.startupBehaviourCheckbox.CheckedChanged += OnControlValueChanged;
            this.enableScreenshotsCheckbox.CheckedChanged += OnControlValueChanged;
            this.showUtilityColsCheckbox.CheckedChanged += OnControlValueChanged; 
        }
        #endregion
    }
}
