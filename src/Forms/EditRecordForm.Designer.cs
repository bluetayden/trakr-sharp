
namespace trakr_sharp {
    partial class EditRecordForm {
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
            System.Windows.Forms.Panel applyCancelPanel;
            System.Windows.Forms.GroupBox nameGroupBox;
            System.Windows.Forms.GroupBox timeDateGroupBox;
            System.Windows.Forms.GroupBox pathIconGroupBox;
            this.cancelButton = new System.Windows.Forms.Button();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.applyButton = new System.Windows.Forms.Button();
            this.fieldsTable = new System.Windows.Forms.TableLayoutPanel();
            this.timeDateFieldLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pathIconFieldLayout = new System.Windows.Forms.TableLayoutPanel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.nameFieldLayout = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.progNameLabel = new System.Windows.Forms.Label();
            this.procNameLabel = new System.Windows.Forms.Label();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.dateOpenedLabel = new System.Windows.Forms.Label();
            this.dateAddedLabel = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            applyCancelPanel = new System.Windows.Forms.Panel();
            nameGroupBox = new System.Windows.Forms.GroupBox();
            timeDateGroupBox = new System.Windows.Forms.GroupBox();
            pathIconGroupBox = new System.Windows.Forms.GroupBox();
            applyCancelPanel.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.fieldsTable.SuspendLayout();
            nameGroupBox.SuspendLayout();
            timeDateGroupBox.SuspendLayout();
            pathIconGroupBox.SuspendLayout();
            this.timeDateFieldLayout.SuspendLayout();
            this.pathIconFieldLayout.SuspendLayout();
            this.nameFieldLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyCancelPanel
            // 
            applyCancelPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            applyCancelPanel.Controls.Add(this.applyButton);
            applyCancelPanel.Controls.Add(this.cancelButton);
            applyCancelPanel.Location = new System.Drawing.Point(306, 290);
            applyCancelPanel.Margin = new System.Windows.Forms.Padding(0);
            applyCancelPanel.Name = "applyCancelPanel";
            applyCancelPanel.Size = new System.Drawing.Size(158, 35);
            applyCancelPanel.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(3, 6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(applyCancelPanel, 0, 1);
            this.mainLayout.Controls.Add(this.fieldsTable, 0, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mainLayout.Size = new System.Drawing.Size(464, 325);
            this.mainLayout.TabIndex = 0;
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(80, 6);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 8;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // fieldsTable
            // 
            this.fieldsTable.ColumnCount = 1;
            this.fieldsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fieldsTable.Controls.Add(nameGroupBox, 0, 0);
            this.fieldsTable.Controls.Add(timeDateGroupBox, 0, 1);
            this.fieldsTable.Controls.Add(pathIconGroupBox, 0, 2);
            this.fieldsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldsTable.Location = new System.Drawing.Point(3, 3);
            this.fieldsTable.Name = "fieldsTable";
            this.fieldsTable.RowCount = 3;
            this.fieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.53868F));
            this.fieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.92265F));
            this.fieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.53868F));
            this.fieldsTable.Size = new System.Drawing.Size(458, 284);
            this.fieldsTable.TabIndex = 5;
            // 
            // nameGroupBox
            // 
            nameGroupBox.Controls.Add(this.nameFieldLayout);
            nameGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            nameGroupBox.Location = new System.Drawing.Point(3, 3);
            nameGroupBox.Name = "nameGroupBox";
            nameGroupBox.Size = new System.Drawing.Size(452, 77);
            nameGroupBox.TabIndex = 0;
            nameGroupBox.TabStop = false;
            nameGroupBox.Text = "Name";
            // 
            // timeDateGroupBox
            // 
            timeDateGroupBox.Controls.Add(this.timeDateFieldLayout);
            timeDateGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            timeDateGroupBox.Location = new System.Drawing.Point(3, 86);
            timeDateGroupBox.Name = "timeDateGroupBox";
            timeDateGroupBox.Size = new System.Drawing.Size(452, 110);
            timeDateGroupBox.TabIndex = 1;
            timeDateGroupBox.TabStop = false;
            timeDateGroupBox.Text = "Time and Date";
            // 
            // pathIconGroupBox
            // 
            pathIconGroupBox.Controls.Add(this.pathIconFieldLayout);
            pathIconGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            pathIconGroupBox.Location = new System.Drawing.Point(3, 202);
            pathIconGroupBox.Name = "pathIconGroupBox";
            pathIconGroupBox.Size = new System.Drawing.Size(452, 79);
            pathIconGroupBox.TabIndex = 2;
            pathIconGroupBox.TabStop = false;
            pathIconGroupBox.Text = "Path and Icon";
            // 
            // timeDateFieldLayout
            // 
            this.timeDateFieldLayout.ColumnCount = 2;
            this.timeDateFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.timeDateFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.timeDateFieldLayout.Controls.Add(this.dateAddedLabel, 0, 2);
            this.timeDateFieldLayout.Controls.Add(this.totalTimeLabel, 0, 0);
            this.timeDateFieldLayout.Controls.Add(this.dateOpenedLabel, 0, 1);
            this.timeDateFieldLayout.Controls.Add(this.textBox3, 1, 0);
            this.timeDateFieldLayout.Controls.Add(this.textBox4, 1, 1);
            this.timeDateFieldLayout.Controls.Add(this.textBox5, 1, 2);
            this.timeDateFieldLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeDateFieldLayout.Location = new System.Drawing.Point(3, 16);
            this.timeDateFieldLayout.Name = "timeDateFieldLayout";
            this.timeDateFieldLayout.RowCount = 3;
            this.timeDateFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.timeDateFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.timeDateFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.timeDateFieldLayout.Size = new System.Drawing.Size(446, 91);
            this.timeDateFieldLayout.TabIndex = 0;
            // 
            // pathIconFieldLayout
            // 
            this.pathIconFieldLayout.ColumnCount = 2;
            this.pathIconFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pathIconFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pathIconFieldLayout.Controls.Add(this.label7, 0, 1);
            this.pathIconFieldLayout.Controls.Add(this.pathLabel, 0, 0);
            this.pathIconFieldLayout.Controls.Add(this.textBox6, 1, 0);
            this.pathIconFieldLayout.Controls.Add(this.textBox7, 1, 1);
            this.pathIconFieldLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathIconFieldLayout.Location = new System.Drawing.Point(3, 16);
            this.pathIconFieldLayout.Name = "pathIconFieldLayout";
            this.pathIconFieldLayout.RowCount = 2;
            this.pathIconFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pathIconFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pathIconFieldLayout.Size = new System.Drawing.Size(446, 60);
            this.pathIconFieldLayout.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(92, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(351, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Location = new System.Drawing.Point(92, 33);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(351, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.Location = new System.Drawing.Point(92, 63);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(351, 20);
            this.textBox5.TabIndex = 4;
            // 
            // textBox6
            // 
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox6.Location = new System.Drawing.Point(92, 3);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(351, 20);
            this.textBox6.TabIndex = 5;
            // 
            // textBox7
            // 
            this.textBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox7.Location = new System.Drawing.Point(92, 33);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(351, 20);
            this.textBox7.TabIndex = 6;
            // 
            // nameFieldLayout
            // 
            this.nameFieldLayout.ColumnCount = 2;
            this.nameFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.nameFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.nameFieldLayout.Controls.Add(this.procNameLabel, 0, 1);
            this.nameFieldLayout.Controls.Add(this.progNameLabel, 0, 0);
            this.nameFieldLayout.Controls.Add(this.textBox1, 1, 0);
            this.nameFieldLayout.Controls.Add(this.textBox2, 1, 1);
            this.nameFieldLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameFieldLayout.Location = new System.Drawing.Point(3, 16);
            this.nameFieldLayout.Name = "nameFieldLayout";
            this.nameFieldLayout.RowCount = 2;
            this.nameFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nameFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nameFieldLayout.Size = new System.Drawing.Size(446, 58);
            this.nameFieldLayout.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(92, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(351, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(92, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(351, 20);
            this.textBox2.TabIndex = 1;
            // 
            // progNameLabel
            // 
            this.progNameLabel.AutoSize = true;
            this.progNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progNameLabel.Location = new System.Drawing.Point(3, 0);
            this.progNameLabel.Name = "progNameLabel";
            this.progNameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.progNameLabel.Size = new System.Drawing.Size(83, 29);
            this.progNameLabel.TabIndex = 0;
            this.progNameLabel.Text = "Program Name";
            this.progNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // procNameLabel
            // 
            this.procNameLabel.AutoSize = true;
            this.procNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.procNameLabel.Location = new System.Drawing.Point(3, 29);
            this.procNameLabel.Name = "procNameLabel";
            this.procNameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.procNameLabel.Size = new System.Drawing.Size(83, 29);
            this.procNameLabel.TabIndex = 0;
            this.procNameLabel.Text = "Process Name";
            this.procNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.AutoSize = true;
            this.totalTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalTimeLabel.Location = new System.Drawing.Point(3, 0);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.totalTimeLabel.Size = new System.Drawing.Size(83, 30);
            this.totalTimeLabel.TabIndex = 0;
            this.totalTimeLabel.Text = "Time Used";
            this.totalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateOpenedLabel
            // 
            this.dateOpenedLabel.AutoSize = true;
            this.dateOpenedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateOpenedLabel.Location = new System.Drawing.Point(3, 30);
            this.dateOpenedLabel.Name = "dateOpenedLabel";
            this.dateOpenedLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.dateOpenedLabel.Size = new System.Drawing.Size(83, 30);
            this.dateOpenedLabel.TabIndex = 0;
            this.dateOpenedLabel.Text = "Last Opened";
            this.dateOpenedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateAddedLabel
            // 
            this.dateAddedLabel.AutoSize = true;
            this.dateAddedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateAddedLabel.Location = new System.Drawing.Point(3, 60);
            this.dateAddedLabel.Name = "dateAddedLabel";
            this.dateAddedLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.dateAddedLabel.Size = new System.Drawing.Size(83, 31);
            this.dateAddedLabel.TabIndex = 0;
            this.dateAddedLabel.Text = "Date Added";
            this.dateAddedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathLabel.Location = new System.Drawing.Point(3, 0);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.pathLabel.Size = new System.Drawing.Size(83, 30);
            this.pathLabel.TabIndex = 0;
            this.pathLabel.Text = "Path";
            this.pathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 30);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.label7.Size = new System.Drawing.Size(83, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "Icon";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditRecordForm
            // 
            this.AcceptButton = this.applyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(464, 325);
            this.Controls.Add(this.mainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 360);
            this.Name = "EditRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit program record";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditRecordForm_FormClosing);
            applyCancelPanel.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.fieldsTable.ResumeLayout(false);
            nameGroupBox.ResumeLayout(false);
            timeDateGroupBox.ResumeLayout(false);
            pathIconGroupBox.ResumeLayout(false);
            this.timeDateFieldLayout.ResumeLayout(false);
            this.timeDateFieldLayout.PerformLayout();
            this.pathIconFieldLayout.ResumeLayout(false);
            this.pathIconFieldLayout.PerformLayout();
            this.nameFieldLayout.ResumeLayout(false);
            this.nameFieldLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TableLayoutPanel fieldsTable;
        private System.Windows.Forms.TableLayoutPanel timeDateFieldLayout;
        private System.Windows.Forms.TableLayoutPanel pathIconFieldLayout;
        private System.Windows.Forms.TableLayoutPanel nameFieldLayout;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label procNameLabel;
        private System.Windows.Forms.Label progNameLabel;
        private System.Windows.Forms.Label dateAddedLabel;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Label dateOpenedLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label pathLabel;
    }
}