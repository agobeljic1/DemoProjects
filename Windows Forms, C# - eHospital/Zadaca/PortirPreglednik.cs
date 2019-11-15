using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;



namespace Zadaca
{
    public partial class PortirPreglednik : Form
    {
        Portir portir;
        public PortirPreglednik(Portir porta)
        {
            portir = porta;
            InitializeComponent();
        }

        private void PortirPreglednik_Load(object sender, EventArgs e)
        {
            if (portir != null)
            {
                
                textBox10.Text = portir.Ime;
                textBox9.Text = portir.Prezime;
                dateTimePicker2.Value = portir.DatumRodjenja;
                textBox8.Text = portir.AdresaStanovanja;
                textBox1.Text = portir.MaticniBroj;
                comboBox3.SelectedItem = portir.BracnoStanje;
                comboBox2.SelectedItem = "Portir";
                comboBox1.SelectedItem = portir.Spol;
                dateTimePicker1.Value = portir.DatumZaposlenja;
                textBox3.Text = portir.ZaposlenikovaOrdinacija.Odjel;
                textBox2.Text = portir.Plata.ToString();
                dateTimePicker2.ShowCheckBox = false;
                dateTimePicker2.ShowUpDown = false;
                dateTimePicker2.MinDate = portir.DatumRodjenja;
                dateTimePicker2.MaxDate = portir.DatumRodjenja;
                dateTimePicker1.ShowCheckBox = false;
                dateTimePicker1.ShowUpDown = false;
                dateTimePicker1.MinDate = portir.DatumZaposlenja;
                dateTimePicker1.MaxDate = portir.DatumZaposlenja;



                foreach (Ordinacija ordinacija in Ulaz.odgovornaKlinika.ListaOrdinacija)
                {
                    int brojac = 0;
                    foreach (var pregled in Ulaz.odgovornaKlinika.ListaPregledaCekanja)
                    {
                        if (pregled.Ordinacija == ordinacija.Odjel)
                            brojac++;
                    }
                    ListViewItem itm1 = new ListViewItem(ordinacija.Odjel);
                    itm1.SubItems.Add(ordinacija.OdgovorniDoktor.Ime + " " + ordinacija.OdgovorniDoktor.Prezime);
                    string prisutan;
                    if (ordinacija.Slobodno)
                        prisutan = "Da";
                    else
                        prisutan = "Ne";
                    itm1.SubItems.Add(prisutan);
                    itm1.SubItems.Add(brojac.ToString());
                    listView4.Items.Add(itm1);
                }
            }
            


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void ThreadProc()
        {
            Klinika kl = Ulaz.odgovornaKlinika;
            Application.Run(new Ulaz(kl));
        }
        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            Close();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ime = textBox17.Text;
                string prezime = textBox18.Text;
                string jmbg = textBox19.Text;
                int nadjen = 0;
                foreach (Pacijent pacijent in Ulaz.odgovornaKlinika.ListaPacijenata)
                {
                    if (pacijent.Ime == ime && pacijent.Prezime == prezime && pacijent.MaticniBroj == jmbg)
                    {
                        nadjen = 1;
                        pacijent.KartonPacijenta.OpisBolesti = textBox4.Text;
                        pacijent.KartonPacijenta.ZdravstvenoStanjePorodice = textBox5.Text;
                        pacijent.KartonPacijenta.SadasnjeStanje = textBox6.Text;
                        pacijent.KartonPacijenta.ZakljucakDoktora = textBox7.Text;
                        break;
                    }
                }
                if (nadjen == 0)
                {
                    MessageBox.Show("Pacijent nije pronadjen", "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Pacijent uspjesno azuriran", "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                obrisi();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ime = textBox17.Text;
            string prezime = textBox18.Text;
            string jmbg = textBox19.Text;
            int nadjen = 0;
            foreach (Pacijent pacijent in Ulaz.odgovornaKlinika.ListaPacijenata)
            {
                if (pacijent.Ime == ime && pacijent.Prezime == prezime && pacijent.MaticniBroj == jmbg)
                {
                    nadjen = 1;
                    pacijent.KartonPacijenta.Vakcinacije.Add(dateTimePicker5.Value, textBox12.Text);
                    break;
                }
            }
            if (nadjen == 0)
            {
                MessageBox.Show("Pacijent nije pronadjen", "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            else
            {                
                MessageBox.Show("Pacijent uspjesno azuriran", "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);                           
            }
            obrisi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ime = textBox17.Text;
            string prezime = textBox18.Text;
            string jmbg = textBox19.Text;
            int nadjen = 0;
            foreach (Pacijent pacijent in Ulaz.odgovornaKlinika.ListaPacijenata)
            {
                if (pacijent.Ime == ime && pacijent.Prezime == prezime && pacijent.MaticniBroj == jmbg)
                {
                    nadjen = 1;
                    pacijent.KartonPacijenta.Alergije.Add(dateTimePicker3.Value, textBox11.Text);
                    break;
                }
            }
            if (nadjen == 0)
            {
                MessageBox.Show("Pacijent nije pronadjen", "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                obrisi();
            }
            else
            {
                MessageBox.Show("Pacijent uspjesno azuriran", "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                obrisi();
            }
        }

        private void obrisi()
        {
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox12.Text = "";
            textBox11.Text = "";
            dateTimePicker5.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
        }

        private void obrisi1()
        {
            textBox20.Text = "";
            dateTimePicker6.Value = DateTime.Now;
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int nadjen = 0;
                string ime = textBox20.Text;
                string prezime = textBox22.Text;
                string jmbg = textBox23.Text;
                foreach (Pacijent pac in Ulaz.odgovornaKlinika.ListaPacijenata)
                {
                    if (pac.Ime == ime && pac.Prezime == prezime && pac.MaticniBroj == jmbg)
                    {
                        nadjen = 1;
                        DateTime datum = dateTimePicker6.Value;
                        string ordinacija = textBox24.Text;
                        string nadlezniDoktor = textBox25.Text;
                        int nadjenPregled = 0;
                        foreach (Pregled pregled in pac.KartonPacijenta.SpisakPregleda)
                        {
                            if (pregled.Ordinacija == ordinacija && pregled.NadlezniDoktor.Ime + " " + pregled.NadlezniDoktor.Prezime == nadlezniDoktor && pregled.VrijemePregleda == datum)
                            {
                                nadjenPregled = 1;
                                MessageBox.Show("Cijena iznosi " + pregled.NadlezniDoktor.ZaposlenikovaOrdinacija.CijenaPregleda.ToString() + " KM", "Naplata pregleda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                obrisi1();
                                break;
                            }
                        }
                        if (nadjenPregled == 0)
                        {
                            MessageBox.Show("Pregled nije pronadjen", "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            obrisi1();
                        }
                        break;

                    }
                }
                if (nadjen == 0)
                {
                    MessageBox.Show("Pacijent nije pronadjen", "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obrisi1();
                    return;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel4.Text = ex.Message;
            }
        }
        private void obrisiRegistraciju()
        {
            textBox13.Text = "";
            dateTimePicker4.Value = DateTime.Now;
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox25.Text = "";
            comboBox8.SelectedItem = "";
            comboBox6.SelectedItem = "";
            pictureBox2.Image = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            obrisiRegistraciju();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Pacijent pac = new Pacijent(textBox16.Text, textBox15.Text, dateTimePicker4.Value, textBox13.Text, comboBox8.SelectedItem.ToString(), textBox14.Text, comboBox6.SelectedItem.ToString(), "abcdefgah", pictureBox2.Image);
                Ulaz.odgovornaKlinika.ListaPacijenata.Add(pac);
                obrisiRegistraciju();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string ime = textBox27.Text;
                string prezime = textBox28.Text;
                string jmbg = textBox29.Text;
                int nadjen = 0;
                Pacijent pacijent = new Pacijent();
                foreach (Pacijent pac in Ulaz.odgovornaKlinika.ListaPacijenata)
                {
                    if (ime == pac.Ime && prezime == pac.Prezime && jmbg == pac.MaticniBroj)
                    {
                        pacijent = pac;
                        nadjen = 1;
                        break;
                    }
                }
                if (nadjen == 0)
                {
                    MessageBox.Show("Pacijent nije pronadjen.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Doktor doktor = new Doktor();
                string ord = textBox26.Text;
                string dok = textBox21.Text;
                nadjen = 0;
                foreach (Zaposlenik zap in Ulaz.odgovornaKlinika.ListaZaposlenika)
                {
                    if (zap.GetType().Name.ToString() == "Doktor" && dok == zap.Ime + " " + zap.Prezime && ord == zap.ZaposlenikovaOrdinacija.Odjel)
                    {
                        nadjen = 1;
                        Pregled pregled = new Pregled(ord, zap as Doktor, pacijent, false, false);
                        Ulaz.odgovornaKlinika.ListaPregledaCekanja.Add(pregled);
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel3.Text = ex.Message;
            }

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void tabPage3_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void tabPage4_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void tabPage5_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void tabPage6_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }


        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox16_Validating(object sender, CancelEventArgs e)
        {
            if (textBox16.Text.Count() <3)
            {
                e.Cancel = true;
                textBox16.Focus();
                errorProvider1.SetError(textBox16, "Ime mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Ime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox16, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox15_Validating(object sender, CancelEventArgs e)
        {
            if (textBox15.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox15.Focus();
                errorProvider1.SetError(textBox15, "Prezime mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Prezime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox15, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox13_Validating(object sender, CancelEventArgs e)
        {
            if (textBox13.Text.Count() !=13)
            {
                e.Cancel = true;
                textBox13.Focus();
                errorProvider1.SetError(textBox13, "JMBG mora imati 13 karaktera");
                toolStripStatusLabel1.Text = "JMBG mora imati 13 karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox13, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox14_Validating(object sender, CancelEventArgs e)
        {
            if (textBox14.Text.Count() ==0)
            {
                e.Cancel = true;
                textBox14.Focus();
                errorProvider1.SetError(textBox14, "Polje ne smije biti prazno");
                toolStripStatusLabel1.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox14, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox17_Validating(object sender, CancelEventArgs e)
        {
            if (textBox17.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox17.Focus();
                errorProvider1.SetError(textBox17, "Ime mora imati barem tri karaktera");
                toolStripStatusLabel2.Text = "Ime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox17, null);
                toolStripStatusLabel2.Text = "";
            }
        }

        private void textBox18_Validating(object sender, CancelEventArgs e)
        {
            if (textBox18.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox18.Focus();
                errorProvider1.SetError(textBox18, "Prezime mora imati barem tri karaktera");
                toolStripStatusLabel2.Text = "Prezime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox18, null);
                toolStripStatusLabel2.Text = "";
            }
        }

        private void textBox19_Validating(object sender, CancelEventArgs e)
        {
            if (textBox19.Text.Count() != 13)
            {
                e.Cancel = true;
                textBox19.Focus();
                errorProvider1.SetError(textBox19, "JMBG mora imati 13 karaktera");
                toolStripStatusLabel2.Text = "JMBG mora imati 13 karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox19, null);
                toolStripStatusLabel2.Text = "";
            }
        }

       


        

        private void textBox20_Validating(object sender, CancelEventArgs e)
        {
            if (textBox20.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox20.Focus();
                errorProvider1.SetError(textBox20, "Ime mora imati barem tri karaktera");
                toolStripStatusLabel4.Text = "Ime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox20, null);
                toolStripStatusLabel4.Text = "";
            }
        }

        private void textBox22_Validating(object sender, CancelEventArgs e)
        {
            if (textBox22.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox22.Focus();
                errorProvider1.SetError(textBox22, "Prezime mora imati barem tri karaktera");
                toolStripStatusLabel4.Text = "Prezime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox22, null);
                toolStripStatusLabel4.Text = "";
            }
        }

        private void textBox23_Validating(object sender, CancelEventArgs e)
        {
            if (textBox23.Text.Count() != 13)
            {
                e.Cancel = true;
                textBox23.Focus();
                errorProvider1.SetError(textBox23, "JMBG mora imati 13 karaktera");
                toolStripStatusLabel4.Text = "JMBG mora imati 13 karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox23, null);
                toolStripStatusLabel4.Text = "";
            }
        }

        


        

        private void textBox27_Validating(object sender, CancelEventArgs e)
        {
            if (textBox27.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox27.Focus();
                errorProvider1.SetError(textBox27, "Ime mora imati barem tri karaktera");
                toolStripStatusLabel3.Text = "Ime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox27, null);
                toolStripStatusLabel3.Text = "";
            }
        }

        private void textBox28_Validating(object sender, CancelEventArgs e)
        {
            if (textBox28.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox28.Focus();
                errorProvider1.SetError(textBox28, "Prezime mora imati barem tri karaktera");
                toolStripStatusLabel3.Text = "Prezime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox28, null);
                toolStripStatusLabel3.Text = "";
            }
        }

        private void textBox29_Validating(object sender, CancelEventArgs e)
        {
            if (textBox29.Text.Count() != 13)
            {
                e.Cancel = true;
                textBox29.Focus();
                errorProvider1.SetError(textBox29, "JMBG mora imati 13 karaktera");
                toolStripStatusLabel3.Text = "JMBG mora imati 13 karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox29, null);
                toolStripStatusLabel3.Text = "";
            }
        }
        

    }
}
