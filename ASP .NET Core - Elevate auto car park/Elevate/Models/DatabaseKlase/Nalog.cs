using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Elevate.Models.DatabaseKlase;

namespace Elevate.Models
{
    public class Nalog
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Datum početka najma")]
        public DateTime VrijemePocetak { get; set; }
        [Display(Name = "Datum završetka najma")]
        public DateTime VrijemeKraj { get; set; }

        [Display(Name = "Polazna lokacija")]
        public string PolaznaLokacija { get; set; }
        [Display(Name = "Dolazna lokacija")]
        public string DolaznaLokacija { get; set; }
        [Display(Name = "Ime i prezime vozača")]
        public string ImePrezimeVozaca { get; set; }
        [Display(Name = "Broj putnika u automobilu")]
        public int BrojPutnikaUAutomobilu { get; set; }
        [Display(Name = "Status naloga")]
        public virtual NalogStatus NalogStatus { get; set; }
        [Display(Name = "Automobil")]
        public virtual Auto Auto { get; set; }

        public Nalog() { }

        public Nalog(int id)
        {
            Id = id;
        }

        public Nalog(int id, DateTime vrijemePocetak, DateTime vrijemeKraj, string polaznaLokacija, string dolaznaLokacija, string imePrezimeVozaca, int brojPutnikaUAutomobilu, NalogStatus nalogStatus, Auto auto)
        {
            Id = id;
            VrijemePocetak = vrijemePocetak;
            VrijemeKraj = vrijemeKraj;
            PolaznaLokacija = polaznaLokacija;
            DolaznaLokacija = dolaznaLokacija;
            ImePrezimeVozaca = imePrezimeVozaca;
            BrojPutnikaUAutomobilu = brojPutnikaUAutomobilu;
            NalogStatus = nalogStatus;
            Auto = auto;
        }

        public Nalog(DateTime vrijemePocetak, DateTime vrijemeKraj, string polaznaLokacija, string dolaznaLokacija, string imePrezimeVozaca, int brojPutnikaUAutomobilu, NalogStatus nalogStatus, Auto auto)
        {
            VrijemePocetak = vrijemePocetak;
            VrijemeKraj = vrijemeKraj;
            PolaznaLokacija = polaznaLokacija;
            DolaznaLokacija = dolaznaLokacija;
            ImePrezimeVozaca = imePrezimeVozaca;
            BrojPutnikaUAutomobilu = brojPutnikaUAutomobilu;
            NalogStatus = nalogStatus;
            Auto = auto;
        }

    }
}
