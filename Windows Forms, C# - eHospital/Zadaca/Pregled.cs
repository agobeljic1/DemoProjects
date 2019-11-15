using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca
{
    class Pregled
    {
        private string ordinacija;
        private DateTime vrijemePregleda;
        private Pacijent pregledaniPacijent;
        private Doktor nadlezniDoktor;
        private bool hitniPregled;
        private bool zavrsenPregled;
        private string zakljucakDoktora;
        private string opisPruzenePomoci;
        private Terapija propisanaTerapija;
        bool odredjenaTerapija;
        
        public DateTime VrijemePregleda { get => vrijemePregleda; set => vrijemePregleda = value; }
        
        public bool HitniPregled { get => hitniPregled; set => hitniPregled = value; }
        public bool ZavrsenPregled { get => zavrsenPregled; set => zavrsenPregled = value; }
        public string Ordinacija { get => ordinacija; set => ordinacija = value; }
        public string ZakljucakDoktora { get => zakljucakDoktora; set => zakljucakDoktora = value; }
        public string OpisPruzenePomoci { get => opisPruzenePomoci; set => opisPruzenePomoci = value; }
        internal Terapija PropisanaTerapija { get => propisanaTerapija; set => propisanaTerapija = value; }
        public Pacijent PregledaniPacijent { get => pregledaniPacijent; set => pregledaniPacijent = value; }
        public bool OdredjenaTerapija { get => odredjenaTerapija; set => odredjenaTerapija = value; }
        internal Doktor NadlezniDoktor { get => nadlezniDoktor; set => nadlezniDoktor = value; }

        public Pregled() { }
        public Pregled(string pordinacija,Doktor doca,Pacijent ppacijent,bool phitni,bool pzavrsen)
        {
            Edit(pordinacija,doca,ppacijent, phitni, pzavrsen);
        }
        
        void Edit(string pordinacija, Doktor doca, Pacijent ppacijent, bool phitni, bool pzavrsen)
        {
            ordinacija = pordinacija;
            pregledaniPacijent = ppacijent;
            HitniPregled = phitni;
            ZavrsenPregled = pzavrsen;
            nadlezniDoktor = doca;
            odredjenaTerapija = false;
            
        }
        
    }
}
