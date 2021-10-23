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
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            InitFormProperties();

            string currTime = DateTime.Now.ToString("h:mm:ss");
            this.textBox1.AppendText(String.Format("[{0}] Welcome to trakr", currTime));
        }

        /// <summary>
        /// Set intial window appearance/properties
        /// </summary>
        private void InitFormProperties() {
            this.Text = "trakr";
            this.Size = new Size(640, 360);
            this.CenterToScreen();
        }
    }
}
