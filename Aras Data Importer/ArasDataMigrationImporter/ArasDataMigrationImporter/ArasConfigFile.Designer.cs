namespace ArasDataMigrationImporter
{
    partial class ArasConfigFile
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.arasConfigCancelButton = new System.Windows.Forms.Button();
            this.arasConfigApply = new System.Windows.Forms.Button();
            this.deleteFilesOnRevCBox = new System.Windows.Forms.ComboBox();
            this.deleteFilesOnRevLabel = new System.Windows.Forms.Label();
            this.fileFolderLabel = new System.Windows.Forms.Label();
            this.fileFolderTBox = new System.Windows.Forms.TextBox();
            this.childFileRelCBox = new System.Windows.Forms.ComboBox();
            this.parentFileRelCBox = new System.Windows.Forms.ComboBox();
            this.parentChildRelCBox = new System.Windows.Forms.ComboBox();
            this.childStuctRelCBox = new System.Windows.Forms.ComboBox();
            this.parentStuctRelCBox = new System.Windows.Forms.ComboBox();
            this.childItemTypeCBox = new System.Windows.Forms.ComboBox();
            this.parentItemTypeCBox = new System.Windows.Forms.ComboBox();
            this.childItemTypeLabel = new System.Windows.Forms.Label();
            this.parentStuctRelLabel = new System.Windows.Forms.Label();
            this.childStuctRelLabel = new System.Windows.Forms.Label();
            this.parentChildRelLabel = new System.Windows.Forms.Label();
            this.parentFileRelLabel = new System.Windows.Forms.Label();
            this.childFileRelLabel = new System.Windows.Forms.Label();
            this.dlimiterLabel = new System.Windows.Forms.Label();
            this.delimiterTBox = new System.Windows.Forms.TextBox();
            this.dateFormatLabel = new System.Windows.Forms.Label();
            this.dateFormatTBox = new System.Windows.Forms.TextBox();
            this.ParentItemLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // arasConfigCancelButton
            // 
            this.arasConfigCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.arasConfigCancelButton.Location = new System.Drawing.Point(303, 412);
            this.arasConfigCancelButton.Name = "arasConfigCancelButton";
            this.arasConfigCancelButton.Size = new System.Drawing.Size(92, 33);
            this.arasConfigCancelButton.TabIndex = 54;
            this.arasConfigCancelButton.Text = "Cancel";
            this.arasConfigCancelButton.UseVisualStyleBackColor = true;
            this.arasConfigCancelButton.Click += new System.EventHandler(this.arasConfigCancelButton_Click);
            // 
            // arasConfigApply
            // 
            this.arasConfigApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.arasConfigApply.Location = new System.Drawing.Point(60, 412);
            this.arasConfigApply.Name = "arasConfigApply";
            this.arasConfigApply.Size = new System.Drawing.Size(97, 33);
            this.arasConfigApply.TabIndex = 53;
            this.arasConfigApply.Text = "Apply";
            this.arasConfigApply.UseVisualStyleBackColor = true;
            this.arasConfigApply.Click += new System.EventHandler(this.arasConfigApply_Click);
            // 
            // deleteFilesOnRevCBox
            // 
            this.deleteFilesOnRevCBox.FormattingEnabled = true;
            this.deleteFilesOnRevCBox.Items.AddRange(new object[] {
            "true",
            "false"});
            this.deleteFilesOnRevCBox.Location = new System.Drawing.Point(214, 347);
            this.deleteFilesOnRevCBox.Name = "deleteFilesOnRevCBox";
            this.deleteFilesOnRevCBox.Size = new System.Drawing.Size(121, 24);
            this.deleteFilesOnRevCBox.TabIndex = 52;
            // 
            // deleteFilesOnRevLabel
            // 
            this.deleteFilesOnRevLabel.AutoSize = true;
            this.deleteFilesOnRevLabel.Location = new System.Drawing.Point(44, 343);
            this.deleteFilesOnRevLabel.Name = "deleteFilesOnRevLabel";
            this.deleteFilesOnRevLabel.Size = new System.Drawing.Size(149, 17);
            this.deleteFilesOnRevLabel.TabIndex = 51;
            this.deleteFilesOnRevLabel.Text = "Delete Files on Revise";
            // 
            // fileFolderLabel
            // 
            this.fileFolderLabel.AutoSize = true;
            this.fileFolderLabel.Location = new System.Drawing.Point(44, 322);
            this.fileFolderLabel.Name = "fileFolderLabel";
            this.fileFolderLabel.Size = new System.Drawing.Size(74, 17);
            this.fileFolderLabel.TabIndex = 50;
            this.fileFolderLabel.Text = "File Folder";
            // 
            // fileFolderTBox
            // 
            this.fileFolderTBox.Location = new System.Drawing.Point(214, 318);
            this.fileFolderTBox.Name = "fileFolderTBox";
            this.fileFolderTBox.Size = new System.Drawing.Size(181, 22);
            this.fileFolderTBox.TabIndex = 49;
            // 
            // childFileRelCBox
            // 
            this.childFileRelCBox.FormattingEnabled = true;
            this.childFileRelCBox.Location = new System.Drawing.Point(214, 232);
            this.childFileRelCBox.Name = "childFileRelCBox";
            this.childFileRelCBox.Size = new System.Drawing.Size(181, 24);
            this.childFileRelCBox.TabIndex = 48;
            // 
            // parentFileRelCBox
            // 
            this.parentFileRelCBox.FormattingEnabled = true;
            this.parentFileRelCBox.Location = new System.Drawing.Point(214, 202);
            this.parentFileRelCBox.Name = "parentFileRelCBox";
            this.parentFileRelCBox.Size = new System.Drawing.Size(181, 24);
            this.parentFileRelCBox.TabIndex = 47;
            // 
            // parentChildRelCBox
            // 
            this.parentChildRelCBox.FormattingEnabled = true;
            this.parentChildRelCBox.Location = new System.Drawing.Point(214, 173);
            this.parentChildRelCBox.Name = "parentChildRelCBox";
            this.parentChildRelCBox.Size = new System.Drawing.Size(181, 24);
            this.parentChildRelCBox.TabIndex = 46;
            // 
            // childStuctRelCBox
            // 
            this.childStuctRelCBox.FormattingEnabled = true;
            this.childStuctRelCBox.Location = new System.Drawing.Point(214, 144);
            this.childStuctRelCBox.Name = "childStuctRelCBox";
            this.childStuctRelCBox.Size = new System.Drawing.Size(181, 24);
            this.childStuctRelCBox.TabIndex = 45;
            // 
            // parentStuctRelCBox
            // 
            this.parentStuctRelCBox.FormattingEnabled = true;
            this.parentStuctRelCBox.Location = new System.Drawing.Point(214, 116);
            this.parentStuctRelCBox.Name = "parentStuctRelCBox";
            this.parentStuctRelCBox.Size = new System.Drawing.Size(181, 24);
            this.parentStuctRelCBox.TabIndex = 44;
            // 
            // childItemTypeCBox
            // 
            this.childItemTypeCBox.FormattingEnabled = true;
            this.childItemTypeCBox.Location = new System.Drawing.Point(214, 86);
            this.childItemTypeCBox.Name = "childItemTypeCBox";
            this.childItemTypeCBox.Size = new System.Drawing.Size(181, 24);
            this.childItemTypeCBox.TabIndex = 43;
            this.childItemTypeCBox.TextChanged += new System.EventHandler(this.childItemTypeCBox_TextChanged);
            // 
            // parentItemTypeCBox
            // 
            this.parentItemTypeCBox.FormattingEnabled = true;
            this.parentItemTypeCBox.Location = new System.Drawing.Point(214, 56);
            this.parentItemTypeCBox.Name = "parentItemTypeCBox";
            this.parentItemTypeCBox.Size = new System.Drawing.Size(181, 24);
            this.parentItemTypeCBox.TabIndex = 42;
            this.parentItemTypeCBox.TextChanged += new System.EventHandler(this.parentItemTypeCBox_TextChanged);
            // 
            // childItemTypeLabel
            // 
            this.childItemTypeLabel.AutoSize = true;
            this.childItemTypeLabel.Location = new System.Drawing.Point(41, 93);
            this.childItemTypeLabel.Name = "childItemTypeLabel";
            this.childItemTypeLabel.Size = new System.Drawing.Size(105, 17);
            this.childItemTypeLabel.TabIndex = 41;
            this.childItemTypeLabel.Text = "Child Item Type";
            // 
            // parentStuctRelLabel
            // 
            this.parentStuctRelLabel.AutoSize = true;
            this.parentStuctRelLabel.Location = new System.Drawing.Point(41, 121);
            this.parentStuctRelLabel.Name = "parentStuctRelLabel";
            this.parentStuctRelLabel.Size = new System.Drawing.Size(137, 17);
            this.parentStuctRelLabel.TabIndex = 40;
            this.parentStuctRelLabel.Text = "Parent Structure Rel";
            // 
            // childStuctRelLabel
            // 
            this.childStuctRelLabel.AutoSize = true;
            this.childStuctRelLabel.Location = new System.Drawing.Point(41, 149);
            this.childStuctRelLabel.Name = "childStuctRelLabel";
            this.childStuctRelLabel.Size = new System.Drawing.Size(126, 17);
            this.childStuctRelLabel.TabIndex = 39;
            this.childStuctRelLabel.Text = "Child Structure Rel";
            // 
            // parentChildRelLabel
            // 
            this.parentChildRelLabel.AutoSize = true;
            this.parentChildRelLabel.Location = new System.Drawing.Point(41, 177);
            this.parentChildRelLabel.Name = "parentChildRelLabel";
            this.parentChildRelLabel.Size = new System.Drawing.Size(110, 17);
            this.parentChildRelLabel.TabIndex = 38;
            this.parentChildRelLabel.Text = "Parent Child Rel";
            // 
            // parentFileRelLabel
            // 
            this.parentFileRelLabel.AutoSize = true;
            this.parentFileRelLabel.Location = new System.Drawing.Point(41, 205);
            this.parentFileRelLabel.Name = "parentFileRelLabel";
            this.parentFileRelLabel.Size = new System.Drawing.Size(101, 17);
            this.parentFileRelLabel.TabIndex = 37;
            this.parentFileRelLabel.Text = "Parent File Rel";
            // 
            // childFileRelLabel
            // 
            this.childFileRelLabel.AutoSize = true;
            this.childFileRelLabel.Location = new System.Drawing.Point(41, 237);
            this.childFileRelLabel.Name = "childFileRelLabel";
            this.childFileRelLabel.Size = new System.Drawing.Size(90, 17);
            this.childFileRelLabel.TabIndex = 36;
            this.childFileRelLabel.Text = "Child File Rel";
            // 
            // dlimiterLabel
            // 
            this.dlimiterLabel.AutoSize = true;
            this.dlimiterLabel.Location = new System.Drawing.Point(41, 265);
            this.dlimiterLabel.Name = "dlimiterLabel";
            this.dlimiterLabel.Size = new System.Drawing.Size(63, 17);
            this.dlimiterLabel.TabIndex = 35;
            this.dlimiterLabel.Text = "Delimiter";
            // 
            // delimiterTBox
            // 
            this.delimiterTBox.Location = new System.Drawing.Point(214, 261);
            this.delimiterTBox.Name = "delimiterTBox";
            this.delimiterTBox.Size = new System.Drawing.Size(181, 22);
            this.delimiterTBox.TabIndex = 34;
            // 
            // dateFormatLabel
            // 
            this.dateFormatLabel.AutoSize = true;
            this.dateFormatLabel.Location = new System.Drawing.Point(41, 293);
            this.dateFormatLabel.Name = "dateFormatLabel";
            this.dateFormatLabel.Size = new System.Drawing.Size(82, 17);
            this.dateFormatLabel.TabIndex = 33;
            this.dateFormatLabel.Text = "DateFormat";
            // 
            // dateFormatTBox
            // 
            this.dateFormatTBox.Location = new System.Drawing.Point(214, 289);
            this.dateFormatTBox.Name = "dateFormatTBox";
            this.dateFormatTBox.Size = new System.Drawing.Size(181, 22);
            this.dateFormatTBox.TabIndex = 32;
            // 
            // ParentItemLabel
            // 
            this.ParentItemLabel.AutoSize = true;
            this.ParentItemLabel.Location = new System.Drawing.Point(41, 65);
            this.ParentItemLabel.Name = "ParentItemLabel";
            this.ParentItemLabel.Size = new System.Drawing.Size(116, 17);
            this.ParentItemLabel.TabIndex = 31;
            this.ParentItemLabel.Text = "Parent Item Type";
            // 
            // ArasConfigFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 469);
            this.Controls.Add(this.arasConfigCancelButton);
            this.Controls.Add(this.arasConfigApply);
            this.Controls.Add(this.deleteFilesOnRevCBox);
            this.Controls.Add(this.deleteFilesOnRevLabel);
            this.Controls.Add(this.fileFolderLabel);
            this.Controls.Add(this.fileFolderTBox);
            this.Controls.Add(this.childFileRelCBox);
            this.Controls.Add(this.parentFileRelCBox);
            this.Controls.Add(this.parentChildRelCBox);
            this.Controls.Add(this.childStuctRelCBox);
            this.Controls.Add(this.parentStuctRelCBox);
            this.Controls.Add(this.childItemTypeCBox);
            this.Controls.Add(this.parentItemTypeCBox);
            this.Controls.Add(this.childItemTypeLabel);
            this.Controls.Add(this.parentStuctRelLabel);
            this.Controls.Add(this.childStuctRelLabel);
            this.Controls.Add(this.parentChildRelLabel);
            this.Controls.Add(this.parentFileRelLabel);
            this.Controls.Add(this.childFileRelLabel);
            this.Controls.Add(this.dlimiterLabel);
            this.Controls.Add(this.delimiterTBox);
            this.Controls.Add(this.dateFormatLabel);
            this.Controls.Add(this.dateFormatTBox);
            this.Controls.Add(this.ParentItemLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ArasConfigFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArasConfigFile";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button arasConfigCancelButton;
        private System.Windows.Forms.Button arasConfigApply;
        private System.Windows.Forms.ComboBox deleteFilesOnRevCBox;
        private System.Windows.Forms.Label deleteFilesOnRevLabel;
        private System.Windows.Forms.Label fileFolderLabel;
        private System.Windows.Forms.TextBox fileFolderTBox;
        private System.Windows.Forms.ComboBox childFileRelCBox;
        private System.Windows.Forms.ComboBox parentFileRelCBox;
        private System.Windows.Forms.ComboBox parentChildRelCBox;
        private System.Windows.Forms.ComboBox childStuctRelCBox;
        private System.Windows.Forms.ComboBox parentStuctRelCBox;
        private System.Windows.Forms.ComboBox childItemTypeCBox;
        private System.Windows.Forms.ComboBox parentItemTypeCBox;
        private System.Windows.Forms.Label childItemTypeLabel;
        private System.Windows.Forms.Label parentStuctRelLabel;
        private System.Windows.Forms.Label childStuctRelLabel;
        private System.Windows.Forms.Label parentChildRelLabel;
        private System.Windows.Forms.Label parentFileRelLabel;
        private System.Windows.Forms.Label childFileRelLabel;
        private System.Windows.Forms.Label dlimiterLabel;
        private System.Windows.Forms.TextBox delimiterTBox;
        private System.Windows.Forms.Label dateFormatLabel;
        private System.Windows.Forms.TextBox dateFormatTBox;
        private System.Windows.Forms.Label ParentItemLabel;
    }
}