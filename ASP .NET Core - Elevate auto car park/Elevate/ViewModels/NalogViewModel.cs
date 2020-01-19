using Elevate.Models;
using Elevate.Models.DatabaseKlase;
using Elevate.Models.Validacija;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elevate.ViewModels
{
    public class NalogViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Datum početka najma")]
        public DateTime VrijemePocetak { get; set; }
        [Display(Name = "Datum završetka najma")]
        [ValidacijaNalogViewModelVrijemeKraj]
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
        public int NalogStatus { get; set; }
        [Display(Name = "Automobil")]
        public string Auto { get; set; }
        [Display(Name = "Automobil")]
        public int AutoId { get; set; }

    }
}
