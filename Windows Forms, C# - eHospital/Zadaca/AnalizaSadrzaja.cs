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
    public partial class AnalizaSadrzaja : Form
    {
        int a;
        public AnalizaSadrzaja(int pa)
        {
            a = pa;
            InitializeComponent();
            chart1.Hide();            
            chart2.Hide();
            chart3.Hide();
        }

        private void AnalizaSadrzaja_Load(object sender, EventArgs e)
        {
               
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (a)
            {
                case 1:
                    chart1.Show();
                    a = 0;
                    foreach (Ordinacija ordinacija in Ulaz.odgovornaKlinika.ListaOrdinacija)
                    {
                        int broj = 0;
                        foreach (Pregled pregled in Ulaz.odgovornaKlinika.ListaPregledaCekanja)
                        {
                            if (pregled.Ordinacija == ordinacija.Odjel)
                            {
                                broj++;
                            }
                        }
                        chart1.Series["Ordinacija sa najvecim redom cekanja"].Points.AddXY(ordinacija.Odjel, broj);
                    }
                    break;
                case 2:
                    a = 0;
                    chart2.Show();
                    string[] mjeseci = { "Januar", "Februar", "Mart", "April", "Maj", "Juni", "Juli", "August", "Septembar", "Oktobar", "Novembar", "Decembar" };
                    
                    int[] ucestalost = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    foreach (Pacijent pacijent in Ulaz.odgovornaKlinika.ListaPacijenata)
                    {
                        foreach (Pregled pregled in pacijent.KartonPacijenta.SpisakPregleda)
                        {
                            ucestalost[pregled.VrijemePregleda.Month - 1]++;
                        }
                    }


                    for (int i = 0; i < 12; i++)
                    {
                        if (DateTime.Now.Month > i + 1)
                            mjeseci[i] += " 2017";
                        else
                            mjeseci[i] += " 2016";
                        chart2.Series["Najprometniji mjesec ove godine"].Points.AddXY(mjeseci[i], ucestalost[i]);
                    }

                    break;
                case 3:
                    a = 0;
                    chart3.Show(); ;
                    foreach (Pacijent pacijent in Ulaz.odgovornaKlinika.ListaPacijenata)
                    {
                        int multi = 0;
                        foreach (Pacijent pac in Ulaz.odgovornaKlinika.ListaPacijenata)
                        {
                            if (pacijent.Prezime == pac.Prezime)
                            {
                                multi++;
                            }
                        }
                        chart3.Series["Najcesce prezime pacijenta"].Points.AddXY(pacijent.Prezime, multi);
                    }

                    break;
                default:
                    break;
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
