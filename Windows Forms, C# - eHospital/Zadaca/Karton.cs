using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca
{
    sealed class Karton
    {


        private Dictionary<DateTime, string> vakcinacije = new Dictionary<DateTime, string>();
        private Dictionary<DateTime, string> alergije = new Dictionary<DateTime, string>();

        private List<Pregled> spisakPregleda = new List<Pregled>();
        private List<int> listaCekanja = new List<int>();
        
        private string opisBolesti;
        private string zdravstvenoStanjePorodice;
        private string sadasnjeStanje;
        private string zakljucakDoktora;
        
        public Karton() {  }
        
        public List<Pregled> SpisakPregleda { get => spisakPregleda; set => spisakPregleda = value; }
        
        public string OpisBolesti { get => opisBolesti; set => opisBolesti = value; }
        public string ZdravstvenoStanjePorodice { get => zdravstvenoStanjePorodice; set => zdravstvenoStanjePorodice = value; }
        public string SadasnjeStanje { get => sadasnjeStanje; set => sadasnjeStanje = value; }
        public string ZakljucakDoktora { get => zakljucakDoktora; set => zakljucakDoktora = value; }
        public List<int> ListaCekanja { get => listaCekanja; set => listaCekanja = value; }
        public Dictionary<DateTime, string> Vakcinacije { get => vakcinacije; set => vakcinacije = value; }
        public Dictionary<DateTime, string> Alergije { get => alergije; set => alergije = value; }
    }
}
