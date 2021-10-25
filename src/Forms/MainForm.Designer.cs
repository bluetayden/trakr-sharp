
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
            this.mainGridLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLayout = new System.Windows.Forms.GroupBox();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.programConsole = new System.Windows.Forms.TextBox();
            this.mainGridLayout.SuspendLayout();
            this.buttonLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGridLayout
            // 
            this.mainGridLayout.ColumnCount = 2;
            this.mainGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.mainGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainGridLayout.Controls.Add(this.buttonLayout, 1, 1);
            this.mainGridLayout.Controls.Add(this.splitContainer1, 0, 0);
            this.mainGridLayout.Controls.Add(this.programConsole, 0, 1);
            this.mainGridLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGridLayout.Location = new System.Drawing.Point(0, 0);
            this.mainGridLayout.Name = "mainGridLayout";
            this.mainGridLayout.RowCount = 2;
            this.mainGridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.mainGridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.mainGridLayout.Size = new System.Drawing.Size(624, 321);
            this.mainGridLayout.TabIndex = 0;
            // 
            // buttonLayout
            // 
            this.buttonLayout.Controls.Add(this.editButton);
            this.buttonLayout.Controls.Add(this.deleteButton);
            this.buttonLayout.Controls.Add(this.addButton);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayout.Location = new System.Drawing.Point(471, 211);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Size = new System.Drawing.Size(150, 107);
            this.buttonLayout.TabIndex = 0;
            this.buttonLayout.TabStop = false;
            this.buttonLayout.Text = "Tracking";
            // 
            // editButton
            // 
            this.editButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.editButton.Location = new System.Drawing.Point(3, 62);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(144, 23);
            this.editButton.TabIndex = 0;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteButton.Location = new System.Drawing.Point(3, 39);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(144, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addButton.Location = new System.Drawing.Point(3, 16);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(144, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Size = new System.Drawing.Size(462, 202);
            this.splitContainer1.SplitterDistance = 101;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(462, 101);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(462, 100);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // programConsole
            // 
            this.programConsole.AcceptsReturn = true;
            this.programConsole.BackColor = System.Drawing.SystemColors.Window;
            this.programConsole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.programConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programConsole.Location = new System.Drawing.Point(3, 211);
            this.programConsole.Multiline = true;
            this.programConsole.Name = "programConsole";
            this.programConsole.ReadOnly = true;
            this.programConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.programConsole.Size = new System.Drawing.Size(462, 107);
            this.programConsole.TabIndex = 3;
            this.programConsole.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.mainGridLayout);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "trakr";
            this.mainGridLayout.ResumeLayout(false);
            this.mainGridLayout.PerformLayout();
            this.buttonLayout.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainGridLayout;
        private System.Windows.Forms.GroupBox buttonLayout;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.TextBox programConsole;
    }
}

