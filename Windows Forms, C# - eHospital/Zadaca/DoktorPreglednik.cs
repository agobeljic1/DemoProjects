using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Zadaca
{
    public partial class DoktorPreglednik : Form
    {
        Doktor doktor;

        public DoktorPreglednik(Doktor dokta)
        {
            doktor = dokta;
            InitializeComponent();
        }

        private void DoktorPreglednik_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.ForeColor = Color.Red;
            toolStripStatusLabel2.ForeColor = Color.Red;
            toolStripStatusLabel3.ForeColor = Color.Red;
            if (doktor != null)
              {
                  textBox10.Text = doktor.Ime;
                  textBox9.Text = doktor.Prezime;
                  dateTimePicker2.Value = doktor.DatumRodjenja;
                  textBox8.Text = doktor.AdresaStanovanja;
                  textBox1.Text = doktor.MaticniBroj;
                  comboBox3.SelectedItem = doktor.BracnoStanje;
                  comboBox2.SelectedItem = "Doktor";
                  comboBox1.SelectedItem = doktor.Spol;
                  dateTimePicker1.Value = doktor.DatumZaposlenja;
                  textBox3.Text = doktor.ZaposlenikovaOrdinacija.Odjel;
                  textBox2.Text = doktor.Plata.ToString();
                  textBox4.Text = doktor.BrojPregleda.ToString();
                  textBox5.Text = doktor.UkupnaPlata.ToString();

                  dateTimePicker2.ShowCheckBox = false;
                  dateTimePicker2.ShowUpDown = false;
                  dateTimePicker2.MinDate = doktor.DatumRodjenja;
                  dateTimePicker2.MaxDate = doktor.DatumRodjenja;

                  dateTimePicker1.ShowCheckBox = false;
                  dateTimePicker1.ShowUpDown = false;
                  dateTimePicker1.MinDate = doktor.DatumZaposlenja;
                  dateTimePicker1.MaxDate = doktor.DatumZaposlenja;

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
            groupBox10.Hide();
            groupBox11.Hide();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
        public void ThreadProc()
        {
            Klinika kl = Ulaz.odgovornaKlinika;
            Application.Run(new Ulaz(kl));
        }

        private void odjeviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
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

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string ime = textBox20.Text;
                string prezime = textBox16.Text;
                string jmbg = textBox15.Text;

                int nadjen = 0;
                foreach (Pacijent pac in Ulaz.odgovornaKlinika.ListaPacijenata)
                {
                    if (pac.Ime == ime && pac.Prezime == prezime && pac.MaticniBroj == jmbg)
                    {
                        nadjen = 1;
                        textBox24.Text = pac.KartonPacijenta.OpisBolesti;
                        textBox23.Text = pac.KartonPacijenta.ZdravstvenoStanjePorodice;
                        textBox22.Text = pac.KartonPacijenta.SadasnjeStanje;
                        textBox21.Text = pac.KartonPacijenta.ZakljucakDoktora;

                        foreach (var vakcinacija in pac.KartonPacijenta.Vakcinacije)
                        {
                            ListViewItem itm = new ListViewItem(vakcinacija.Key.ToString());
                            itm.SubItems.Add(vakcinacija.Value);
                            listView1.Items.Add(itm);

                        }
                        foreach (var alergija in pac.KartonPacijenta.Alergije)
                        {
                            ListViewItem itm = new ListViewItem(alergija.Key.ToString());
                            itm.SubItems.Add(alergija.Value);
                            listView2.Items.Add(itm);
                        }


                        foreach (var pregled in pac.KartonPacijenta.SpisakPregleda)
                        {
                            ListViewItem itm = new ListViewItem(pregled.VrijemePregleda.ToString());
                            itm.SubItems.Add(pregled.Ordinacija);
                            itm.SubItems.Add(pregled.NadlezniDoktor.Ime + " " + pregled.NadlezniDoktor.Prezime);
                            itm.SubItems.Add(pregled.ZakljucakDoktora);
                            string hitan;
                            if (pregled.HitniPregled)
                                hitan = "Da";
                            else
                                hitan = "Ne";
                            itm.SubItems.Add(hitan);
                            itm.SubItems.Add(pregled.OpisPruzenePomoci);
                            string terapija = "";
                            if (pregled.PropisanaTerapija.Lijek.Count() != 0)
                            {
                                for (int i = 0; i < pregled.PropisanaTerapija.Lijek.Count(); i++)
                                {
                                    if (i != 0)
                                        terapija += ", ";
                                    terapija += pregled.PropisanaTerapija.Lijek[i] + " " + pregled.PropisanaTerapija.BrojUnosa[i].ToString() + " " + pregled.PropisanaTerapija.RazmakUnosa[i].ToString() + " " + pregled.PropisanaTerapija.OpisUnosa[i] + " ";
                                }
                            }
                            itm.SubItems.Add(terapija);






                            listView3.Items.Add(itm);
                        }
                        break;

                    }
                }
                if (nadjen == 0)
                    MessageBox.Show("Pacijent nije pronadjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.Text = ex.Message;
            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string ime = textBox25.Text;
                string prezime = textBox27.Text;
                string jmbg = textBox26.Text;
                int nadjen = 0;
                foreach (Pregled pregled in Ulaz.odgovornaKlinika.ListaPregledaCekanja)
                {
                    if (ime == pregled.PregledaniPacijent.Ime && prezime == pregled.PregledaniPacijent.Prezime && jmbg == pregled.PregledaniPacijent.MaticniBroj && doktor.Ime + " " + doktor.Prezime == pregled.NadlezniDoktor.Ime + " " + pregled.NadlezniDoktor.Prezime && pregled.NadlezniDoktor.ZaposlenikovaOrdinacija.Odjel == doktor.ZaposlenikovaOrdinacija.Odjel)
                    {
                        nadjen = 1;
                        groupBox10.Show();
                        groupBox11.Show();
                        break;
                    }
                }
                if (nadjen == 0)
                {
                    MessageBox.Show("Pregled nije pronadjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string ime = textBox25.Text;
            string prezime = textBox27.Text;
            string jmbg = textBox26.Text;
            foreach (Pacijent pac in Ulaz.odgovornaKlinika.ListaPacijenata)
            {
                if (ime == pac.Ime && prezime == pac.Prezime && jmbg == pac.MaticniBroj)
                {
                    pac.KartonPacijenta.OpisBolesti = textBox28.Text;
                    pac.KartonPacijenta.ZdravstvenoStanjePorodice = textBox29.Text;
                    pac.KartonPacijenta.SadasnjeStanje = textBox30.Text;
                    pac.KartonPacijenta.ZakljucakDoktora = textBox31.Text;
                    break;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string ime = textBox25.Text;
            string prezime = textBox27.Text;
            string jmbg = textBox26.Text;
            
            foreach (Pregled pregled in Ulaz.odgovornaKlinika.ListaPregledaCekanja)
            {
                if (ime == pregled.PregledaniPacijent.Ime && prezime == pregled.PregledaniPacijent.Prezime && jmbg == pregled.PregledaniPacijent.MaticniBroj && doktor.Ime + " " + doktor.Prezime == pregled.NadlezniDoktor.Ime + " " + pregled.NadlezniDoktor.Prezime && pregled.NadlezniDoktor.ZaposlenikovaOrdinacija.Odjel == doktor.ZaposlenikovaOrdinacija.Odjel)
                {
                    int broj, razmak;
                    Int32.TryParse(textBox33.Text,out broj);
                    Int32.TryParse(textBox34.Text, out razmak);
                    pregled.PropisanaTerapija.Lijek.Add(textBox32.Text);
                    pregled.PropisanaTerapija.BrojUnosa.Add(broj);
                    pregled.PropisanaTerapija.RazmakUnosa.Add(razmak);
                    pregled.PropisanaTerapija.OpisUnosa.Add(textBox35.Text);
                    break;
                }
            }
        }

        private void DoktorPreglednik_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void groupBox9_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void groupBox10_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F); 
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void groupBox11_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F); 
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void tabPage3_Paint(object sender, PaintEventArgs e)
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

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void textBox25_Validating(object sender, CancelEventArgs e)
        {
            if (textBox25.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox25.Focus();
                errorProvider1.SetError(textBox25, "Ime mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Ime mora imati barem tri karaktera";

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox25, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox27_Validated(object sender, EventArgs e)
        {
            
        }

        private void textBox27_Validating(object sender, CancelEventArgs e)
        {
            if (textBox27.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox27.Focus();
                errorProvider1.SetError(textBox27, "Prezime mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Prezime mora imati barem tri karaktera";

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox27, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox26_Validating(object sender, CancelEventArgs e)
        {
            if (textBox26.Text.Count() != 13)
            {
                e.Cancel = true;
                textBox26.Focus();
                errorProvider1.SetError(textBox26, "JMBG mora imati 13 karaktera");
                toolStripStatusLabel1.Text = "JMBG mora imati 13 karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox26, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox28_Validating(object sender, CancelEventArgs e)
        {
            if (textBox28.Text.Count() ==0)
            {
                e.Cancel = true;
                textBox28.Focus();
                errorProvider1.SetError(textBox28, "Polje ne smije biti prazno");
                toolStripStatusLabel1.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox28, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox29_Validating(object sender, CancelEventArgs e)
        {
            if (textBox29.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox29.Focus();
                errorProvider1.SetError(textBox29, "Polje ne smije biti prazno");
                toolStripStatusLabel1.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox29, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox30_Validating(object sender, CancelEventArgs e)
        {
            if (textBox30.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox30.Focus();
                errorProvider1.SetError(textBox30, "Polje ne smije biti prazno");
                toolStripStatusLabel1.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox30, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox31_Validating(object sender, CancelEventArgs e)
        {
            if (textBox31.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox31.Focus();
                errorProvider1.SetError(textBox31, "Polje ne smije biti prazno");
                toolStripStatusLabel1.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox31, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox32_Validating(object sender, CancelEventArgs e)
        {
            if (textBox32.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox32.Focus();
                errorProvider1.SetError(textBox32, "Polje ne smije biti prazno");
                toolStripStatusLabel1.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox32, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox33_Validating(object sender, CancelEventArgs e)
        {
            if (textBox33.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox33.Focus();
                errorProvider1.SetError(textBox33, "Polje ne smije biti prazno");
                toolStripStatusLabel1.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox33, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox34_Validating(object sender, CancelEventArgs e)
        {
            if (textBox34.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox34.Focus();
                errorProvider1.SetError(textBox34, "Polje ne smije biti prazno");
                toolStripStatusLabel1.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox34, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox35_Validating(object sender, CancelEventArgs e)
        {
            if (textBox35.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox35.Focus();
                errorProvider1.SetError(textBox35, "Polje ne smije biti prazno");
                toolStripStatusLabel1.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox35, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox20_Validating(object sender, CancelEventArgs e)
        {
            if (textBox20.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox20.Focus();
                errorProvider1.SetError(textBox20, "Ime mora imati barem tri karaktera");
                toolStripStatusLabel2.Text = "Ime mora imati barem tri karaktera";

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox20, null);
                toolStripStatusLabel2.Text = "";
            }
        }

        private void textBox16_Validating(object sender, CancelEventArgs e)
        {
            if (textBox16.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox16.Focus();
                errorProvider1.SetError(textBox16, "Prezime mora imati barem tri karaktera");
                toolStripStatusLabel2.Text = "Prezime mora imati barem tri karaktera";

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox16, null);
                toolStripStatusLabel2.Text = "";
            }
        }

        private void textBox15_Validating(object sender, CancelEventArgs e)
        {
            if (textBox15.Text.Count() != 13)
            {
                e.Cancel = true;
                textBox27.Focus();
                errorProvider1.SetError(textBox15, "JMBG mora imati 13 karaktera");
                toolStripStatusLabel2.Text = "JMBG mora imati 13 karaktera";

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox15, null);
                toolStripStatusLabel2.Text = "";
            }
        }

        private void textBox17_Validating(object sender, CancelEventArgs e)
        {
            if (textBox17.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox17.Focus();
                errorProvider1.SetError(textBox17, "Ime mora imati barem tri karaktera");
                toolStripStatusLabel3.Text = "Ime mora imati barem tri karaktera";

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox17, null);
                toolStripStatusLabel3.Text = "";
            }
        }

        private void textBox18_Validating(object sender, CancelEventArgs e)
        {
            if (textBox18.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox18.Focus();
                errorProvider1.SetError(textBox18, "Prezime mora imati barem tri karaktera");
                toolStripStatusLabel3.Text = "Prezime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox18, null);
                toolStripStatusLabel3.Text = "";
            }
        }

        private void textBox19_Validating(object sender, CancelEventArgs e)
        {
            if (textBox19.Text.Count() !=13)
            {
                e.Cancel = true;
                textBox19.Focus();
                errorProvider1.SetError(textBox19, "JMBG mora imati 13 karaktera");
                toolStripStatusLabel3.Text = "JMBG mora imati 13 karaktera";

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox19, null);
                toolStripStatusLabel3.Text = "";
            }
        }

        private void textBox12_Validating(object sender, CancelEventArgs e)
        {
            if (textBox13.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox12.Focus();
                errorProvider1.SetError(textBox12, "Polje ne smije biti prazno");
                toolStripStatusLabel3.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox12, null);
                toolStripStatusLabel3.Text = "";
            }
        }

        private void textBox11_Validating(object sender, CancelEventArgs e)
        {
            if (textBox11.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox11.Focus();
                errorProvider1.SetError(textBox11, "Polje ne smije biti prazno");
                toolStripStatusLabel3.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox11, null);
                toolStripStatusLabel3.Text = "";
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox6.Focus();
                errorProvider1.SetError(textBox6, "Polje ne smije biti prazno");
                toolStripStatusLabel3.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox6, null);
                toolStripStatusLabel3.Text = "";
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox7.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox7.Focus();
                errorProvider1.SetError(textBox7, "Polje ne smije biti prazno");
                toolStripStatusLabel3.Text = "Polje ne smije biti prazno";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox7, null);
                toolStripStatusLabel3.Text = "";
            }
        }
    }
}
