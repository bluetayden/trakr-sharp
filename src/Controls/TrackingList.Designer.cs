
namespace trakr_sharp.Controls {
    partial class TrackingList {
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
            this.listView = new System.Windows.Forms.ListView();
            this.Program_Icon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Program_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Elapsed_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date_Opened = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hours_Used = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date_Added = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Process_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Program_Icon,
            this.Program_Name,
            this.Elapsed_Time,
            this.Date_Opened,
            this.Hours_Used,
            this.Date_Added,
            this.Process_Name});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(434, 150);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // Program_Icon
            // 
            this.Program_Icon.Text = "";
            this.Program_Icon.Width = 24;
            // 
            // Program_Name
            // 
            this.Program_Name.Text = "Name";
            this.Program_Name.Width = 120;
            // 
            // Elapsed_Time
            // 
            this.Elapsed_Time.Text = "Elapsed";
            this.Elapsed_Time.Width = 70;
            // 
            // Date_Opened
            // 
            this.Date_Opened.Text = "Opened";
            this.Date_Opened.Width = 70;
            // 
            // Hours_Used
            // 
            this.Hours_Used.Text = "Hours";
            // 
            // Date_Added
            // 
            this.Date_Added.Text = "Added";
            this.Date_Added.Width = 70;
            // 
            // Process_Name
            // 
            this.Process_Name.Width = 0;
            // 
            // TrackingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Name = "TrackingList";
            this.Size = new System.Drawing.Size(434, 150);
            this.Resize += new System.EventHandler(this.TrackingList_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Program_Icon;
        private System.Windows.Forms.ColumnHeader Program_Name;
        private System.Windows.Forms.ColumnHeader Elapsed_Time;
        private System.Windows.Forms.ColumnHeader Date_Opened;
        private System.Windows.Forms.ColumnHeader Hours_Used;
        private System.Windows.Forms.ColumnHeader Date_Added;
        private System.Windows.Forms.ColumnHeader Process_Name;
    }
}
