using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zadaca
{
    public class Doktor:Zaposlenik
    {
        int brojPregleda;
        int plataZaMjesec;
        double ukupnaPlata;
        
        public Doktor() { }
        public Doktor(string ime, string prezime, DateTime datumRodjenja,string maticniBroj,string spol,string adresaStanovanja,string bracnoStanje,DateTime zaposlenje, Ordinacija ordinacija,double plata,string plozinka):base(ime,prezime,datumRodjenja,maticniBroj,spol,adresaStanovanja,bracnoStanje,zaposlenje,ordinacija,plata,plozinka)
        {
            this.Plata = plata;
            brojPregleda = 0;
            plataZaMjesec = DateTime.Now.Month;
            ukupnaPlata = plata;
            
           
        }

        public int BrojPregleda { get => brojPregleda; set => brojPregleda = value; }
        public int PlataZaMjesec { get => plataZaMjesec; set => plataZaMjesec = value; }
        public double UkupnaPlata { get => ukupnaPlata; set => ukupnaPlata = value; }

        public void dodajPregled()
        {
            if(plataZaMjesec!=DateTime.Now.Month)
            {
                ukupnaPlata = Plata;
                brojPregleda = 0;
                plataZaMjesec = DateTime.Now.Month;
                return;
            }
            
            if (brojPregleda < 20)
            {
                ukupnaPlata += 10;
            }
            brojPregleda++;
        }
        

    }
}
