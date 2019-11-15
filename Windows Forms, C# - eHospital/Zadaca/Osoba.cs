using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;

namespace Zadaca
{
    public class Osoba
    {
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private string maticniBroj;
        private string spol;
        private string adresaStanovanja;
        private string bracnoStanje;
        private string lozinka;
        

        public Osoba() { }
        public Osoba(string pime,string pprezime,DateTime pdatumRodjenja,string pmaticniBroj,string pspol,string padresaStanovanja,string pbracnoStanje,string plozinka)
        {
            ime = pime;
            prezime = pprezime;
            datumRodjenja = pdatumRodjenja;
            maticniBroj = pmaticniBroj;
            spol = pspol;
            adresaStanovanja = padresaStanovanja;
            bracnoStanje = pbracnoStanje;
            
            lozinka = CalculateMD5Hash(plozinka);

        }
        public Osoba(string pime, string pprezime, string plozinka)
        {
            ime = pime;
            prezime = pprezime;            
            lozinka = CalculateMD5Hash(plozinka);

        }


        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string MaticniBroj { get => maticniBroj; set => maticniBroj = value; }
        public string Spol { get => spol; set => spol = value; }
        public string AdresaStanovanja { get => adresaStanovanja; set => adresaStanovanja = value; }
        public string BracnoStanje { get => bracnoStanje; set => bracnoStanje = value; }
        public string Lozinka { get => lozinka; set => PostaviLozinku(value); }
        

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
        void PostaviLozinku(string lozinka)
        {

        }
    }
}
