
namespace trakr_sharp {
    partial class SettingsForm {
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
            this.applyCancelPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.optionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.systemGroupBox = new System.Windows.Forms.GroupBox();
            this.systemTable = new System.Windows.Forms.TableLayoutPanel();
            this.startupBehaviourLabel = new System.Windows.Forms.Label();
            this.closeBehaviourLabel = new System.Windows.Forms.Label();
            this.startupBehaviourCheckbox = new System.Windows.Forms.CheckBox();
            this.closeBehaviourComboBox = new System.Windows.Forms.ComboBox();
            this.displayGroupBox = new System.Windows.Forms.GroupBox();
            this.displayTable = new System.Windows.Forms.TableLayoutPanel();
            this.showUtilityColsCheckbox = new System.Windows.Forms.CheckBox();
            this.showUtilityColsLabel = new System.Windows.Forms.Label();
            this.applyCancelPanel.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.optionLayout.SuspendLayout();
            this.systemGroupBox.SuspendLayout();
            this.systemTable.SuspendLayout();
            this.displayGroupBox.SuspendLayout();
            this.displayTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyCancelPanel
            // 
            this.applyCancelPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.applyCancelPanel.Controls.Add(this.cancelButton);
            this.applyCancelPanel.Controls.Add(this.applyButton);
            this.applyCancelPanel.Location = new System.Drawing.Point(226, 159);
            this.applyCancelPanel.Margin = new System.Windows.Forms.Padding(0);
            this.applyCancelPanel.Name = "applyCancelPanel";
            this.applyCancelPanel.Size = new System.Drawing.Size(158, 29);
            this.applyCancelPanel.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(3, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(80, 3);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.applyCancelPanel, 0, 1);
            this.mainLayout.Controls.Add(this.optionLayout, 0, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mainLayout.Size = new System.Drawing.Size(384, 191);
            this.mainLayout.TabIndex = 0;
            // 
            // optionLayout
            // 
            this.optionLayout.ColumnCount = 1;
            this.optionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optionLayout.Controls.Add(this.systemGroupBox, 0, 0);
            this.optionLayout.Controls.Add(this.displayGroupBox, 0, 1);
            this.optionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionLayout.Location = new System.Drawing.Point(3, 3);
            this.optionLayout.Name = "optionLayout";
            this.optionLayout.RowCount = 2;
            this.optionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.optionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.optionLayout.Size = new System.Drawing.Size(378, 150);
            this.optionLayout.TabIndex = 5;
            // 
            // systemGroupBox
            // 
            this.systemGroupBox.Controls.Add(this.systemTable);
            this.systemGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemGroupBox.Location = new System.Drawing.Point(3, 3);
            this.systemGroupBox.Name = "systemGroupBox";
            this.systemGroupBox.Size = new System.Drawing.Size(372, 84);
            this.systemGroupBox.TabIndex = 0;
            this.systemGroupBox.TabStop = false;
            this.systemGroupBox.Text = "System";
            // 
            // systemTable
            // 
            this.systemTable.ColumnCount = 2;
            this.systemTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.systemTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.systemTable.Controls.Add(this.startupBehaviourLabel, 0, 1);
            this.systemTable.Controls.Add(this.closeBehaviourLabel, 0, 0);
            this.systemTable.Controls.Add(this.startupBehaviourCheckbox, 1, 1);
            this.systemTable.Controls.Add(this.closeBehaviourComboBox, 1, 0);
            this.systemTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemTable.Location = new System.Drawing.Point(3, 16);
            this.systemTable.Name = "systemTable";
            this.systemTable.RowCount = 2;
            this.systemTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.systemTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.systemTable.Size = new System.Drawing.Size(366, 65);
            this.systemTable.TabIndex = 0;
            // 
            // startupBehaviourLabel
            // 
            this.startupBehaviourLabel.AutoSize = true;
            this.startupBehaviourLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startupBehaviourLabel.Location = new System.Drawing.Point(3, 32);
            this.startupBehaviourLabel.Name = "startupBehaviourLabel";
            this.startupBehaviourLabel.Size = new System.Drawing.Size(177, 33);
            this.startupBehaviourLabel.TabIndex = 0;
            this.startupBehaviourLabel.Text = "Run trakr on system startup";
            this.startupBehaviourLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // closeBehaviourLabel
            // 
            this.closeBehaviourLabel.AutoSize = true;
            this.closeBehaviourLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closeBehaviourLabel.Location = new System.Drawing.Point(3, 0);
            this.closeBehaviourLabel.Name = "closeBehaviourLabel";
            this.closeBehaviourLabel.Size = new System.Drawing.Size(177, 32);
            this.closeBehaviourLabel.TabIndex = 1;
            this.closeBehaviourLabel.Text = "Close button behaviour";
            this.closeBehaviourLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startupBehaviourCheckbox
            // 
            this.startupBehaviourCheckbox.AutoSize = true;
            this.startupBehaviourCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startupBehaviourCheckbox.Location = new System.Drawing.Point(187, 35);
            this.startupBehaviourCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.startupBehaviourCheckbox.Name = "startupBehaviourCheckbox";
            this.startupBehaviourCheckbox.Size = new System.Drawing.Size(176, 27);
            this.startupBehaviourCheckbox.TabIndex = 3;
            this.startupBehaviourCheckbox.UseVisualStyleBackColor = true;
            // 
            // closeBehaviourComboBox
            // 
            this.closeBehaviourComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closeBehaviourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.closeBehaviourComboBox.FormattingEnabled = true;
            this.closeBehaviourComboBox.Items.AddRange(new object[] {
            "Minimize to task tray",
            "Close trakr"});
            this.closeBehaviourComboBox.Location = new System.Drawing.Point(186, 3);
            this.closeBehaviourComboBox.Name = "closeBehaviourComboBox";
            this.closeBehaviourComboBox.Size = new System.Drawing.Size(177, 21);
            this.closeBehaviourComboBox.TabIndex = 2;
            // 
            // displayGroupBox
            // 
            this.displayGroupBox.Controls.Add(this.displayTable);
            this.displayGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayGroupBox.Location = new System.Drawing.Point(3, 93);
            this.displayGroupBox.Name = "displayGroupBox";
            this.displayGroupBox.Size = new System.Drawing.Size(372, 54);
            this.displayGroupBox.TabIndex = 1;
            this.displayGroupBox.TabStop = false;
            this.displayGroupBox.Text = "Tracking Display";
            // 
            // displayTable
            // 
            this.displayTable.ColumnCount = 2;
            this.displayTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayTable.Controls.Add(this.showUtilityColsCheckbox, 1, 0);
            this.displayTable.Controls.Add(this.showUtilityColsLabel, 0, 0);
            this.displayTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayTable.Location = new System.Drawing.Point(3, 16);
            this.displayTable.Name = "displayTable";
            this.displayTable.RowCount = 1;
            this.displayTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.displayTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.displayTable.Size = new System.Drawing.Size(366, 35);
            this.displayTable.TabIndex = 0;
            // 
            // showUtilityColsCheckbox
            // 
            this.showUtilityColsCheckbox.AutoSize = true;
            this.showUtilityColsCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showUtilityColsCheckbox.Location = new System.Drawing.Point(187, 3);
            this.showUtilityColsCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.showUtilityColsCheckbox.Name = "showUtilityColsCheckbox";
            this.showUtilityColsCheckbox.Size = new System.Drawing.Size(176, 29);
            this.showUtilityColsCheckbox.TabIndex = 1;
            this.showUtilityColsCheckbox.UseVisualStyleBackColor = true;
            // 
            // showUtilityColsLabel
            // 
            this.showUtilityColsLabel.AutoSize = true;
            this.showUtilityColsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showUtilityColsLabel.Location = new System.Drawing.Point(3, 0);
            this.showUtilityColsLabel.Name = "showUtilityColsLabel";
            this.showUtilityColsLabel.Size = new System.Drawing.Size(177, 35);
            this.showUtilityColsLabel.TabIndex = 0;
            this.showUtilityColsLabel.Text = "Show utility columns";
            this.showUtilityColsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 191);
            this.Controls.Add(this.mainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 230);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.applyCancelPanel.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.optionLayout.ResumeLayout(false);
            this.systemGroupBox.ResumeLayout(false);
            this.systemTable.ResumeLayout(false);
            this.systemTable.PerformLayout();
            this.displayGroupBox.ResumeLayout(false);
            this.displayTable.ResumeLayout(false);
            this.displayTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TableLayoutPanel optionLayout;
        private System.Windows.Forms.GroupBox systemGroupBox;
        private System.Windows.Forms.GroupBox displayGroupBox;
        private System.Windows.Forms.TableLayoutPanel systemTable;
        private System.Windows.Forms.Label startupBehaviourLabel;
        private System.Windows.Forms.Label closeBehaviourLabel;
        private System.Windows.Forms.ComboBox closeBehaviourComboBox;
        private System.Windows.Forms.CheckBox startupBehaviourCheckbox;
        private System.Windows.Forms.TableLayoutPanel displayTable;
        private System.Windows.Forms.Label showUtilityColsLabel;
        private System.Windows.Forms.CheckBox showUtilityColsCheckbox;
        private System.Windows.Forms.Panel applyCancelPanel;
    }
}