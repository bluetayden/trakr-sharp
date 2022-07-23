
namespace TrakrSharp {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRecordForm));
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameFieldLayout = new System.Windows.Forms.TableLayoutPanel();
            this.procNameLabel = new System.Windows.Forms.Label();
            this.progNameLabel = new System.Windows.Forms.Label();
            this.progNameTextBox = new System.Windows.Forms.TextBox();
            this.procNameTextBox = new System.Windows.Forms.TextBox();
            this.timeDateFieldLayout = new System.Windows.Forms.TableLayoutPanel();
            this.dateAddedLabel = new System.Windows.Forms.Label();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.dateOpenedLabel = new System.Windows.Forms.Label();
            this.totalTimeCounterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.hoursCounter = new System.Windows.Forms.NumericUpDown();
            this.minsCounter = new System.Windows.Forms.NumericUpDown();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.minsLabel = new System.Windows.Forms.Label();
            this.dateOpenedTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateAddedTimePicker = new System.Windows.Forms.DateTimePicker();
            this.pathIconFieldLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.pathBrowseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.procPathTextBox = new System.Windows.Forms.TextBox();
            this.detectButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.procIconBox = new System.Windows.Forms.PictureBox();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.fieldsTable = new System.Windows.Forms.TableLayoutPanel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            applyCancelPanel = new System.Windows.Forms.Panel();
            nameGroupBox = new System.Windows.Forms.GroupBox();
            timeDateGroupBox = new System.Windows.Forms.GroupBox();
            pathIconGroupBox = new System.Windows.Forms.GroupBox();
            applyCancelPanel.SuspendLayout();
            nameGroupBox.SuspendLayout();
            this.nameFieldLayout.SuspendLayout();
            timeDateGroupBox.SuspendLayout();
            this.timeDateFieldLayout.SuspendLayout();
            this.totalTimeCounterLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minsCounter)).BeginInit();
            pathIconGroupBox.SuspendLayout();
            this.pathIconFieldLayout.SuspendLayout();
            this.pathBrowseLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.procIconBox)).BeginInit();
            this.mainLayout.SuspendLayout();
            this.fieldsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyCancelPanel
            // 
            applyCancelPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            applyCancelPanel.Controls.Add(this.applyButton);
            applyCancelPanel.Controls.Add(this.cancelButton);
            applyCancelPanel.Location = new System.Drawing.Point(300, 286);
            applyCancelPanel.Margin = new System.Windows.Forms.Padding(0);
            applyCancelPanel.Name = "applyCancelPanel";
            applyCancelPanel.Size = new System.Drawing.Size(164, 35);
            applyCancelPanel.TabIndex = 4;
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(0, 6);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 9;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(77, 6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nameGroupBox
            // 
            nameGroupBox.Controls.Add(this.nameFieldLayout);
            nameGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            nameGroupBox.Location = new System.Drawing.Point(3, 3);
            nameGroupBox.Name = "nameGroupBox";
            nameGroupBox.Size = new System.Drawing.Size(452, 76);
            nameGroupBox.TabIndex = 0;
            nameGroupBox.TabStop = false;
            nameGroupBox.Text = "Name";
            // 
            // nameFieldLayout
            // 
            this.nameFieldLayout.ColumnCount = 2;
            this.nameFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.nameFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.nameFieldLayout.Controls.Add(this.procNameLabel, 0, 1);
            this.nameFieldLayout.Controls.Add(this.progNameLabel, 0, 0);
            this.nameFieldLayout.Controls.Add(this.progNameTextBox, 1, 0);
            this.nameFieldLayout.Controls.Add(this.procNameTextBox, 1, 1);
            this.nameFieldLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameFieldLayout.Location = new System.Drawing.Point(3, 16);
            this.nameFieldLayout.Name = "nameFieldLayout";
            this.nameFieldLayout.RowCount = 2;
            this.nameFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nameFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nameFieldLayout.Size = new System.Drawing.Size(446, 57);
            this.nameFieldLayout.TabIndex = 1;
            // 
            // procNameLabel
            // 
            this.procNameLabel.AutoSize = true;
            this.procNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.procNameLabel.Location = new System.Drawing.Point(3, 28);
            this.procNameLabel.Name = "procNameLabel";
            this.procNameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.procNameLabel.Size = new System.Drawing.Size(83, 29);
            this.procNameLabel.TabIndex = 0;
            this.procNameLabel.Text = "Process Name";
            this.procNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progNameLabel
            // 
            this.progNameLabel.AutoSize = true;
            this.progNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progNameLabel.Location = new System.Drawing.Point(3, 0);
            this.progNameLabel.Name = "progNameLabel";
            this.progNameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.progNameLabel.Size = new System.Drawing.Size(83, 28);
            this.progNameLabel.TabIndex = 0;
            this.progNameLabel.Text = "Program Name";
            this.progNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progNameTextBox
            // 
            this.progNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progNameTextBox.Location = new System.Drawing.Point(92, 3);
            this.progNameTextBox.Name = "progNameTextBox";
            this.progNameTextBox.Size = new System.Drawing.Size(351, 20);
            this.progNameTextBox.TabIndex = 0;
            // 
            // procNameTextBox
            // 
            this.procNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.procNameTextBox.Enabled = false;
            this.procNameTextBox.Location = new System.Drawing.Point(92, 31);
            this.procNameTextBox.Name = "procNameTextBox";
            this.procNameTextBox.ReadOnly = true;
            this.procNameTextBox.Size = new System.Drawing.Size(351, 20);
            this.procNameTextBox.TabIndex = 1;
            // 
            // timeDateGroupBox
            // 
            timeDateGroupBox.Controls.Add(this.timeDateFieldLayout);
            timeDateGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            timeDateGroupBox.Location = new System.Drawing.Point(3, 85);
            timeDateGroupBox.Name = "timeDateGroupBox";
            timeDateGroupBox.Size = new System.Drawing.Size(452, 108);
            timeDateGroupBox.TabIndex = 1;
            timeDateGroupBox.TabStop = false;
            timeDateGroupBox.Text = "Time and Date";
            // 
            // timeDateFieldLayout
            // 
            this.timeDateFieldLayout.ColumnCount = 2;
            this.timeDateFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.timeDateFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.timeDateFieldLayout.Controls.Add(this.dateAddedLabel, 0, 2);
            this.timeDateFieldLayout.Controls.Add(this.totalTimeLabel, 0, 0);
            this.timeDateFieldLayout.Controls.Add(this.dateOpenedLabel, 0, 1);
            this.timeDateFieldLayout.Controls.Add(this.totalTimeCounterLayout, 1, 0);
            this.timeDateFieldLayout.Controls.Add(this.dateOpenedTimePicker, 1, 1);
            this.timeDateFieldLayout.Controls.Add(this.dateAddedTimePicker, 1, 2);
            this.timeDateFieldLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeDateFieldLayout.Location = new System.Drawing.Point(3, 16);
            this.timeDateFieldLayout.Name = "timeDateFieldLayout";
            this.timeDateFieldLayout.RowCount = 3;
            this.timeDateFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.timeDateFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.timeDateFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.timeDateFieldLayout.Size = new System.Drawing.Size(446, 89);
            this.timeDateFieldLayout.TabIndex = 0;
            // 
            // dateAddedLabel
            // 
            this.dateAddedLabel.AutoSize = true;
            this.dateAddedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateAddedLabel.Location = new System.Drawing.Point(3, 58);
            this.dateAddedLabel.Name = "dateAddedLabel";
            this.dateAddedLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.dateAddedLabel.Size = new System.Drawing.Size(83, 31);
            this.dateAddedLabel.TabIndex = 0;
            this.dateAddedLabel.Text = "Date Added";
            this.dateAddedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.AutoSize = true;
            this.totalTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalTimeLabel.Location = new System.Drawing.Point(3, 0);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.totalTimeLabel.Size = new System.Drawing.Size(83, 29);
            this.totalTimeLabel.TabIndex = 0;
            this.totalTimeLabel.Text = "Time Used";
            this.totalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateOpenedLabel
            // 
            this.dateOpenedLabel.AutoSize = true;
            this.dateOpenedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateOpenedLabel.Location = new System.Drawing.Point(3, 29);
            this.dateOpenedLabel.Name = "dateOpenedLabel";
            this.dateOpenedLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.dateOpenedLabel.Size = new System.Drawing.Size(83, 29);
            this.dateOpenedLabel.TabIndex = 0;
            this.dateOpenedLabel.Text = "Last Opened";
            this.dateOpenedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalTimeCounterLayout
            // 
            this.totalTimeCounterLayout.ColumnCount = 4;
            this.totalTimeCounterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.64227F));
            this.totalTimeCounterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.35773F));
            this.totalTimeCounterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.64226F));
            this.totalTimeCounterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.35773F));
            this.totalTimeCounterLayout.Controls.Add(this.hoursCounter, 0, 0);
            this.totalTimeCounterLayout.Controls.Add(this.minsCounter, 2, 0);
            this.totalTimeCounterLayout.Controls.Add(this.hoursLabel, 1, 0);
            this.totalTimeCounterLayout.Controls.Add(this.minsLabel, 3, 0);
            this.totalTimeCounterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalTimeCounterLayout.Location = new System.Drawing.Point(92, 3);
            this.totalTimeCounterLayout.Name = "totalTimeCounterLayout";
            this.totalTimeCounterLayout.RowCount = 1;
            this.totalTimeCounterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.totalTimeCounterLayout.Size = new System.Drawing.Size(351, 23);
            this.totalTimeCounterLayout.TabIndex = 5;
            // 
            // hoursCounter
            // 
            this.hoursCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hoursCounter.Location = new System.Drawing.Point(3, 3);
            this.hoursCounter.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.hoursCounter.Name = "hoursCounter";
            this.hoursCounter.Size = new System.Drawing.Size(129, 20);
            this.hoursCounter.TabIndex = 3;
            // 
            // minsCounter
            // 
            this.minsCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minsCounter.Location = new System.Drawing.Point(177, 3);
            this.minsCounter.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minsCounter.Name = "minsCounter";
            this.minsCounter.Size = new System.Drawing.Size(129, 20);
            this.minsCounter.TabIndex = 3;
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hoursLabel.Location = new System.Drawing.Point(138, 0);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(33, 23);
            this.hoursLabel.TabIndex = 2;
            this.hoursLabel.Text = "hours";
            this.hoursLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minsLabel
            // 
            this.minsLabel.AutoSize = true;
            this.minsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minsLabel.Location = new System.Drawing.Point(312, 0);
            this.minsLabel.Name = "minsLabel";
            this.minsLabel.Size = new System.Drawing.Size(36, 23);
            this.minsLabel.TabIndex = 3;
            this.minsLabel.Text = "mins";
            this.minsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateOpenedTimePicker
            // 
            this.dateOpenedTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateOpenedTimePicker.Location = new System.Drawing.Point(92, 32);
            this.dateOpenedTimePicker.Name = "dateOpenedTimePicker";
            this.dateOpenedTimePicker.Size = new System.Drawing.Size(351, 20);
            this.dateOpenedTimePicker.TabIndex = 6;
            // 
            // dateAddedTimePicker
            // 
            this.dateAddedTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateAddedTimePicker.Location = new System.Drawing.Point(92, 61);
            this.dateAddedTimePicker.Name = "dateAddedTimePicker";
            this.dateAddedTimePicker.Size = new System.Drawing.Size(351, 20);
            this.dateAddedTimePicker.TabIndex = 7;
            // 
            // pathIconGroupBox
            // 
            pathIconGroupBox.Controls.Add(this.pathIconFieldLayout);
            pathIconGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            pathIconGroupBox.Location = new System.Drawing.Point(3, 199);
            pathIconGroupBox.Name = "pathIconGroupBox";
            pathIconGroupBox.Size = new System.Drawing.Size(452, 78);
            pathIconGroupBox.TabIndex = 2;
            pathIconGroupBox.TabStop = false;
            pathIconGroupBox.Text = "Path and Icon";
            // 
            // pathIconFieldLayout
            // 
            this.pathIconFieldLayout.ColumnCount = 2;
            this.pathIconFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pathIconFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pathIconFieldLayout.Controls.Add(this.label7, 0, 1);
            this.pathIconFieldLayout.Controls.Add(this.pathLabel, 0, 0);
            this.pathIconFieldLayout.Controls.Add(this.pathBrowseLayout, 1, 0);
            this.pathIconFieldLayout.Controls.Add(this.procIconBox, 1, 1);
            this.pathIconFieldLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathIconFieldLayout.Location = new System.Drawing.Point(3, 16);
            this.pathIconFieldLayout.Name = "pathIconFieldLayout";
            this.pathIconFieldLayout.RowCount = 2;
            this.pathIconFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pathIconFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pathIconFieldLayout.Size = new System.Drawing.Size(446, 59);
            this.pathIconFieldLayout.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 29);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.label7.Size = new System.Drawing.Size(83, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "Icon";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathLabel.Location = new System.Drawing.Point(3, 0);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.pathLabel.Size = new System.Drawing.Size(83, 29);
            this.pathLabel.TabIndex = 0;
            this.pathLabel.Text = "Path";
            this.pathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pathBrowseLayout
            // 
            this.pathBrowseLayout.ColumnCount = 3;
            this.pathBrowseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pathBrowseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pathBrowseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pathBrowseLayout.Controls.Add(this.procPathTextBox, 0, 0);
            this.pathBrowseLayout.Controls.Add(this.detectButton, 2, 0);
            this.pathBrowseLayout.Controls.Add(this.browseButton, 1, 0);
            this.pathBrowseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathBrowseLayout.Location = new System.Drawing.Point(89, 0);
            this.pathBrowseLayout.Margin = new System.Windows.Forms.Padding(0);
            this.pathBrowseLayout.Name = "pathBrowseLayout";
            this.pathBrowseLayout.RowCount = 1;
            this.pathBrowseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pathBrowseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.pathBrowseLayout.Size = new System.Drawing.Size(357, 29);
            this.pathBrowseLayout.TabIndex = 8;
            // 
            // procPathTextBox
            // 
            this.procPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.procPathTextBox.Location = new System.Drawing.Point(3, 5);
            this.procPathTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.procPathTextBox.Name = "procPathTextBox";
            this.procPathTextBox.ReadOnly = true;
            this.procPathTextBox.Size = new System.Drawing.Size(193, 20);
            this.procPathTextBox.TabIndex = 10;
            // 
            // detectButton
            // 
            this.detectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.detectButton.Location = new System.Drawing.Point(279, 3);
            this.detectButton.Margin = new System.Windows.Forms.Padding(1, 3, 3, 0);
            this.detectButton.Name = "detectButton";
            this.detectButton.Size = new System.Drawing.Size(75, 23);
            this.detectButton.TabIndex = 8;
            this.detectButton.Text = "Detect";
            this.detectButton.UseVisualStyleBackColor = true;
            this.detectButton.Click += new System.EventHandler(this.detectButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(202, 3);
            this.browseButton.Margin = new System.Windows.Forms.Padding(3, 3, 1, 0);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 9;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // procIconBox
            // 
            this.procIconBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("procIconBox.BackgroundImage")));
            this.procIconBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.procIconBox.Location = new System.Drawing.Point(92, 32);
            this.procIconBox.Name = "procIconBox";
            this.procIconBox.Size = new System.Drawing.Size(24, 24);
            this.procIconBox.TabIndex = 9;
            this.procIconBox.TabStop = false;
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
            this.mainLayout.Size = new System.Drawing.Size(464, 321);
            this.mainLayout.TabIndex = 0;
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
            this.fieldsTable.Size = new System.Drawing.Size(458, 280);
            this.fieldsTable.TabIndex = 5;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "exe";
            this.openFileDialog.Filter = "Executables|*.exe";
            this.openFileDialog.Title = "Select executable file";
            // 
            // EditRecordForm
            // 
            this.AcceptButton = this.applyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(464, 321);
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
            nameGroupBox.ResumeLayout(false);
            this.nameFieldLayout.ResumeLayout(false);
            this.nameFieldLayout.PerformLayout();
            timeDateGroupBox.ResumeLayout(false);
            this.timeDateFieldLayout.ResumeLayout(false);
            this.timeDateFieldLayout.PerformLayout();
            this.totalTimeCounterLayout.ResumeLayout(false);
            this.totalTimeCounterLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minsCounter)).EndInit();
            pathIconGroupBox.ResumeLayout(false);
            this.pathIconFieldLayout.ResumeLayout(false);
            this.pathIconFieldLayout.PerformLayout();
            this.pathBrowseLayout.ResumeLayout(false);
            this.pathBrowseLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.procIconBox)).EndInit();
            this.mainLayout.ResumeLayout(false);
            this.fieldsTable.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox progNameTextBox;
        private System.Windows.Forms.TextBox procNameTextBox;
        private System.Windows.Forms.Label procNameLabel;
        private System.Windows.Forms.Label progNameLabel;
        private System.Windows.Forms.Label dateAddedLabel;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Label dateOpenedLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.TableLayoutPanel totalTimeCounterLayout;
        private System.Windows.Forms.NumericUpDown hoursCounter;
        private System.Windows.Forms.NumericUpDown minsCounter;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.Label minsLabel;
        private System.Windows.Forms.DateTimePicker dateOpenedTimePicker;
        private System.Windows.Forms.DateTimePicker dateAddedTimePicker;
        private System.Windows.Forms.TableLayoutPanel pathBrowseLayout;
        private System.Windows.Forms.TextBox procPathTextBox;
        private System.Windows.Forms.PictureBox procIconBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button detectButton;
        private System.Windows.Forms.Button browseButton;
    }
}