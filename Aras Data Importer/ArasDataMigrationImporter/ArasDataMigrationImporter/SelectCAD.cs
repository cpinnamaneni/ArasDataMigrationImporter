using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArasDataMigrationImporter
{
    public partial class SelectCAD : UserControl
    {
        public SelectCAD()
        {
            InitializeComponent();
        }

        private void picBoxCAD_MouseHover(object sender, EventArgs e)
        {
            PictureBox fieldcontrole = (PictureBox)sender;
            fieldcontrole.BorderStyle = BorderStyle.Fixed3D;
        }
        private void picBoxCAD_MouseLeave(object sender, EventArgs e)
        {
            PictureBox fieldcontrole = (PictureBox)sender;
            fieldcontrole.BorderStyle = BorderStyle.FixedSingle;
        }

        private void picBoxExitButton_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Parent.Text = "CAD Data Import/Export";
            this.Hide();
        }

        private void picBoxCreo_Click(object sender, EventArgs e)
        {
            this.Parent.Text = "Export Creo Data to Excel";
            MessageBox.Show("Creo....");
        }

        private void picBoxAutoCAD_Click(object sender, EventArgs e)
        {
            this.Parent.Text = "Export Auto CAD Data to Excel";

            MessageBox.Show("Auto CAD....");
        }

        private void picBoxSolidWorks_Click(object sender, EventArgs e)
        {
            this.Parent.Text = "Export SolidWorks Data to Excel";

            MessageBox.Show("Solid Works....");

        }



        private void picBoxSolidEdge_Click(object sender, EventArgs e)
        {
            this.Parent.Text = "Export Solid Edge Data to Excel";

            MessageBox.Show("Solid Edge....");
        }
    }
}
