namespace ArasDataMigrationImporter
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picBoxExitButton = new System.Windows.Forms.PictureBox();
            this.picBoxCADToExcel = new System.Windows.Forms.PictureBox();
            this.picBoxTextToAras = new System.Windows.Forms.PictureBox();
            this.selectCAD = new ArasDataMigrationImporter.SelectCAD();
            this.textFileToAras = new ArasDataMigrationImporter.TextFileToAras();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCADToExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTextToAras)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxExitButton
            // 
            this.picBoxExitButton.Image = global::ArasDataMigrationImporter.Properties.Resources.logout__2_;
            this.picBoxExitButton.Location = new System.Drawing.Point(1070, 12);
            this.picBoxExitButton.Name = "picBoxExitButton";
            this.picBoxExitButton.Size = new System.Drawing.Size(30, 30);
            this.picBoxExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxExitButton.TabIndex = 1;
            this.picBoxExitButton.TabStop = false;
            this.toolTip1.SetToolTip(this.picBoxExitButton, "Close");
            this.picBoxExitButton.Click += new System.EventHandler(this.picBoxExitButton_Click);
            // 
            // picBoxCADToExcel
            // 
            this.picBoxCADToExcel.Image = global::ArasDataMigrationImporter.Properties.Resources.CAD_to_Excel1;
            this.picBoxCADToExcel.Location = new System.Drawing.Point(32, 221);
            this.picBoxCADToExcel.Name = "picBoxCADToExcel";
            this.picBoxCADToExcel.Size = new System.Drawing.Size(240, 146);
            this.picBoxCADToExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxCADToExcel.TabIndex = 0;
            this.picBoxCADToExcel.TabStop = false;
            this.picBoxCADToExcel.Click += new System.EventHandler(this.picBoxCADToExcel_Click);
            this.picBoxCADToExcel.MouseLeave += new System.EventHandler(this.picBoxCADToExcel_MouseLeave);
            this.picBoxCADToExcel.MouseHover += new System.EventHandler(this.picBoxCADToExcel_MouseHover);
            // 
            // picBoxTextToAras
            // 
            this.picBoxTextToAras.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTextToAras.Image")));
            this.picBoxTextToAras.Location = new System.Drawing.Point(32, 28);
            this.picBoxTextToAras.Name = "picBoxTextToAras";
            this.picBoxTextToAras.Size = new System.Drawing.Size(240, 146);
            this.picBoxTextToAras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxTextToAras.TabIndex = 0;
            this.picBoxTextToAras.TabStop = false;
            this.toolTip1.SetToolTip(this.picBoxTextToAras, "Import Data from Text File to Aras");
            this.picBoxTextToAras.Click += new System.EventHandler(this.picBoxTextToAras_Click);
            this.picBoxTextToAras.MouseLeave += new System.EventHandler(this.picBoxTextToAras_MouseLeave);
            this.picBoxTextToAras.MouseHover += new System.EventHandler(this.picBoxTextToAras_MouseHover);
            // 
            // selectCAD
            // 
            this.selectCAD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectCAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectCAD.Location = new System.Drawing.Point(909, 459);
            this.selectCAD.Name = "selectCAD";
            this.selectCAD.Size = new System.Drawing.Size(156, 51);
            this.selectCAD.TabIndex = 3;
            // 
            // textFileToAras
            // 
            this.textFileToAras.BackColor = System.Drawing.Color.White;
            this.textFileToAras.Location = new System.Drawing.Point(555, 459);
            this.textFileToAras.Name = "textFileToAras";
            this.textFileToAras.Size = new System.Drawing.Size(81, 60);
            this.textFileToAras.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1112, 808);
            this.Controls.Add(this.selectCAD);
            this.Controls.Add(this.textFileToAras);
            this.Controls.Add(this.picBoxExitButton);
            this.Controls.Add(this.picBoxCADToExcel);
            this.Controls.Add(this.picBoxTextToAras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HelpButton = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAD Data Import/Export";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCADToExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTextToAras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxTextToAras;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picBoxCADToExcel;
        private System.Windows.Forms.PictureBox picBoxExitButton;
        private TextFileToAras textFileToAras;
        private SelectCAD selectCAD;
    }
}

