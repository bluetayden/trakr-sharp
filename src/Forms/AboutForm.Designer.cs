
namespace trakr_sharp {
    partial class AboutForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.infoLayout = new System.Windows.Forms.TableLayoutPanel();
            this.infoLabelsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.nameVersionLabel = new System.Windows.Forms.Label();
            this.websiteLabel = new System.Windows.Forms.LinkLabel();
            this.authorLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.mainLayout.SuspendLayout();
            this.infoLayout.SuspendLayout();
            this.infoLabelsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.Controls.Add(this.okButton, 0, 1);
            this.mainLayout.Controls.Add(this.infoLayout, 0, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mainLayout.Size = new System.Drawing.Size(255, 116);
            this.mainLayout.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.okButton.Location = new System.Drawing.Point(174, 87);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // infoLayout
            // 
            this.infoLayout.ColumnCount = 2;
            this.infoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.infoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.infoLayout.Controls.Add(this.infoLabelsLayout, 1, 0);
            this.infoLayout.Controls.Add(this.iconPictureBox, 0, 0);
            this.infoLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLayout.Location = new System.Drawing.Point(3, 3);
            this.infoLayout.Name = "infoLayout";
            this.infoLayout.RowCount = 1;
            this.infoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infoLayout.Size = new System.Drawing.Size(249, 75);
            this.infoLayout.TabIndex = 1;
            // 
            // infoLabelsLayout
            // 
            this.infoLabelsLayout.ColumnCount = 1;
            this.infoLabelsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infoLabelsLayout.Controls.Add(this.nameVersionLabel, 0, 0);
            this.infoLabelsLayout.Controls.Add(this.websiteLabel, 0, 2);
            this.infoLabelsLayout.Controls.Add(this.authorLabel, 0, 1);
            this.infoLabelsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLabelsLayout.Location = new System.Drawing.Point(86, 3);
            this.infoLabelsLayout.Name = "infoLabelsLayout";
            this.infoLabelsLayout.RowCount = 3;
            this.infoLabelsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.infoLabelsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.infoLabelsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.infoLabelsLayout.Size = new System.Drawing.Size(160, 69);
            this.infoLabelsLayout.TabIndex = 0;
            // 
            // nameVersionLabel
            // 
            this.nameVersionLabel.AutoSize = true;
            this.nameVersionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameVersionLabel.Location = new System.Drawing.Point(3, 0);
            this.nameVersionLabel.Name = "nameVersionLabel";
            this.nameVersionLabel.Size = new System.Drawing.Size(154, 22);
            this.nameVersionLabel.TabIndex = 0;
            this.nameVersionLabel.Text = "trakr-sharp v1.0.2b";
            this.nameVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // websiteLabel
            // 
            this.websiteLabel.AutoSize = true;
            this.websiteLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.websiteLabel.Location = new System.Drawing.Point(3, 45);
            this.websiteLabel.Name = "websiteLabel";
            this.websiteLabel.Size = new System.Drawing.Size(154, 24);
            this.websiteLabel.TabIndex = 3;
            this.websiteLabel.TabStop = true;
            this.websiteLabel.Text = "GitHub";
            this.websiteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.websiteLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.websiteLabel.Click += new System.EventHandler(this.websiteLabel_Click);
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authorLabel.Location = new System.Drawing.Point(3, 22);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(154, 23);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "by bluetayden";
            this.authorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconPictureBox.BackgroundImage")));
            this.iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.iconPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconPictureBox.Location = new System.Drawing.Point(3, 3);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(77, 69);
            this.iconPictureBox.TabIndex = 1;
            this.iconPictureBox.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 116);
            this.Controls.Add(this.mainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AboutForm_FormClosing);
            this.mainLayout.ResumeLayout(false);
            this.infoLayout.ResumeLayout(false);
            this.infoLabelsLayout.ResumeLayout(false);
            this.infoLabelsLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TableLayoutPanel infoLayout;
        private System.Windows.Forms.TableLayoutPanel infoLabelsLayout;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label nameVersionLabel;
        private System.Windows.Forms.LinkLabel websiteLabel;
        private System.Windows.Forms.Label authorLabel;
    }
}