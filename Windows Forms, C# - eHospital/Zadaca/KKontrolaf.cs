using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadaca
{
    public partial class KKontrolaf : Form
    {
        DateTime datum;
        string greska;
        Image image;
        bool desila = false;
        public KKontrolaf()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            datum = dateTimePicker1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value.AddMonths(6)<DateTime.Now)
            {
                greska = "Stara slika";
                desila = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.CheckFileExists && openFileDialog1.FileName.Contains(".jpg"))
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ImageLocation = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Profilna slika nije pravilno izabrana ili nije u ispravnom formatu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
