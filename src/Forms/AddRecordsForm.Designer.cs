
namespace TrakrSharp {
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
            System.Windows.Forms.TableLayoutPanel mainLayout;
            System.Windows.Forms.Panel refreshPanel;
            System.Windows.Forms.Panel applyCancelPanel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRecordsForm));
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.runningProcList = new TrakrSharp.Controls.ProcCheckedListBox();
            this.selectedProcList = new TrakrSharp.Controls.ProcCheckedListBox();
            this.searchBox = new TrakrSharp.Controls.SearchBox();
            this.dialogButtonsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            procListAndButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            addRemovePanel = new System.Windows.Forms.TableLayoutPanel();
            mainLayout = new System.Windows.Forms.TableLayoutPanel();
            refreshPanel = new System.Windows.Forms.Panel();
            applyCancelPanel = new System.Windows.Forms.Panel();
            procListAndButtonPanel.SuspendLayout();
            addRemovePanel.SuspendLayout();
            mainLayout.SuspendLayout();
            this.dialogButtonsLayout.SuspendLayout();
            refreshPanel.SuspendLayout();
            applyCancelPanel.SuspendLayout();
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
            procListAndButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 163F));
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
            // runningProcList
            // 
            this.runningProcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runningProcList.Location = new System.Drawing.Point(3, 3);
            this.runningProcList.Name = "runningProcList";
            this.runningProcList.Size = new System.Drawing.Size(200, 157);
            this.runningProcList.TabIndex = 1;
            this.runningProcList.OnItemCheck += new TrakrSharp.Controls.ProcCheckedListBox.OnItemCheckDelegate(this.runningProcList_OnItemCheck);
            // 
            // selectedProcList
            // 
            this.selectedProcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedProcList.Location = new System.Drawing.Point(254, 3);
            this.selectedProcList.Name = "selectedProcList";
            this.selectedProcList.Size = new System.Drawing.Size(201, 157);
            this.selectedProcList.TabIndex = 2;
            this.selectedProcList.OnItemCheck += new TrakrSharp.Controls.ProcCheckedListBox.OnItemCheckDelegate(this.selectedProcList_OnItemCheck);
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            mainLayout.Controls.Add(procListAndButtonPanel, 0, 0);
            mainLayout.Controls.Add(this.searchBox, 0, 1);
            mainLayout.Controls.Add(this.dialogButtonsLayout, 0, 2);
            mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayout.Location = new System.Drawing.Point(0, 0);
            mainLayout.Margin = new System.Windows.Forms.Padding(0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            mainLayout.Size = new System.Drawing.Size(464, 236);
            mainLayout.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.AutoSize = true;
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBox.Location = new System.Drawing.Point(3, 172);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(458, 21);
            this.searchBox.TabIndex = 0;
            this.searchBox.OnValidQuery += new TrakrSharp.Controls.SearchBox.OnValidQueryDelegate(this.searchBox_OnValidQuery);
            // 
            // dialogButtonsLayout
            // 
            this.dialogButtonsLayout.ColumnCount = 2;
            this.dialogButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dialogButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dialogButtonsLayout.Controls.Add(refreshPanel, 0, 0);
            this.dialogButtonsLayout.Controls.Add(applyCancelPanel, 1, 0);
            this.dialogButtonsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialogButtonsLayout.Location = new System.Drawing.Point(3, 199);
            this.dialogButtonsLayout.Name = "dialogButtonsLayout";
            this.dialogButtonsLayout.RowCount = 1;
            this.dialogButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dialogButtonsLayout.Size = new System.Drawing.Size(458, 34);
            this.dialogButtonsLayout.TabIndex = 4;
            // 
            // refreshPanel
            // 
            refreshPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            refreshPanel.Controls.Add(this.refreshButton);
            refreshPanel.Location = new System.Drawing.Point(0, 2);
            refreshPanel.Margin = new System.Windows.Forms.Padding(0);
            refreshPanel.Name = "refreshPanel";
            refreshPanel.Size = new System.Drawing.Size(81, 29);
            refreshPanel.TabIndex = 4;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.refreshButton.Location = new System.Drawing.Point(3, 3);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // applyCancelPanel
            // 
            applyCancelPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            applyCancelPanel.Controls.Add(this.cancelButton);
            applyCancelPanel.Controls.Add(this.applyButton);
            applyCancelPanel.Location = new System.Drawing.Point(300, 2);
            applyCancelPanel.Margin = new System.Windows.Forms.Padding(0);
            applyCancelPanel.Name = "applyCancelPanel";
            applyCancelPanel.Size = new System.Drawing.Size(158, 29);
            applyCancelPanel.TabIndex = 3;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(3, 3);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(80, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 236);
            this.Controls.Add(mainLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 275);
            this.Name = "AddRecordsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add programs to trakr";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddRecordsForm_FormClosing);
            procListAndButtonPanel.ResumeLayout(false);
            addRemovePanel.ResumeLayout(false);
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            this.dialogButtonsLayout.ResumeLayout(false);
            refreshPanel.ResumeLayout(false);
            applyCancelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SearchBox searchBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private Controls.ProcCheckedListBox selectedProcList;
        private System.Windows.Forms.TableLayoutPanel dialogButtonsLayout;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button refreshButton;
        private Controls.ProcCheckedListBox runningProcList;
    }
}