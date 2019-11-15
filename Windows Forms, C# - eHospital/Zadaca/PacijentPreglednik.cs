using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zadaca;

namespace Zadaca
{
    public partial class PacijentPreglednik : Form
    {
        
        private Pacijent pac;
        List<string> vakc = new List<string>();
        List<string> alerg = new List<string>();
        public PacijentPreglednik(Pacijent ppac)
        {
            pac = ppac;
            /*
            foreach(var vakcinacija in pac.KartonPacijenta.Vakcinacije)
            {
                listBox1.Items.Add(vakcinacija.Key.ToString() + ", " + vakcinacija.Value);                
            }
            foreach (var alergija in pac.KartonPacijenta.Alergije)
            {
                listBox2.Items.Add(alergija.Key.ToString() + ", " + alergija.Value.ToString());
            }
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox2.SelectionMode = SelectionMode.MultiSimple;
            MessageBox.Show(vakc[0], "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            /*listBox1.DataSource =vakc;
            listBox2.DataSource =alerg;*/

            InitializeComponent();
            

        }

        private void PacijentPreglednik_Load(object sender, EventArgs e)
        {
            if (pac != null)
            {
                textBox6.Text = pac.Ime;
                textBox5.Text = pac.Prezime;
                dateTimePicker3.Value = pac.DatumRodjenja;
                textBox4.Text = pac.AdresaStanovanja;
                textBox3.Text = pac.MaticniBroj;
                comboBox4.SelectedItem = pac.BracnoStanje.ToString();
                comboBox5.SelectedItem = "Pacijent";
                comboBox6.SelectedItem = pac.Spol;
                dateTimePicker3.Value = pac.DatumRodjenja;
                dateTimePicker3.ShowCheckBox = false;
                dateTimePicker3.ShowUpDown = false;
                dateTimePicker3.MinDate = pac.DatumRodjenja;
                dateTimePicker3.MaxDate = pac.DatumRodjenja;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
