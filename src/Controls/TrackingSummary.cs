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
    public partial class TrackingSummary : UserControl {
        public Bitmap ProcIcon { get; set; }
        public int TrackedCount { get; set; }
        public int RunningCount { get; set; }
        public long Uptime { get; set; }

        public TrackingSummary() {
            InitializeComponent();
            refreshUptime_Timer.Start();
        }

        public void RerenderFields() {
            this.picturePanel.BackgroundImage = this.ProcIcon;
            this.trackingLabel.Text = String.Format("Tracking: {0}", TrackedCount);
            this.runningLabel.Text = String.Format("Running: {0}", RunningCount);
            this.uptimeLabel.Text = String.Format("Uptime: {0}", Utils.Times.SecsToHMString(this.Uptime));
        }

        private void refreshUptime_Timer_Tick(object sender, EventArgs e) {
            this.Uptime += refreshUptime_Timer.Interval / 1000;
            this.uptimeLabel.Text = String.Format("Uptime: {0}", Utils.Times.SecsToHMString(this.Uptime));
        }
    }
}
