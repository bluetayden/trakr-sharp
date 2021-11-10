
namespace trakr_sharp {
    partial class AddRecordsForm {
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
            System.Windows.Forms.TableLayoutPanel procListAndButtonPanel;
            System.Windows.Forms.TableLayoutPanel addRemovePanel;
            System.Windows.Forms.Panel applyCancelPanel;
            System.Windows.Forms.TableLayoutPanel mainLayout;
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.runningProcList = new trakr_sharp.Controls.ProcCheckedListBox();
            this.selectedProcList = new trakr_sharp.Controls.ProcCheckedListBox();
            this.searchBox = new trakr_sharp.Controls.SearchBox();
            procListAndButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            addRemovePanel = new System.Windows.Forms.TableLayoutPanel();
            applyCancelPanel = new System.Windows.Forms.Panel();
            mainLayout = new System.Windows.Forms.TableLayoutPanel();
            procListAndButtonPanel.SuspendLayout();
            addRemovePanel.SuspendLayout();
            applyCancelPanel.SuspendLayout();
            mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // procListAndButtonPanel
            // 
            procListAndButtonPanel.ColumnCount = 3;
            procListAndButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            procListAndButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            procListAndButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            procListAndButtonPanel.Controls.Add(addRemovePanel, 1, 0);
            procListAndButtonPanel.Controls.Add(this.runningProcList, 0, 0);
            procListAndButtonPanel.Controls.Add(this.selectedProcList, 2, 0);
            procListAndButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            procListAndButtonPanel.Location = new System.Drawing.Point(3, 3);
            procListAndButtonPanel.Name = "procListAndButtonPanel";
            procListAndButtonPanel.RowCount = 1;
            procListAndButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            procListAndButtonPanel.Size = new System.Drawing.Size(458, 163);
            procListAndButtonPanel.TabIndex = 3;
            // 
            // addRemovePanel
            // 
            addRemovePanel.ColumnCount = 1;
            addRemovePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            addRemovePanel.Controls.Add(this.addButton, 0, 0);
            addRemovePanel.Controls.Add(this.removeButton, 0, 1);
            addRemovePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            addRemovePanel.Location = new System.Drawing.Point(209, 3);
            addRemovePanel.Name = "addRemovePanel";
            addRemovePanel.RowCount = 2;
            addRemovePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            addRemovePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            addRemovePanel.Size = new System.Drawing.Size(39, 157);
            addRemovePanel.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(3, 52);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(33, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = ">>";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(3, 81);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(33, 23);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "<<";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // applyCancelPanel
            // 
            applyCancelPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            applyCancelPanel.Controls.Add(this.cancelButton);
            applyCancelPanel.Controls.Add(this.applyButton);
            applyCancelPanel.Location = new System.Drawing.Point(306, 196);
            applyCancelPanel.Margin = new System.Windows.Forms.Padding(0);
            applyCancelPanel.Name = "applyCancelPanel";
            applyCancelPanel.Size = new System.Drawing.Size(158, 35);
            applyCancelPanel.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(3, 6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.applyButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(80, 6);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            mainLayout.Controls.Add(procListAndButtonPanel, 0, 0);
            mainLayout.Controls.Add(this.searchBox, 0, 1);
            mainLayout.Controls.Add(applyCancelPanel, 0, 2);
            mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayout.Location = new System.Drawing.Point(0, 0);
            mainLayout.Margin = new System.Windows.Forms.Padding(0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            mainLayout.Size = new System.Drawing.Size(464, 231);
            mainLayout.TabIndex = 0;
            // 
            // runningProcList
            // 
            this.runningProcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runningProcList.Location = new System.Drawing.Point(3, 3);
            this.runningProcList.Name = "runningProcList";
            this.runningProcList.Size = new System.Drawing.Size(200, 157);
            this.runningProcList.TabIndex = 1;
            this.runningProcList.OnItemCheck += new trakr_sharp.Controls.ProcCheckedListBox.OnItemCheckDelegate(this.runningProcList_OnItemCheck);
            // 
            // selectedProcList
            // 
            this.selectedProcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedProcList.Location = new System.Drawing.Point(254, 3);
            this.selectedProcList.Name = "selectedProcList";
            this.selectedProcList.Size = new System.Drawing.Size(201, 157);
            this.selectedProcList.TabIndex = 2;
            this.selectedProcList.OnItemCheck += new trakr_sharp.Controls.ProcCheckedListBox.OnItemCheckDelegate(this.selectedProcList_OnItemCheck);
            // 
            // searchBox
            // 
            this.searchBox.AutoSize = true;
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBox.Location = new System.Drawing.Point(3, 172);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(458, 21);
            this.searchBox.TabIndex = 0;
            this.searchBox.OnValidQuery += new trakr_sharp.Controls.SearchBox.OnValidQueryDelegate(this.searchBox_OnValidQuery);
            // 
            // AddRecordsForm
            // 
            this.AcceptButton = this.applyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(464, 231);
            this.Controls.Add(mainLayout);
            this.Name = "AddRecordsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add programs to trakr";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddRecordsForm_FormClosing);
            procListAndButtonPanel.ResumeLayout(false);
            addRemovePanel.ResumeLayout(false);
            applyCancelPanel.ResumeLayout(false);
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SearchBox searchBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private Controls.ProcCheckedListBox runningProcList;
        private Controls.ProcCheckedListBox selectedProcList;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
    }
}