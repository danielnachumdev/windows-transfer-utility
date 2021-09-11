
namespace Windows_Transfer_Utility
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.browserPanel = new System.Windows.Forms.Panel();
            this.createDirectoryButton = new System.Windows.Forms.Button();
            this.switchDirectoriesButton = new System.Windows.Forms.Button();
            this.folder2Panel = new System.Windows.Forms.Panel();
            this.goUpButton2 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.selectFolderButton2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.folder1Panel = new System.Windows.Forms.Panel();
            this.goUpButton1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.selectFolderButton1 = new System.Windows.Forms.Button();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.mergeCheckBox = new System.Windows.Forms.CheckBox();
            this.skipEmptyDirectoriesCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteEmptyFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.backupCheckBox = new System.Windows.Forms.CheckBox();
            this.copyRadioButton = new System.Windows.Forms.RadioButton();
            this.cutRadioButton = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.cDirLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.stopWatchLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.failedLabel = new System.Windows.Forms.Label();
            this.replacedLabel = new System.Windows.Forms.Label();
            this.skippedLabel = new System.Windows.Forms.Label();
            this.copiedLabel = new System.Windows.Forms.Label();
            this.cFileLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.browserPanel.SuspendLayout();
            this.folder2Panel.SuspendLayout();
            this.folder1Panel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.progressPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // browserPanel
            // 
            this.browserPanel.Controls.Add(this.createDirectoryButton);
            this.browserPanel.Controls.Add(this.switchDirectoriesButton);
            this.browserPanel.Controls.Add(this.folder2Panel);
            this.browserPanel.Controls.Add(this.folder1Panel);
            this.browserPanel.Location = new System.Drawing.Point(12, 12);
            this.browserPanel.Name = "browserPanel";
            this.browserPanel.Size = new System.Drawing.Size(1400, 979);
            this.browserPanel.TabIndex = 0;
            // 
            // createDirectoryButton
            // 
            this.createDirectoryButton.Location = new System.Drawing.Point(504, 912);
            this.createDirectoryButton.Name = "createDirectoryButton";
            this.createDirectoryButton.Size = new System.Drawing.Size(307, 53);
            this.createDirectoryButton.TabIndex = 9;
            this.createDirectoryButton.Text = "Create a directory like this ";
            this.createDirectoryButton.UseVisualStyleBackColor = true;
            this.createDirectoryButton.Click += new System.EventHandler(this.createDirectoryButton_Click);
            // 
            // switchDirectoriesButton
            // 
            this.switchDirectoriesButton.Location = new System.Drawing.Point(596, 853);
            this.switchDirectoriesButton.Name = "switchDirectoriesButton";
            this.switchDirectoriesButton.Size = new System.Drawing.Size(112, 34);
            this.switchDirectoriesButton.TabIndex = 8;
            this.switchDirectoriesButton.Text = "Switch";
            this.switchDirectoriesButton.UseVisualStyleBackColor = true;
            this.switchDirectoriesButton.Click += new System.EventHandler(this.switchDirectoriesButton_Click);
            // 
            // folder2Panel
            // 
            this.folder2Panel.Controls.Add(this.goUpButton2);
            this.folder2Panel.Controls.Add(this.richTextBox2);
            this.folder2Panel.Controls.Add(this.selectFolderButton2);
            this.folder2Panel.Controls.Add(this.textBox2);
            this.folder2Panel.Location = new System.Drawing.Point(700, 3);
            this.folder2Panel.Name = "folder2Panel";
            this.folder2Panel.Padding = new System.Windows.Forms.Padding(10);
            this.folder2Panel.Size = new System.Drawing.Size(700, 816);
            this.folder2Panel.TabIndex = 7;
            // 
            // goUpButton2
            // 
            this.goUpButton2.Location = new System.Drawing.Point(193, 36);
            this.goUpButton2.Name = "goUpButton2";
            this.goUpButton2.Size = new System.Drawing.Size(112, 34);
            this.goUpButton2.TabIndex = 6;
            this.goUpButton2.Text = "Go Up";
            this.goUpButton2.UseVisualStyleBackColor = true;
            this.goUpButton2.Click += new System.EventHandler(this.goUpButtons_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(13, 112);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(674, 652);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // selectFolderButton2
            // 
            this.selectFolderButton2.Location = new System.Drawing.Point(13, 13);
            this.selectFolderButton2.Name = "selectFolderButton2";
            this.selectFolderButton2.Size = new System.Drawing.Size(174, 56);
            this.selectFolderButton2.TabIndex = 1;
            this.selectFolderButton2.Text = "Select Folder";
            this.selectFolderButton2.UseVisualStyleBackColor = true;
            this.selectFolderButton2.Click += new System.EventHandler(this.selectFolderButtons_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(678, 31);
            this.textBox2.TabIndex = 3;
            // 
            // folder1Panel
            // 
            this.folder1Panel.Controls.Add(this.goUpButton1);
            this.folder1Panel.Controls.Add(this.richTextBox1);
            this.folder1Panel.Controls.Add(this.textBox1);
            this.folder1Panel.Controls.Add(this.selectFolderButton1);
            this.folder1Panel.Location = new System.Drawing.Point(0, 3);
            this.folder1Panel.Name = "folder1Panel";
            this.folder1Panel.Padding = new System.Windows.Forms.Padding(10);
            this.folder1Panel.Size = new System.Drawing.Size(700, 816);
            this.folder1Panel.TabIndex = 6;
            // 
            // goUpButton1
            // 
            this.goUpButton1.Location = new System.Drawing.Point(193, 36);
            this.goUpButton1.Name = "goUpButton1";
            this.goUpButton1.Size = new System.Drawing.Size(112, 34);
            this.goUpButton1.TabIndex = 5;
            this.goUpButton1.Text = "Go Up";
            this.goUpButton1.UseVisualStyleBackColor = true;
            this.goUpButton1.Click += new System.EventHandler(this.goUpButtons_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 112);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(678, 643);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(674, 31);
            this.textBox1.TabIndex = 2;
            // 
            // selectFolderButton1
            // 
            this.selectFolderButton1.Location = new System.Drawing.Point(13, 13);
            this.selectFolderButton1.Name = "selectFolderButton1";
            this.selectFolderButton1.Size = new System.Drawing.Size(174, 56);
            this.selectFolderButton1.TabIndex = 0;
            this.selectFolderButton1.Text = "Select Folder";
            this.selectFolderButton1.UseVisualStyleBackColor = true;
            this.selectFolderButton1.Click += new System.EventHandler(this.selectFolderButtons_Click);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.mergeCheckBox);
            this.optionsPanel.Controls.Add(this.skipEmptyDirectoriesCheckBox);
            this.optionsPanel.Controls.Add(this.label1);
            this.optionsPanel.Controls.Add(this.deleteEmptyFoldersCheckBox);
            this.optionsPanel.Controls.Add(this.backupCheckBox);
            this.optionsPanel.Controls.Add(this.copyRadioButton);
            this.optionsPanel.Controls.Add(this.cutRadioButton);
            this.optionsPanel.Location = new System.Drawing.Point(3, 3);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Padding = new System.Windows.Forms.Padding(10);
            this.optionsPanel.Size = new System.Drawing.Size(514, 166);
            this.optionsPanel.TabIndex = 1;
            // 
            // mergeCheckBox
            // 
            this.mergeCheckBox.AutoSize = true;
            this.mergeCheckBox.Location = new System.Drawing.Point(201, 108);
            this.mergeCheckBox.Name = "mergeCheckBox";
            this.mergeCheckBox.Size = new System.Drawing.Size(244, 29);
            this.mergeCheckBox.TabIndex = 8;
            this.mergeCheckBox.Text = "Merge Similar Directories?";
            this.mergeCheckBox.UseVisualStyleBackColor = true;
            this.mergeCheckBox.CheckedChanged += new System.EventHandler(this.mergeCheckBox_CheckedChanged);
            // 
            // skipEmptyDirectoriesCheckBox
            // 
            this.skipEmptyDirectoriesCheckBox.AutoSize = true;
            this.skipEmptyDirectoriesCheckBox.Location = new System.Drawing.Point(201, 82);
            this.skipEmptyDirectoriesCheckBox.Name = "skipEmptyDirectoriesCheckBox";
            this.skipEmptyDirectoriesCheckBox.Size = new System.Drawing.Size(225, 29);
            this.skipEmptyDirectoriesCheckBox.TabIndex = 7;
            this.skipEmptyDirectoriesCheckBox.Text = "Skip Empty Directories?";
            this.skipEmptyDirectoriesCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "OPTIONS";
            // 
            // deleteEmptyFoldersCheckBox
            // 
            this.deleteEmptyFoldersCheckBox.AutoSize = true;
            this.deleteEmptyFoldersCheckBox.Location = new System.Drawing.Point(201, 56);
            this.deleteEmptyFoldersCheckBox.Name = "deleteEmptyFoldersCheckBox";
            this.deleteEmptyFoldersCheckBox.Size = new System.Drawing.Size(215, 29);
            this.deleteEmptyFoldersCheckBox.TabIndex = 3;
            this.deleteEmptyFoldersCheckBox.Text = "Delete Empty Folders?";
            this.deleteEmptyFoldersCheckBox.UseVisualStyleBackColor = true;
            // 
            // backupCheckBox
            // 
            this.backupCheckBox.AutoSize = true;
            this.backupCheckBox.Location = new System.Drawing.Point(201, 28);
            this.backupCheckBox.Name = "backupCheckBox";
            this.backupCheckBox.Size = new System.Drawing.Size(284, 29);
            this.backupCheckBox.TabIndex = 2;
            this.backupCheckBox.Text = "when replacing, create backup?";
            this.backupCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyRadioButton
            // 
            this.copyRadioButton.AutoSize = true;
            this.copyRadioButton.Checked = true;
            this.copyRadioButton.Location = new System.Drawing.Point(13, 51);
            this.copyRadioButton.Name = "copyRadioButton";
            this.copyRadioButton.Size = new System.Drawing.Size(79, 29);
            this.copyRadioButton.TabIndex = 1;
            this.copyRadioButton.TabStop = true;
            this.copyRadioButton.Text = "Copy";
            this.copyRadioButton.UseVisualStyleBackColor = true;
            this.copyRadioButton.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // cutRadioButton
            // 
            this.cutRadioButton.AutoSize = true;
            this.cutRadioButton.Location = new System.Drawing.Point(13, 86);
            this.cutRadioButton.Name = "cutRadioButton";
            this.cutRadioButton.Size = new System.Drawing.Size(64, 29);
            this.cutRadioButton.TabIndex = 0;
            this.cutRadioButton.Text = "Cut";
            this.cutRadioButton.UseVisualStyleBackColor = true;
            this.cutRadioButton.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startButton.Location = new System.Drawing.Point(16, 175);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(488, 99);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.cDirLabel);
            this.progressPanel.Controls.Add(this.infoLabel);
            this.progressPanel.Controls.Add(this.stopWatchLabel);
            this.progressPanel.Controls.Add(this.statusLabel);
            this.progressPanel.Controls.Add(this.failedLabel);
            this.progressPanel.Controls.Add(this.replacedLabel);
            this.progressPanel.Controls.Add(this.skippedLabel);
            this.progressPanel.Controls.Add(this.copiedLabel);
            this.progressPanel.Controls.Add(this.cFileLabel);
            this.progressPanel.Controls.Add(this.progressLabel);
            this.progressPanel.Controls.Add(this.progressBar1);
            this.progressPanel.Location = new System.Drawing.Point(6, 280);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Padding = new System.Windows.Forms.Padding(10);
            this.progressPanel.Size = new System.Drawing.Size(514, 686);
            this.progressPanel.TabIndex = 7;
            // 
            // cDirLabel
            // 
            this.cDirLabel.AutoSize = true;
            this.cDirLabel.Location = new System.Drawing.Point(129, 107);
            this.cDirLabel.Name = "cDirLabel";
            this.cDirLabel.Size = new System.Drawing.Size(151, 25);
            this.cDirLabel.TabIndex = 18;
            this.cDirLabel.Text = "Current Directory:";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(13, 107);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(85, 25);
            this.infoLabel.TabIndex = 17;
            this.infoLabel.Text = "info label";
            // 
            // stopWatchLabel
            // 
            this.stopWatchLabel.AutoSize = true;
            this.stopWatchLabel.Location = new System.Drawing.Point(81, 453);
            this.stopWatchLabel.Name = "stopWatchLabel";
            this.stopWatchLabel.Size = new System.Drawing.Size(125, 25);
            this.stopWatchLabel.TabIndex = 15;
            this.stopWatchLabel.Text = "Elapsed Time: ";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.Location = new System.Drawing.Point(13, 596);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(105, 45);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "label2";
            // 
            // failedLabel
            // 
            this.failedLabel.AutoSize = true;
            this.failedLabel.Location = new System.Drawing.Point(18, 304);
            this.failedLabel.Name = "failedLabel";
            this.failedLabel.Size = new System.Drawing.Size(61, 25);
            this.failedLabel.TabIndex = 14;
            this.failedLabel.Text = "Failed:";
            // 
            // replacedLabel
            // 
            this.replacedLabel.AutoSize = true;
            this.replacedLabel.Location = new System.Drawing.Point(18, 279);
            this.replacedLabel.Name = "replacedLabel";
            this.replacedLabel.Size = new System.Drawing.Size(87, 25);
            this.replacedLabel.TabIndex = 13;
            this.replacedLabel.Text = "Replaced:";
            // 
            // skippedLabel
            // 
            this.skippedLabel.AutoSize = true;
            this.skippedLabel.Location = new System.Drawing.Point(18, 254);
            this.skippedLabel.Name = "skippedLabel";
            this.skippedLabel.Size = new System.Drawing.Size(86, 25);
            this.skippedLabel.TabIndex = 12;
            this.skippedLabel.Text = "Skipped: ";
            // 
            // copiedLabel
            // 
            this.copiedLabel.AutoSize = true;
            this.copiedLabel.Location = new System.Drawing.Point(18, 229);
            this.copiedLabel.Name = "copiedLabel";
            this.copiedLabel.Size = new System.Drawing.Size(78, 25);
            this.copiedLabel.TabIndex = 8;
            this.copiedLabel.Text = "Copied: ";
            // 
            // cFileLabel
            // 
            this.cFileLabel.AutoSize = true;
            this.cFileLabel.Location = new System.Drawing.Point(129, 132);
            this.cFileLabel.Name = "cFileLabel";
            this.cFileLabel.Size = new System.Drawing.Size(110, 25);
            this.cFileLabel.TabIndex = 11;
            this.cFileLabel.Text = "Current File: ";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(13, 82);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(49, 25);
            this.progressLabel.TabIndex = 10;
            this.progressLabel.Text = "0 / 0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 13);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(488, 66);
            this.progressBar1.TabIndex = 9;
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.progressPanel);
            this.actionPanel.Controls.Add(this.optionsPanel);
            this.actionPanel.Controls.Add(this.startButton);
            this.actionPanel.Enabled = false;
            this.actionPanel.Location = new System.Drawing.Point(1418, 12);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(520, 979);
            this.actionPanel.TabIndex = 8;
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 1;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(0, 36);
            this.linkLabel1.Location = new System.Drawing.Point(1648, 981);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(301, 25);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "All rights reserved to Daniel Nachum";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1950, 1003);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.actionPanel);
            this.Controls.Add(this.browserPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Transfer Utility";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.browserPanel.ResumeLayout(false);
            this.folder2Panel.ResumeLayout(false);
            this.folder2Panel.PerformLayout();
            this.folder1Panel.ResumeLayout(false);
            this.folder1Panel.PerformLayout();
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel browserPanel;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox deleteEmptyFoldersCheckBox;
        private System.Windows.Forms.CheckBox backupCheckBox;
        private System.Windows.Forms.RadioButton copyRadioButton;
        private System.Windows.Forms.RadioButton cutRadioButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button selectFolderButton1;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button selectFolderButton2;
        private System.Windows.Forms.Panel folder1Panel;
        private System.Windows.Forms.Panel folder2Panel;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label cFileLabel;
        private System.Windows.Forms.Label failedLabel;
        private System.Windows.Forms.Label replacedLabel;
        private System.Windows.Forms.Label skippedLabel;
        private System.Windows.Forms.Label copiedLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox skipEmptyDirectoriesCheckBox;
        private System.Windows.Forms.CheckBox mergeCheckBox;
        private System.Windows.Forms.Label stopWatchLabel;
        private System.Windows.Forms.Button createDirectoryButton;
        private System.Windows.Forms.Button switchDirectoriesButton;
        private System.Windows.Forms.Button goUpButton2;
        private System.Windows.Forms.Button goUpButton1;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label cDirLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

