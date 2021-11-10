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
        public EditRecordForm() {
            InitializeComponent();

            this.textBox1.Select();
        }
        #endregion

        #region LocalEventHandlers
        private void EditRecordForm_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (Control c in this.Controls) {
                c.Dispose();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            Utils.SysCalls.Print("cancel clicked");
            this.Close();
        }
        private void applyButton_Click(object sender, EventArgs e) {
            Utils.SysCalls.Print("apply clicked");
        }
        #endregion
    }
}
