
namespace trakr_sharp {
    partial class MainForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainGridLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLayout = new System.Windows.Forms.GroupBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.programConsole = new System.Windows.Forms.TextBox();
            this.sysTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.sysTrayIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trakrToolStripMenuLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackingList = new trakr_sharp.Controls.TrackingList();
            this.trackingSummary = new trakr_sharp.Controls.TrackingSummary();
            this.mainGridLayout.SuspendLayout();
            this.buttonLayout.SuspendLayout();
            this.sysTrayIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGridLayout
            // 
            this.mainGridLayout.ColumnCount = 2;
            this.mainGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.mainGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainGridLayout.Controls.Add(this.buttonLayout, 1, 1);
            this.mainGridLayout.Controls.Add(this.programConsole, 0, 1);
            this.mainGridLayout.Controls.Add(this.trackingList, 0, 0);
            this.mainGridLayout.Controls.Add(this.trackingSummary, 1, 0);
            this.mainGridLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGridLayout.Location = new System.Drawing.Point(0, 0);
            this.mainGridLayout.Name = "mainGridLayout";
            this.mainGridLayout.RowCount = 2;
            this.mainGridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.mainGridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.mainGridLayout.Size = new System.Drawing.Size(644, 341);
            this.mainGridLayout.TabIndex = 0;
            // 
            // buttonLayout
            // 
            this.buttonLayout.Controls.Add(this.settingsButton);
            this.buttonLayout.Controls.Add(this.deleteButton);
            this.buttonLayout.Controls.Add(this.editButton);
            this.buttonLayout.Controls.Add(this.addButton);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayout.Location = new System.Drawing.Point(486, 224);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Size = new System.Drawing.Size(155, 114);
            this.buttonLayout.TabIndex = 0;
            this.buttonLayout.TabStop = false;
            this.buttonLayout.Text = "Tracking";
            // 
            // settingsButton
            // 
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsButton.Location = new System.Drawing.Point(3, 85);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(149, 23);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(3, 62);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(149, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(3, 39);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(149, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit";
            this.editButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addButton.Location = new System.Drawing.Point(3, 16);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(149, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // programConsole
            // 
            this.programConsole.AcceptsReturn = true;
            this.programConsole.BackColor = System.Drawing.SystemColors.Window;
            this.programConsole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.programConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programConsole.Location = new System.Drawing.Point(3, 224);
            this.programConsole.Multiline = true;
            this.programConsole.Name = "programConsole";
            this.programConsole.ReadOnly = true;
            this.programConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.programConsole.Size = new System.Drawing.Size(477, 114);
            this.programConsole.TabIndex = 1;
            this.programConsole.Enter += new System.EventHandler(this.programConsole_Enter);
            // 
            // sysTrayIcon
            // 
            this.sysTrayIcon.ContextMenuStrip = this.sysTrayIconContextMenu;
            this.sysTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("sysTrayIcon.Icon")));
            this.sysTrayIcon.Text = "trakr";
            this.sysTrayIcon.Visible = true;
            this.sysTrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sysTrayIcon_MouseClick);
            // 
            // sysTrayIconContextMenu
            // 
            this.sysTrayIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trakrToolStripMenuLabel,
            this.exitToolStripMenuItem});
            this.sysTrayIconContextMenu.Name = "sysTrayIconContextMenu";
            this.sysTrayIconContextMenu.Size = new System.Drawing.Size(121, 48);
            // 
            // trakrToolStripMenuLabel
            // 
            this.trakrToolStripMenuLabel.Enabled = false;
            this.trakrToolStripMenuLabel.Image = ((System.Drawing.Image)(resources.GetObject("trakrToolStripMenuLabel.Image")));
            this.trakrToolStripMenuLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.trakrToolStripMenuLabel.Name = "trakrToolStripMenuLabel";
            this.trakrToolStripMenuLabel.Size = new System.Drawing.Size(120, 22);
            this.trakrToolStripMenuLabel.Text = "trakr";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "Exit trakr";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // trackingList
            // 
            this.trackingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackingList.Location = new System.Drawing.Point(3, 3);
            this.trackingList.Name = "trackingList";
            this.trackingList.Size = new System.Drawing.Size(477, 215);
            this.trackingList.TabIndex = 2;
            // 
            // trackingSummary
            // 
            this.trackingSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackingSummary.Location = new System.Drawing.Point(486, 3);
            this.trackingSummary.Name = "trackingSummary";
            this.trackingSummary.ProcIcon = null;
            this.trackingSummary.ProcName = null;
            this.trackingSummary.RunningCount = 0;
            this.trackingSummary.Size = new System.Drawing.Size(155, 215);
            this.trackingSummary.TabIndex = 3;
            this.trackingSummary.TrackedCount = 0;
            this.trackingSummary.Uptime = ((long)(0));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 341);
            this.Controls.Add(this.mainGridLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(660, 380);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "trakr-sharp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainGridLayout.ResumeLayout(false);
            this.mainGridLayout.PerformLayout();
            this.buttonLayout.ResumeLayout(false);
            this.sysTrayIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox programConsole;
        private Controls.TrackingList trackingList;
        private Controls.TrackingSummary trackingSummary;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.TableLayoutPanel mainGridLayout;
        private System.Windows.Forms.GroupBox buttonLayout;
        private System.Windows.Forms.NotifyIcon sysTrayIcon;
        private System.Windows.Forms.ContextMenuStrip sysTrayIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem trakrToolStripMenuLabel;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

