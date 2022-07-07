using System;
using System.Windows.Forms;

namespace trakr_sharp {
    public partial class AboutForm : Form {
        #region Init
        public AboutForm() {
            InitializeComponent();
        }
        #endregion

        #region Local Event Handlers
        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.iconPictureBox.BackgroundImage != null) {
                this.iconPictureBox.BackgroundImage.Dispose();
            }

            foreach (Control c in this.Controls) {
                c.Dispose();
            }

            this.Dispose();
        }

        private void okButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void websiteLabel_Click(object sender, EventArgs e) {
            // Open repo link in browser window
            bool success = Utils.SysCalls.OpenRepoLink();
            // Show error message if failed to open wesbite
            if (!success) {
                MessageBox.Show("Attempt to open link with browser was unsuccessful.", "Failed to open repository link",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
    }
}
