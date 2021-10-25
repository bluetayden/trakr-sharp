
namespace trakr_sharp.Controls {
    partial class SearchBox {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBox));
            this.searchIcon = new System.Windows.Forms.PictureBox();
            this.queryBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchIcon
            // 
            this.searchIcon.BackColor = System.Drawing.Color.White;
            this.searchIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.searchIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchIcon.Image = ((System.Drawing.Image)(resources.GetObject("searchIcon.Image")));
            this.searchIcon.Location = new System.Drawing.Point(3, 0);
            this.searchIcon.Margin = new System.Windows.Forms.Padding(0);
            this.searchIcon.Name = "searchIcon";
            this.searchIcon.Size = new System.Drawing.Size(20, 20);
            this.searchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.searchIcon.TabIndex = 1;
            this.searchIcon.TabStop = false;
            // 
            // queryBox
            // 
            this.queryBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.queryBox.Location = new System.Drawing.Point(23, 0);
            this.queryBox.Margin = new System.Windows.Forms.Padding(0);
            this.queryBox.Name = "queryBox";
            this.queryBox.Size = new System.Drawing.Size(227, 20);
            this.queryBox.TabIndex = 0;
            this.queryBox.Text = "Search...";
            this.queryBox.TextChanged += new System.EventHandler(this.queryBox_TextChanged);
            this.queryBox.Enter += new System.EventHandler(this.queryBox_OnFocus);
            this.queryBox.Leave += new System.EventHandler(this.queryBox_OnLeave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.searchIcon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.queryBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(253, 35);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // SearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SearchBox";
            this.Size = new System.Drawing.Size(253, 35);
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox searchIcon;
        private System.Windows.Forms.TextBox queryBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
