using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;


namespace Zadaca
{
    public class Klinika:IKlinika
    {
        private int godinaOsnivanja = 2001;
        private string adminSifra;
        private List<Ordinacija> listaOrdinacija= new List<Ordinacija>();
        private List<Pacijent> listaPacijenata=new List<Pacijent>();
        private List<Zaposlenik> listaZaposlenika = new List<Zaposlenik>();
        private List<Pregled> listaPregledaCekanja=new List<Pregled>();
        private List<Admin> listaAdministratora = new List<Admin>();

        public Klinika(string padminSifra)
        {
            adminSifra = CalculateMD5Hash(padminSifra);
        }

        public int GodinaOsnivanja { get => godinaOsnivanja; set => godinaOsnivanja = value; }
        public List<Ordinacija> ListaOrdinacija { get => listaOrdinacija; set => listaOrdinacija = value; }
        public List<Pacijent> ListaPacijenata { get => listaPacijenata; set => listaPacijenata = value; }
        internal List<Zaposlenik> ListaZaposlenika { get => listaZaposlenika; set => listaZaposlenika = value; }
        internal List<Pregled> ListaPregledaCekanja  { get => listaPregledaCekanja; set => listaPregledaCekanja = value; }
        public string AdminSifra { get => adminSifra;  }
        internal List<Admin> ListaAdministratora { get => listaAdministratora; set => listaAdministratora = value; }

        public int ZakaziNoviPregled(int ordinacija,Pacijent pacijent)
        {
            
            string[] lista = { "Hitna", "Opsta", "Ortopedija", "Kardiologija", "Dermatologija", "Internistika", "Otorinolaringologija", "Oftamologija", "Laboratorija", "Stomatologija", "Hirurgija","Patologija" };
            Doktor doca =listaZaposlenika[2] as Doktor;
            foreach(Ordinacija ord in ListaOrdinacija)
            {
                if (ord.Odjel == lista[ordinacija])
                {
                    doca = ord.OdgovorniDoktor;
                    break;
                }
            }
            Pregled pregled = new Pregled(lista[ordinacija],doca, pacijent,ordinacija==0, false);
            int broj = ListaPregledaCekanja.Count;
            int brojac = 0;
            foreach(Pregled a in ListaPregledaCekanja)
            {
                if (lista[ordinacija] == a.Ordinacija)
                    brojac++;
            }
            pregled.NadlezniDoktor = doca;
            pregled.NadlezniDoktor.ZaposlenikovaOrdinacija = doca.ZaposlenikovaOrdinacija;
            ListaPregledaCekanja.Add(pregled);
            
            pacijent.DodajPregled(broj,brojac);
            return brojac;
        }

        public void DodajDoktora(string ime, string prezime, DateTime datumRodjenja, string maticniBroj, string spol, string adresaStanovanja, string bracnoStanje, DateTime zaposlenje, Ordinacija ordinacija, double plata,string lozinka)
        {
            Doktor noviDoktor = new Doktor(ime, prezime, datumRodjenja, maticniBroj, spol, adresaStanovanja, bracnoStanje, zaposlenje, ordinacija, plata,lozinka);
            ordinacija.OdgovorniDoktor = noviDoktor;           
            ListaZaposlenika.Add(noviDoktor);
        }
        
        public int RegistrirajNovogPacijenta(string pime, string pprezime, DateTime pdatumRodjenja, string pmaticniBroj, string pspol, string padresa, string pstanje,Dictionary<DateTime,string> vakcinacije, Dictionary<DateTime,string> alergije,string plozinka,Image slikica)
        {
            
            Pacijent pacijent = new Pacijent(pime, pprezime,pdatumRodjenja,pmaticniBroj,pspol,padresa,pstanje,vakcinacije,alergije,plozinka,slikica);
            listaPacijenata.Add(pacijent);
            return listaPacijenata.Count-1; 
        }
        
        public void ObrisiPacijenta(string pime,string pprezime,string pmaticniBroj)
        {
            int index = 0;
            foreach (var pacijent in listaPacijenata)
            {
                if (pacijent.Ime == pime && pacijent.Prezime == pprezime && pacijent.MaticniBroj == pmaticniBroj)
                {
                    listaPacijenata.RemoveAt(index);
                    break;
                }
                index++;
            }
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

        /*public int ProvjeriKorisnika(string pime,string pprezime,string psifra,int pkljuc)
        {
            
            switch (pkljuc)
            {
                case 1:
                    {
                        if(CalculateMD5Hash(psifra)!=sifraDoktora)
                        {
                            return -1;
                        }
                        foreach (Ordinacija ord in ListaOrdinacija)
                        {
                            if(ord.OdgovorniDoktor.Ime==pime && ord.OdgovorniDoktor.Prezime == pprezime)
                            {
                                return 1;
                            }
                        }
                        return 0;
                    }
                case 2:
                    {
                        if (CalculateMD5Hash(psifra) != sifraOsoblja)
                        {
                            return -1;
                        }
                        foreach (Zaposlenik zaposleni in ListaZaposlenika)
                        {
                            if (zaposleni.Ime == pime && zaposleni.Prezime == pprezime)
                            {
                                return 1;
                            }
                        }
                        return 0;
                    }
                case 3:
                    {
                        if (CalculateMD5Hash(psifra) != sifraPacijenta)
                        {
                            return -1;
                        }
                        foreach (Pacijent pacijent in ListaPacijenata)
                        {
                            if (pacijent.Ime == pime && pacijent.Prezime == pprezime)
                            {
                                return 1;
                            }
                        }
                        return 0;                        
                    }
                default:
                    break;
            }
            return 7;



        }*/

    }
}
