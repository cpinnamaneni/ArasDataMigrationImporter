using ArasDataMigrationImporter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArasDataMigrationImporter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            //Hide Testfile to Aras UserControle
            textFileToAras.Dock = DockStyle.None;
           
            textFileToAras.Hide();

            selectCAD.Dock = DockStyle.None;

            selectCAD.Hide();

            //Hide Select CAD UserControle

        }

        private void picBoxTextToAras_MouseHover(object sender, EventArgs e)
        {
            picBoxTextToAras.Image = Resources.Text_to_Aras2;
        }

        private void picBoxTextToAras_MouseLeave(object sender, EventArgs e)
        {
            picBoxTextToAras.Image = Resources.Text_to_Aras1;
        }

        private void picBoxCADToExcel_MouseHover(object sender, EventArgs e)
        {
            picBoxCADToExcel.Image = Resources.CAD_to_Excel2;
        }

        private void picBoxCADToExcel_MouseLeave(object sender, EventArgs e)
        {
            picBoxCADToExcel.Image = Resources.CAD_to_Excel1;
        }

        private void picBoxTextToAras_Click(object sender, EventArgs e)
        {
            this.Text = "Import Data from Text file to Aras";
            //textFileToAras1 textFileToAras = new textFileToAras1();
            textFileToAras.Dock = DockStyle.Fill;
            textFileToAras.BringToFront();
            textFileToAras.Focus();
            textFileToAras.Show();
        }

        private void picBoxExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picBoxCADToExcel_Click(object sender, EventArgs e)
        {
            this.Text = "Export the CAD data into Excel";
            selectCAD.Dock = DockStyle.Fill;
            selectCAD.BringToFront();
            selectCAD.Focus();
            selectCAD.Show();
        }
    }
}
