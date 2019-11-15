using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca
{
    public class Admin:Osoba
    {
        DateTime datumZaposlenja;
        double plata;

        public DateTime DatumZaposlenja { get => datumZaposlenja; set => datumZaposlenja = value; }
        public double Plata { get => plata; set => plata = value; }

        public Admin(string ime, string prezime, DateTime datumRodjenja, string maticniBroj, string spol, string adresaStanovanja, string bracnoStanje, DateTime zaposlenje,double pplata,string plozinka):base(ime,prezime,datumRodjenja,maticniBroj,spol,adresaStanovanja,bracnoStanje,plozinka)
        {
            datumZaposlenja = zaposlenje;
            plata = pplata;

        }
        public Admin() 
        {
            datumZaposlenja = DateTime.Now;
        }
    }
}
