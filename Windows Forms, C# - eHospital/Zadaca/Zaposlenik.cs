using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zadaca
{
    public abstract class Zaposlenik:Osoba
    {
        private DateTime datumZaposlenja;
        private double plata;
        private Ordinacija zaposlenikovaOrdinacija;
        

        public Zaposlenik() { }
        public Zaposlenik(string ime, string prezime, DateTime datumRodjenja, string maticniBroj, string spol, string adresaStanovanja, string bracnoStanje,DateTime zaposlenje,Ordinacija ordinacija,double plata,string plozinka): base(ime, prezime, datumRodjenja, maticniBroj, spol, adresaStanovanja, bracnoStanje,plozinka)
        {
            DatumZaposlenja = zaposlenje;
            this.plata = plata;
            zaposlenikovaOrdinacija = ordinacija;
            
        }
        public DateTime DatumZaposlenja { get => datumZaposlenja; set => datumZaposlenja = value; }
        public double Plata { get => plata; set => plata = value; }
        public Ordinacija ZaposlenikovaOrdinacija { get => zaposlenikovaOrdinacija; set => zaposlenikovaOrdinacija = value; }

       
    }
}
