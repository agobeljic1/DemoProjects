using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zadaca
{
    public class Portir : Zaposlenik
    {
        public Portir(string ime, string prezime, DateTime datumRodjenja, string maticniBroj, string spol, string adresaStanovanja, string bracnoStanje, DateTime zaposlenje, Ordinacija ordinacija, double plata,string plozinka) : base(ime,  prezime,  datumRodjenja,maticniBroj,spol,adresaStanovanja,bracnoStanje,zaposlenje,ordinacija,plata,plozinka)
        {
        }
        public Portir()
        {

        }
    }
}
