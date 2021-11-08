﻿
namespace trakr_sharp.Controls {
    partial class TrackingSummary {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.GroupBox groupBox;
            System.Windows.Forms.TableLayoutPanel tableLayout;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackingSummary));
            this.picturePanel = new System.Windows.Forms.Panel();
            this.trackingLabel = new System.Windows.Forms.Label();
            this.runningLabel = new System.Windows.Forms.Label();
            this.uptimeLabel = new System.Windows.Forms.Label();
            groupBox = new System.Windows.Forms.GroupBox();
            tableLayout = new System.Windows.Forms.TableLayoutPanel();
            groupBox.SuspendLayout();
            tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            groupBox.Controls.Add(tableLayout);
            groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox.Location = new System.Drawing.Point(0, 0);
            groupBox.Name = "groupBox";
            groupBox.Size = new System.Drawing.Size(150, 180);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "Summary";
            // 
            // tableLayout
            // 
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayout.Controls.Add(this.uptimeLabel, 0, 3);
            tableLayout.Controls.Add(this.picturePanel, 0, 0);
            tableLayout.Controls.Add(this.trackingLabel, 0, 1);
            tableLayout.Controls.Add(this.runningLabel, 0, 2);
            tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayout.Location = new System.Drawing.Point(3, 16);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 4;
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61F));
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            tableLayout.Size = new System.Drawing.Size(144, 161);
            tableLayout.TabIndex = 0;
            // 
            // picturePanel
            // 
            this.picturePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picturePanel.BackgroundImage")));
            this.picturePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePanel.Location = new System.Drawing.Point(3, 3);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(138, 92);
            this.picturePanel.TabIndex = 0;
            // 
            // trackingLabel
            // 
            this.trackingLabel.AutoSize = true;
            this.trackingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackingLabel.Location = new System.Drawing.Point(3, 98);
            this.trackingLabel.Name = "trackingLabel";
            this.trackingLabel.Size = new System.Drawing.Size(138, 20);
            this.trackingLabel.TabIndex = 1;
            this.trackingLabel.Text = "Tracking 0 Processes";
            this.trackingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // runningLabel
            // 
            this.runningLabel.AutoSize = true;
            this.runningLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runningLabel.Location = new System.Drawing.Point(3, 118);
            this.runningLabel.Name = "runningLabel";
            this.runningLabel.Size = new System.Drawing.Size(138, 20);
            this.runningLabel.TabIndex = 2;
            this.runningLabel.Text = "0 Processes Running";
            this.runningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uptimeLabel
            // 
            this.uptimeLabel.AutoSize = true;
            this.uptimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uptimeLabel.Location = new System.Drawing.Point(3, 138);
            this.uptimeLabel.Name = "uptimeLabel";
            this.uptimeLabel.Size = new System.Drawing.Size(138, 23);
            this.uptimeLabel.TabIndex = 3;
            this.uptimeLabel.Text = "Uptime 0:00";
            this.uptimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackingSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupBox);
            this.Name = "TrackingSummary";
            this.Size = new System.Drawing.Size(150, 180);
            groupBox.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.Label uptimeLabel;
        private System.Windows.Forms.Label trackingLabel;
        private System.Windows.Forms.Label runningLabel;
    }
}
