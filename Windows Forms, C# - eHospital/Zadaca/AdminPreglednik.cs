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
using System.Drawing.Drawing2D;

namespace Zadaca
{
    public partial class AdminPreglednik : Form
    {
        
        Admin adm=new Admin();
        public AdminPreglednik(Admin padm)
        {
            adm = padm;
            
            InitializeComponent();
        }

        

        private void AdminPreglednik_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.ForeColor = Color.Red;
            toolStripStatusLabel2.ForeColor = Color.Red;
            

            if (adm != null)
              {
                  textBox10.Text = adm.Ime;
                  textBox9.Text = adm.Prezime;
                  dateTimePicker2.Value = adm.DatumRodjenja;
                  dateTimePicker2.ShowCheckBox = false;
                  dateTimePicker2.ShowUpDown = false;                 
                  dateTimePicker2.MinDate = adm.DatumRodjenja;
                  dateTimePicker2.MaxDate = adm.DatumRodjenja;
                  dateTimePicker1.Value = adm.DatumZaposlenja;
                  dateTimePicker1.ShowCheckBox = false;
                  dateTimePicker1.ShowUpDown = false;
                  dateTimePicker1.MinDate = adm.DatumZaposlenja;
                  dateTimePicker1.MaxDate = adm.DatumZaposlenja;
                  textBox8.Text = adm.AdresaStanovanja;
                  textBox1.Text = adm.MaticniBroj;
                  comboBox3.SelectedItem = adm.BracnoStanje;
                  comboBox2.SelectedItem = "Administrator";
                  comboBox1.SelectedItem = adm.Spol;                            
                  textBox2.Text = adm.Plata.ToString();

                treeView1.Nodes.Add("Pacijenti");
                treeView1.Nodes.Add("Doktori");
                treeView1.Nodes.Add("Portiri");
                treeView1.Nodes.Add("Administratori");
                foreach (Pacijent pacijent in Ulaz.odgovornaKlinika.ListaPacijenata)
                {
                    treeView1.Nodes[0].Nodes.Add(pacijent.Ime+" "+pacijent.Prezime);
                }
                foreach (Zaposlenik doktor in Ulaz.odgovornaKlinika.ListaZaposlenika)
                {
                    if(doktor.GetType().Name=="Doktor")
                    treeView1.Nodes[1].Nodes.Add(doktor.Ime + " " + doktor.Prezime);
                }
                foreach (Zaposlenik portir in Ulaz.odgovornaKlinika.ListaZaposlenika)
                {
                    if (portir.GetType().Name == "Portir")
                        treeView1.Nodes[2].Nodes.Add(portir.Ime + " " + portir.Prezime);
                }
                foreach (Admin admin in Ulaz.odgovornaKlinika.ListaAdministratora)
                {
                    treeView1.Nodes[3].Nodes.Add(admin.Ime + " " + admin.Prezime);
                }

            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox9.Text = "";
            dateTimePicker2.Value = DateTime.Now;
            textBox8.Text = "";
            textBox1.Text = "";
            comboBox3.SelectedItem = "";
            comboBox2.SelectedItem = "";
            comboBox1.SelectedItem = "";
            dateTimePicker1.Value = DateTime.Now;
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*moram to azurirati*********************************************************************/
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string ime = textBox7.Text;
                string prezime = textBox6.Text;
                string jmbg = textBox3.Text;
                string grupa = comboBox5.SelectedItem.ToString();


                switch (grupa)
                {
                    case "Pacijent":
                        int nadjen = 0;
                        foreach (Pacijent pac in Ulaz.odgovornaKlinika.ListaPacijenata)
                        {
                            if (pac.Ime == ime && pac.Prezime == prezime && jmbg == pac.MaticniBroj)
                            {
                                nadjen = 1;
                                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni?", "Brisanje pacijenta", MessageBoxButtons.YesNo);
                                switch (dialogResult)
                                {
                                    case DialogResult.Yes:
                                        Ulaz.odgovornaKlinika.ListaPacijenata.Remove(pac);
                                        MessageBox.Show("Izbrisali ste pacijenta: " + ime + " " + prezime + " JMBG: " + jmbg, "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    case DialogResult.No: break;
                                }
                                break;
                            }

                        }
                        if (nadjen == 0)
                            MessageBox.Show("Pacijent nije pronadjen", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    case "Doktor":
                        nadjen = 0;
                        foreach (Zaposlenik zap in Ulaz.odgovornaKlinika.ListaZaposlenika)
                        {
                            if (zap.Ime == ime && zap.Prezime == prezime && jmbg == zap.MaticniBroj && zap.GetType().Name == "Doktor")
                            {
                                nadjen = 1;
                                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni?", "Brisanje doktora", MessageBoxButtons.YesNo);
                                switch (dialogResult)
                                {
                                    case DialogResult.Yes:
                                        Ulaz.odgovornaKlinika.ListaZaposlenika.Remove(zap);
                                        MessageBox.Show("Izbrisali ste doktora: " + ime + " " + prezime + " JMBG: " + jmbg, "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    case DialogResult.No: break;
                                }
                                break;
                            }

                        }
                        if (nadjen == 0)
                            MessageBox.Show("Doktor nije pronadjen", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;

                    case "Portir":
                        nadjen = 0;
                        foreach (Zaposlenik zap in Ulaz.odgovornaKlinika.ListaZaposlenika)
                        {
                            if (zap.Ime == ime && zap.Prezime == prezime && jmbg == zap.MaticniBroj && zap.GetType().Name == "Portir")
                            {
                                nadjen = 1;
                                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni?", "Brisanje portira", MessageBoxButtons.YesNo);
                                switch (dialogResult)
                                {
                                    case DialogResult.Yes:
                                        Ulaz.odgovornaKlinika.ListaZaposlenika.Remove(zap);
                                        MessageBox.Show("Izbrisali ste portira: " + ime + " " + prezime + " JMBG: " + jmbg, "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    case DialogResult.No: break;
                                }
                                break;
                            }

                        }
                        if (nadjen == 0)
                            MessageBox.Show("Portir nije pronadjen", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;

                    case "Administrator":
                        nadjen = 0;
                        foreach (Admin admin in Ulaz.odgovornaKlinika.ListaAdministratora)
                        {

                            if (admin.Ime == ime && admin.Prezime == prezime && jmbg == admin.MaticniBroj)
                            {
                                if (admin == adm)
                                {
                                    MessageBox.Show("Akciju nije moguce izvrsiti", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    nadjen = -1;
                                    break;
                                }
                                nadjen = 1;
                                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni?", "Brisanje administratora", MessageBoxButtons.YesNo);
                                switch (dialogResult)
                                {
                                    case DialogResult.Yes:
                                        Ulaz.odgovornaKlinika.ListaAdministratora.Remove(admin);
                                        MessageBox.Show("Izbrisali ste administratora: " + ime + " " + prezime + " JMBG: " + jmbg, "Obavjestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    case DialogResult.No: break;
                                }
                                break;
                            }

                        }
                        if (nadjen == 0)
                            MessageBox.Show("Administrator nije pronadjen", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;

                    default:
                        MessageBox.Show("Neispravan unos", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }


            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Obrisi()
        {
            textBox16.Text = "";
            textBox15.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox12.Text = "";
            dateTimePicker4.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            comboBox6.SelectedItem = "";
            comboBox7.SelectedItem = "";
            comboBox8.SelectedItem = "";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Obrisi();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.Text = ex.Message;
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
        }
            private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<DateTime, string> v = new Dictionary<DateTime, string>();
                string ime = textBox16.Text;
                string prezime = textBox15.Text;
                string jmbg = textBox13.Text;
                string a = "";
                string sifra = ime[0] + prezime[0] + prezime[1] + a;
                for (int i = 0; i < 7; i++)
                    sifra += jmbg[i];
                sifra = sifra.ToUpper();

                switch (comboBox7.SelectedItem.ToString())
                {

                    case "Administrator":
                        double plata;
                        double.TryParse(textBox12.Text, out plata);
                        Admin adm = new Admin(textBox16.Text, textBox15.Text, dateTimePicker4.Value, textBox13.Text, comboBox8.SelectedItem.ToString(), textBox14.Text, comboBox6.SelectedItem.ToString(), dateTimePicker4.Value, plata, sifra);
                        Ulaz.odgovornaKlinika.ListaAdministratora.Add(adm);
                        MessageBox.Show("Administrator uspjesno registrovan", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Obrisi();
                        break;
                    case "Doktor":

                        double.TryParse(textBox12.Text, out plata);
                        string ord = comboBox9.SelectedItem.ToString();
                        Ordinacija ordinacija = new Ordinacija();
                        int nadjen = 0;
                        foreach (Ordinacija or in Ulaz.odgovornaKlinika.ListaOrdinacija)
                        {
                            if (or.Odjel == ord)
                            {
                                ordinacija = or;
                                nadjen = 1;
                                break;
                            }
                        }
                        if (nadjen == 0)
                        {
                            MessageBox.Show("Ordinacija nije pronadjena", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        Doktor dok = new Doktor(textBox16.Text, textBox15.Text, dateTimePicker4.Value, textBox13.Text, comboBox8.SelectedItem.ToString(), textBox14.Text, comboBox6.SelectedItem.ToString(), dateTimePicker4.Value, ordinacija, plata, sifra);
                        Ulaz.odgovornaKlinika.ListaZaposlenika.Add(dok);
                        MessageBox.Show("Doktor uspjesno registrovan", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Obrisi();
                        break;
                    case "Portir":
                        ordinacija = new Ordinacija();
                        nadjen = 0;
                        ord = comboBox9.SelectedText;
                        foreach (Ordinacija or in Ulaz.odgovornaKlinika.ListaOrdinacija)
                        {
                            if (or.Odjel == ord)
                            {
                                ordinacija = or;
                                nadjen = 1;
                                break;
                            }
                        }
                        if (nadjen == 0)
                        {
                            MessageBox.Show("Ordinacija nije pronadjena", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        double.TryParse(textBox12.Text, out plata);
                        Portir por = new Portir(textBox16.Text, textBox15.Text, dateTimePicker4.Value, textBox13.Text, comboBox8.SelectedItem.ToString(), textBox14.Text, comboBox6.SelectedItem.ToString(), dateTimePicker4.Value, ordinacija, plata, sifra);
                        Ulaz.odgovornaKlinika.ListaZaposlenika.Add(por);
                        MessageBox.Show("Portir uspjesno registrovan", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Obrisi();
                        break;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.Text = ex.Message;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AnalizaSadrzaja forma = new AnalizaSadrzaja(1);
            forma.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AnalizaSadrzaja forma = new AnalizaSadrzaja(2);
            forma.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnalizaSadrzaja forma = new AnalizaSadrzaja(3);
            forma.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
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

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
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

        private void tabPage3_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);
            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox7.Text.Count() <3)
            {
                e.Cancel = true;
                textBox7.Focus();
                errorProvider1.SetError(textBox7, "Ime mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Ime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox7, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text.Count() <3)
            {
                e.Cancel = true;
                textBox6.Focus();
                errorProvider1.SetError(textBox6, "Prezime mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Prezime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox6, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Count() == 0)
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider1.SetError(textBox3, "Ime mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Ime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox3, null);
                toolStripStatusLabel1.Text = "";
            }
        }

     

        private void textBox16_Validating(object sender, CancelEventArgs e)
        {
            if (textBox16.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox16.Focus();
                errorProvider1.SetError(textBox16, "Ime mora imati barem tri karaktera");
                toolStripStatusLabel2.Text = "Ime mora imati barem tri karaktera";
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
            if (textBox15.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox15.Focus();
                errorProvider1.SetError(textBox15, "Prezime mora imati barem tri karaktera");
                toolStripStatusLabel2.Text = "Prezime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox15, null);
                toolStripStatusLabel2.Text = "";
            }
        }

        private void textBox13_Validating(object sender, CancelEventArgs e)
        {
            if (textBox13.Text.Count() != 13)
            {
                e.Cancel = true;
                textBox13.Focus();
                errorProvider1.SetError(textBox13, "JMBG mora imati 13 karaktera");
                toolStripStatusLabel2.Text = "JMBG mora imati 13 karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox13, null);
                toolStripStatusLabel2.Text = "";
            }
        }

        
    }
}
