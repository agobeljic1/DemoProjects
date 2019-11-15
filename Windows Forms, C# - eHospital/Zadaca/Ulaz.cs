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
using System.IO;
using System.Security.Cryptography;

namespace Zadaca
{

    public partial class Ulaz : Form
    {
        public static Klinika odgovornaKlinika;
        private string ime;
        private string prezime;
        private string password;
        private string potpassword;
        public Klinika OdgovornaKlinika { get => odgovornaKlinika; set => odgovornaKlinika = value; }

        public Ulaz(Klinika klinika17938)
        {
            OdgovornaKlinika = klinika17938;
            InitializeComponent();
            
            /*InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);*/

        }
        /*private void Ulaz_Paint(PaintEventArgs e)
        {
            
        }*/




        private void Ulaz_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel1.ForeColor = Color.Red;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        public void ThreadProc()
        {

            /*int a = 0;
            
            Pacijent pacijentic = new Pacijent();
            Doktor dokta = new Doktor();
            Portir porta = new Portir();
            Admin admin = new Admin();
            
                foreach (Pacijent pac in OdgovornaKlinika.ListaPacijenata)
                {
                    if (ime == pac.Ime && prezime == pac.Prezime)
                    {
                        if (password == pac.Lozinka)
                        {
                            MessageBox.Show("Logirani ste kao " + ime + " " + prezime + ".", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            a = 1;
                            pacijentic = pac;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Netacan password", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }


                    }
                }
                if (a == 0)
                {
                    foreach (Zaposlenik zap in OdgovornaKlinika.ListaZaposlenika)
                    {
                        if (ime == zap.Ime && prezime == zap.Prezime)
                        {
                            if (password == zap.Lozinka)
                            {
                                if (zap.GetType().Name == "Doktor")
                                {
                                    a = 2;
                                    dokta = zap as Doktor;
                                }
                                else
                                {
                                    a = 3;
                                    porta = zap as Portir;
                                }
                                MessageBox.Show("Logirani ste kao " + ime + " " + prezime + ".", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                break;
                            }
                            else
                            {
                                MessageBox.Show("Netacan password", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }


                        }
                    }
                }
                if (a == 0)
                {
                    foreach (Admin adm in OdgovornaKlinika.ListaAdministratora)
                    {
                        if (ime == adm.Ime && prezime == adm.Prezime)
                        {
                            if (password == adm.Lozinka)
                            {
                                MessageBox.Show("Logirani ste kao " + ime + " " + prezime + ".", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                a = 4;
                                admin = adm;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Netacan password", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }


                        }
                    }
                }
                switch (a)
                {
                    case 1:
                        Application.Run(new PacijentPreglednik(pacijentic));
                        break;
                    case 2:
                        Application.Run(new DoktorPreglednik(dokta));
                        break;
                    case 3:
                        Application.Run(new PortirPreglednik(porta));
                        break;
                    case 4:
                        Application.Run(new AdminPreglednik(admin));
                        break;
                    default:
                        MessageBox.Show("Neuspjesan login", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }


            return a;*/
        }  
        public void obrisi()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public void button1_Click(object sender, EventArgs e)
        {
            

            toolStripStatusLabel1.ForeColor = Color.Red;
            int a = 0;
            try
            {
                Pacijent pacijentic = new Pacijent();
                Doktor dokta = new Doktor();
                Portir porta = new Portir();
                Admin admin = new Admin();

                Osoba osoba = new Osoba(textBox1.Text, textBox2.Text, textBox3.Text);
                /*validIme(ime);
                validPrezime(prezime);
                validPassword(password);*/
                foreach (Pacijent pac in OdgovornaKlinika.ListaPacijenata)
                {
                    if (ime == pac.Ime && prezime == pac.Prezime)
                    {
                        if (password == pac.Lozinka)
                        {
                            MessageBox.Show("Logirani ste kao " + ime + " " + prezime + ".", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            a = 1;
                            pacijentic = pac;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Netacan password", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                    }
                }
                if (a == 0)
                {
                    foreach (Zaposlenik zap in OdgovornaKlinika.ListaZaposlenika)
                    {
                        if (ime == zap.Ime && prezime == zap.Prezime)
                        {
                            if (password == zap.Lozinka)
                            {
                                if (zap.GetType().Name == "Doktor")
                                {
                                    a = 2;
                                    dokta = zap as Doktor;
                                }
                                else
                                {
                                    a = 3;
                                    porta = zap as Portir;
                                }
                                MessageBox.Show("Logirani ste kao " + ime + " " + prezime + ".", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                break;
                            }
                            else
                            {
                                MessageBox.Show("Netacan password", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }


                        }
                    }
                }
                if (a == 0)
                {
                    foreach (Admin adm in OdgovornaKlinika.ListaAdministratora)
                    {
                        if (ime == adm.Ime && prezime == adm.Prezime)
                        {
                            if (password == adm.Lozinka)
                            {
                                MessageBox.Show("Logirani ste kao " + ime + " " + prezime + ".", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                a = 4;
                                admin = adm;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Netacan password", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }


                        }
                    }
                }
                switch (a)
                {
                    case 1:
                        PacijentPreglednik f1 = new PacijentPreglednik(pacijentic); f1.Show();
                        /*Application.Run(new PacijentPreglednik(pacijentic));*/
                        break;
                    case 2:
                        DoktorPreglednik f2 = new DoktorPreglednik(dokta); f2.Show();
                        /*Application.Run(new DoktorPreglednik(dokta));*/
                        break;
                    case 3:
                        PortirPreglednik f3 = new PortirPreglednik(porta); f3.Show();
                        /*Application.Run(new PortirPreglednik(porta));*/
                        break;
                    case 4:
                        AdminPreglednik f4 = new AdminPreglednik(admin); f4.Show();
                        /*Application.Run(new AdminPreglednik(admin));*/
                        break;
                    case 0:
                        MessageBox.Show("Neuspjesan login", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
                if (a != 0)
                    Hide();
                else
                    obrisi();
                toolStripStatusLabel1.ForeColor = Color.Black;
            }
            catch(Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }



            /*System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            Close();  */

        }


        private void Ulaz_Paint(object sender, PaintEventArgs e)
        {
            Rectangle BaseRectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Brush Gradient_Brush = new System.Drawing.Drawing2D.LinearGradientBrush(BaseRectangle, Color.Navy, Color.LightSlateGray, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(Gradient_Brush, BaseRectangle);
        }

        private void Ulaz_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            prezime = textBox2.Text;
        }

   
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ime = textBox1.Text;
        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            password = CalculateMD5Hash(textBox3.Text);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
        public string CalculateMD5Hash(string input)

        {

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void toolStripStatusLabel1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            potpassword = CalculateMD5Hash(textBox4.Text);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(textBox1.Text.Count()<3)
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1,"Ime mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Ime mora imati barem tri karaktera";
                
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider1.SetError(textBox2, "Prezime mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Prezime mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider1.SetError(textBox3, "Password mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Password mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox3, null);
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text.Count() < 3)
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider1.SetError(textBox4, "Password mora imati barem tri karaktera");
                toolStripStatusLabel1.Text = "Password mora imati barem tri karaktera";
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox4, null);
                toolStripStatusLabel1.Text = "";
                if(textBox3.Text.Count()>0 && textBox3.Text!= textBox4.Text)
                {
                    e.Cancel = false;
                    textBox3.Focus();
                    errorProvider1.SetError(textBox4, "Passwordi se ne poklapaju");
                    toolStripStatusLabel1.Text = "Passwordi se ne poklapaju";
                }                
            }
            
        }

        private void Ulaz_Paint_1(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.LightCyan, 90F);  // Opaque blue


            e.Graphics.FillRectangle(linGrBrush, this.ClientRectangle);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {

            Graphics obj = groupBox1.CreateGraphics();
            
            Brush black = new SolidBrush(Color.Black);
            Point[] polygonTacke1 = new Point[3];
            Point p = new Point(315, 75);
            Brush br1 = new LinearGradientBrush(this.ClientRectangle, Color.Orange, Color.Green, 90F);
            Brush br2 = new LinearGradientBrush(this.ClientRectangle, Color.White, Color.Black, 90F);
            Brush br= new LinearGradientBrush(this.ClientRectangle, Color.LightPink, Color.Purple, 90F);
            Pen plinear = new Pen(br, 5);
            Pen redpen = new Pen(br1, 8);
            Pen bluepen = new Pen(br2, 8);
            polygonTacke1[0] = new Point(330, 40);
            polygonTacke1[1] = new Point(300, 100);
            polygonTacke1[2] = new Point(360, 100);
            obj.DrawEllipse(redpen, 275, 20, 110, 110);
            obj.DrawPolygon(bluepen, polygonTacke1);
            obj.DrawString("NMK",this.Font, black, p);
            obj.DrawRectangle(plinear, 260, 13, 140, 127);
            
        }

        private void izadjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
