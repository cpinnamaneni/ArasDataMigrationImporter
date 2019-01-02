namespace ArasDataMigrationImporter
{
    partial class TextFileToAras
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextFileToAras));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.techLogFilePath = new System.Windows.Forms.TextBox();
            this.techLogFileExploreButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.repeteFileExploreButton = new System.Windows.Forms.Button();
            this.repeatFilePath = new System.Windows.Forms.TextBox();
            this.delimiterLabel = new System.Windows.Forms.Label();
            this.delimiterField = new System.Windows.Forms.TextBox();
            this.logFileTextLabel = new System.Windows.Forms.Label();
            this.logFilePath = new System.Windows.Forms.TextBox();
            this.logFileExplore = new System.Windows.Forms.Button();
            this.inputFilelabel = new System.Windows.Forms.Label();
            this.InputFileExplore = new System.Windows.Forms.Button();
            this.InputTextFilePath = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusTextBox = new System.Windows.Forms.RichTextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.getDBListButton = new System.Windows.Forms.Button();
            this.dbLabel = new System.Windows.Forms.Label();
            this.dbList = new System.Windows.Forms.ComboBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.validateButton = new System.Windows.Forms.ToolStripButton();
            this.settingsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cadImportButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.guideButton = new System.Windows.Forms.ToolStripButton();
            this.infoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitButton = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.inputTextFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.logFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(846, 790);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(243, 18);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 56;
            this.progressBar1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Tech Log File";
            // 
            // techLogFilePath
            // 
            this.techLogFilePath.Location = new System.Drawing.Point(554, 152);
            this.techLogFilePath.Name = "techLogFilePath";
            this.techLogFilePath.Size = new System.Drawing.Size(482, 22);
            this.techLogFilePath.TabIndex = 54;
            // 
            // techLogFileExploreButton
            // 
            this.techLogFileExploreButton.Location = new System.Drawing.Point(1043, 152);
            this.techLogFileExploreButton.Name = "techLogFileExploreButton";
            this.techLogFileExploreButton.Size = new System.Drawing.Size(40, 23);
            this.techLogFileExploreButton.TabIndex = 53;
            this.techLogFileExploreButton.Text = "...";
            this.techLogFileExploreButton.UseVisualStyleBackColor = true;
            this.techLogFileExploreButton.Click += new System.EventHandler(this.techLogFileExploreButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 52;
            this.label2.Text = "Repeat File";
            // 
            // repeteFileExploreButton
            // 
            this.repeteFileExploreButton.Location = new System.Drawing.Point(1043, 111);
            this.repeteFileExploreButton.Name = "repeteFileExploreButton";
            this.repeteFileExploreButton.Size = new System.Drawing.Size(40, 23);
            this.repeteFileExploreButton.TabIndex = 51;
            this.repeteFileExploreButton.Text = "...";
            this.repeteFileExploreButton.UseVisualStyleBackColor = true;
            this.repeteFileExploreButton.Click += new System.EventHandler(this.repeteFileExploreButton_Click);
            // 
            // repeatFilePath
            // 
            this.repeatFilePath.Location = new System.Drawing.Point(554, 113);
            this.repeatFilePath.Name = "repeatFilePath";
            this.repeatFilePath.Size = new System.Drawing.Size(482, 22);
            this.repeatFilePath.TabIndex = 50;
            // 
            // delimiterLabel
            // 
            this.delimiterLabel.AutoSize = true;
            this.delimiterLabel.Location = new System.Drawing.Point(341, 130);
            this.delimiterLabel.Name = "delimiterLabel";
            this.delimiterLabel.Size = new System.Drawing.Size(63, 17);
            this.delimiterLabel.TabIndex = 49;
            this.delimiterLabel.Text = "Delimiter";
            this.delimiterLabel.Visible = false;
            // 
            // delimiterField
            // 
            this.delimiterField.Location = new System.Drawing.Point(410, 127);
            this.delimiterField.Name = "delimiterField";
            this.delimiterField.Size = new System.Drawing.Size(27, 22);
            this.delimiterField.TabIndex = 48;
            this.delimiterField.Visible = false;
            // 
            // logFileTextLabel
            // 
            this.logFileTextLabel.AutoSize = true;
            this.logFileTextLabel.Location = new System.Drawing.Point(483, 77);
            this.logFileTextLabel.Name = "logFileTextLabel";
            this.logFileTextLabel.Size = new System.Drawing.Size(58, 17);
            this.logFileTextLabel.TabIndex = 47;
            this.logFileTextLabel.Text = "Log File";
            // 
            // logFilePath
            // 
            this.logFilePath.Location = new System.Drawing.Point(554, 74);
            this.logFilePath.Name = "logFilePath";
            this.logFilePath.Size = new System.Drawing.Size(482, 22);
            this.logFilePath.TabIndex = 46;
            // 
            // logFileExplore
            // 
            this.logFileExplore.Location = new System.Drawing.Point(1043, 74);
            this.logFileExplore.Name = "logFileExplore";
            this.logFileExplore.Size = new System.Drawing.Size(40, 23);
            this.logFileExplore.TabIndex = 45;
            this.logFileExplore.Text = "...";
            this.logFileExplore.UseVisualStyleBackColor = true;
            this.logFileExplore.Click += new System.EventHandler(this.logFileExplore_Click);
            // 
            // inputFilelabel
            // 
            this.inputFilelabel.AutoSize = true;
            this.inputFilelabel.Location = new System.Drawing.Point(483, 40);
            this.inputFilelabel.Name = "inputFilelabel";
            this.inputFilelabel.Size = new System.Drawing.Size(65, 17);
            this.inputFilelabel.TabIndex = 44;
            this.inputFilelabel.Text = "Input File";
            // 
            // InputFileExplore
            // 
            this.InputFileExplore.Location = new System.Drawing.Point(1043, 33);
            this.InputFileExplore.Name = "InputFileExplore";
            this.InputFileExplore.Size = new System.Drawing.Size(40, 23);
            this.InputFileExplore.TabIndex = 43;
            this.InputFileExplore.Text = "...";
            this.InputFileExplore.UseVisualStyleBackColor = true;
            this.InputFileExplore.Click += new System.EventHandler(this.InputFileExplore_Click);
            // 
            // InputTextFilePath
            // 
            this.InputTextFilePath.Location = new System.Drawing.Point(554, 35);
            this.InputTextFilePath.Name = "InputTextFilePath";
            this.InputTextFilePath.Size = new System.Drawing.Size(482, 22);
            this.InputTextFilePath.TabIndex = 42;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 785);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1112, 25);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.statusTextBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1076, 493);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(7, 22);
            this.statusTextBox.MaximumSize = new System.Drawing.Size(1063, 450);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(1063, 450);
            this.statusTextBox.TabIndex = 0;
            this.statusTextBox.Text = "";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(91, 166);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(76, 34);
            this.loginButton.TabIndex = 38;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(36, 127);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(69, 17);
            this.passwordLabel.TabIndex = 37;
            this.passwordLabel.Text = "Password";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(36, 98);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(38, 17);
            this.userLabel.TabIndex = 36;
            this.userLabel.Text = "User";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(114, 124);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(193, 22);
            this.passwordTextBox.TabIndex = 35;
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(114, 95);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(193, 22);
            this.userTextBox.TabIndex = 34;
            // 
            // getDBListButton
            // 
            this.getDBListButton.Location = new System.Drawing.Point(340, 63);
            this.getDBListButton.Name = "getDBListButton";
            this.getDBListButton.Size = new System.Drawing.Size(45, 32);
            this.getDBListButton.TabIndex = 33;
            this.getDBListButton.Text = "...";
            this.getDBListButton.UseVisualStyleBackColor = true;
            this.getDBListButton.Click += new System.EventHandler(this.getDBListButton_Click);
            // 
            // dbLabel
            // 
            this.dbLabel.AutoSize = true;
            this.dbLabel.Location = new System.Drawing.Point(36, 67);
            this.dbLabel.Name = "dbLabel";
            this.dbLabel.Size = new System.Drawing.Size(69, 17);
            this.dbLabel.TabIndex = 32;
            this.dbLabel.Text = "Database";
            // 
            // dbList
            // 
            this.dbList.FormattingEnabled = true;
            this.dbList.Location = new System.Drawing.Point(114, 64);
            this.dbList.Name = "dbList";
            this.dbList.Size = new System.Drawing.Size(193, 24);
            this.dbList.TabIndex = 31;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(36, 35);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(36, 17);
            this.urlLabel.TabIndex = 30;
            this.urlLabel.Text = "URL";
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(114, 35);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(355, 22);
            this.urlBox.TabIndex = 29;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validateButton,
            this.settingsButton,
            this.toolStripSeparator2,
            this.cadImportButton,
            this.toolStripSeparator1,
            this.guideButton,
            this.infoButton,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.exitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(1112, 27);
            this.toolStrip1.TabIndex = 57;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // validateButton
            // 
            this.validateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.validateButton.Image = ((System.Drawing.Image)(resources.GetObject("validateButton.Image")));
            this.validateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.validateButton.MergeIndex = 1;
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(24, 24);
            this.validateButton.Text = "Validate";
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(24, 24);
            this.settingsButton.Text = "Settings";
            this.settingsButton.ToolTipText = "Settings";
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // cadImportButton
            // 
            this.cadImportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cadImportButton.Image = ((System.Drawing.Image)(resources.GetObject("cadImportButton.Image")));
            this.cadImportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cadImportButton.Name = "cadImportButton";
            this.cadImportButton.Size = new System.Drawing.Size(24, 24);
            this.cadImportButton.Text = "Import CAD Data";
            this.cadImportButton.Click += new System.EventHandler(this.cadImportButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // guideButton
            // 
            this.guideButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.guideButton.Image = ((System.Drawing.Image)(resources.GetObject("guideButton.Image")));
            this.guideButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guideButton.Name = "guideButton";
            this.guideButton.Size = new System.Drawing.Size(24, 24);
            this.guideButton.Text = "Guide";
            this.guideButton.ToolTipText = "Guide";
            // 
            // infoButton
            // 
            this.infoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.infoButton.Image = ((System.Drawing.Image)(resources.GetObject("infoButton.Image")));
            this.infoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(24, 24);
            this.infoButton.Text = "Info";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ArasDataMigrationImporter.Properties.Resources.Back_Arrow;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Back to Main Window";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // exitButton
            // 
            this.exitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitButton.Name = "exitButton";
            this.exitButton.RightToLeftAutoMirrorImage = true;
            this.exitButton.Size = new System.Drawing.Size(24, 24);
            this.exitButton.Text = "Close";
            this.exitButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // inputTextFileDialog
            // 
            this.inputTextFileDialog.Filter = "Text files|*.txt|All files|*.*";
            // 
            // TextFileToAras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.techLogFilePath);
            this.Controls.Add(this.techLogFileExploreButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.repeteFileExploreButton);
            this.Controls.Add(this.repeatFilePath);
            this.Controls.Add(this.delimiterLabel);
            this.Controls.Add(this.delimiterField);
            this.Controls.Add(this.logFileTextLabel);
            this.Controls.Add(this.logFilePath);
            this.Controls.Add(this.logFileExplore);
            this.Controls.Add(this.inputFilelabel);
            this.Controls.Add(this.InputFileExplore);
            this.Controls.Add(this.InputTextFilePath);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.getDBListButton);
            this.Controls.Add(this.dbLabel);
            this.Controls.Add(this.dbList);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.urlBox);
            this.Name = "TextFileToAras";
            this.Size = new System.Drawing.Size(1112, 810);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox techLogFilePath;
        private System.Windows.Forms.Button techLogFileExploreButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button repeteFileExploreButton;
        private System.Windows.Forms.TextBox repeatFilePath;
        private System.Windows.Forms.Label delimiterLabel;
        private System.Windows.Forms.TextBox delimiterField;
        private System.Windows.Forms.Label logFileTextLabel;
        private System.Windows.Forms.TextBox logFilePath;
        private System.Windows.Forms.Button logFileExplore;
        private System.Windows.Forms.Label inputFilelabel;
        private System.Windows.Forms.Button InputFileExplore;
        private System.Windows.Forms.TextBox InputTextFilePath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox statusTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Button getDBListButton;
        private System.Windows.Forms.Label dbLabel;
        private System.Windows.Forms.ComboBox dbList;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton validateButton;
        private System.Windows.Forms.ToolStripButton settingsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton cadImportButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton guideButton;
        private System.Windows.Forms.ToolStripButton infoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton exitButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog inputTextFileDialog;
        private System.Windows.Forms.OpenFileDialog logFileDialog;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}
