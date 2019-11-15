using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zadaca
{
    public partial class Pacijent:Osoba
    {
        
        private DateTime datumPrijema;
        private int brojPosjeta;
        private Karton kartonPacijenta=new Karton();
        private bool imaLiKarton;
        bool isplacenPregled;
        Pregled zadnjiPregled=new Pregled();
        private Image slika;
        

        public bool IsplacenPregled { get => isplacenPregled; set => isplacenPregled = value; }
        internal Pregled ZadnjiPregled { get => zadnjiPregled; set => zadnjiPregled = value; }
        public Image Slika { get => slika; set => slika = value; }

        public Pacijent(string pime, string pprezime, DateTime pdatumRodjenja, string pmaticniBroj, string pspol, string padresa, string pstanje, Dictionary<DateTime,string> vakcinacije, Dictionary<DateTime,string> alergije,string plozinka,Image slikica):base(pime,pprezime,pdatumRodjenja,pmaticniBroj,pspol,padresa,pstanje,plozinka)
        {
            this.Ime = pime;
            this.Prezime = pprezime;
            this.DatumRodjenja = pdatumRodjenja;
            this.MaticniBroj = pmaticniBroj;
            this.Spol = pspol;
            this.AdresaStanovanja = padresa;
            this.BracnoStanje = pstanje;
            this.DatumPrijema = DateTime.Now;
            brojPosjeta = 0;
            KartonPacijenta.Alergije = alergije;
            KartonPacijenta.Vakcinacije = vakcinacije;
            imaLiKarton = false;
            Slika = slikica;
            isplacenPregled = true;
        }
        public Pacijent(string pime, string pprezime, DateTime pdatumRodjenja, string pmaticniBroj, string pspol, string padresa, string pstanje, string plozinka, Image slikica) : base(pime, pprezime, pdatumRodjenja, pmaticniBroj, pspol, padresa, pstanje, plozinka)
        {
            this.Ime = pime;
            this.Prezime = pprezime;
            this.DatumRodjenja = pdatumRodjenja;
            this.MaticniBroj = pmaticniBroj;
            this.Spol = pspol;
            this.AdresaStanovanja = padresa;
            this.BracnoStanje = pstanje;
            this.DatumPrijema = DateTime.Now;
            brojPosjeta = 0;            
            imaLiKarton = false;
            Slika = slikica;
            isplacenPregled = true;


        }

        public Pacijent()
        {
            datumPrijema = DateTime.Now;
            imaLiKarton = false;
            isplacenPregled = true;
        }

        public Pacijent(string spol)
        {
            this.DatumPrijema = DateTime.Now;
            imaLiKarton = false;
            this.Spol = spol;
            isplacenPregled = true;
        }
        public void DodajPregled(int index,int redni)
        {
            /*if (karton.ListaCekanja.Count == 0)*/
                kartonPacijenta.ListaCekanja.Add(index);            
            /*else
            {
                int brojac = 0; 
                foreach (Ordinacija ord in Klinika.ListaOrdinacija)
                {


                    if (Klinika.ListaPregledaCekanja[Karton.ListaCekanja[index]].Ordinacija==ord.Odjel && (!ord.PrisutanDoktor || !ord.Aparat))
                    {
                        karton.ListaCekanja.Insert(index,0);
                        break;
                    }
                    else
                    {
                        
                        int pomocni = -1;
                        foreach(Pregled pregled in Klinika.ListaPregledaCekanja)
                        {
                            if (pregled.Ordinacija == ord.Odjel)
                                pomocni++;
                        }
                        karton.ListaCekanja.Add(index,karton.ListaCekanja.Count-pomocni);
                    }


                }
                        
            }*/
        }
        

        
    }  
           


    

       
    
}
