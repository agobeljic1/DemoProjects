using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ping.Models.DatabaseKlase;
using ping.Models.Validacija;

namespace ping.ViewModels
{
    public class IzvjestajViewModel
    {
        [Display(Name = "Izvještaj za sve automobile")]
        public bool SviAutomobili { get; set; }
        [Display(Name = "ID automobila")]
        [ValidacijaIzvjestajViewModelId]
        public int AutoId { get; set; }
        [Display(Name = "Vrijeme početka")]
        [ValidacijaIzvjestajViewModelVrijemePocetak]

        public DateTime VrijemePocetak { get; set; }
        [Display(Name = "Vrijeme kraja")]
        [ValidacijaIzvjestajViewModelVrijemeKraj]
        public DateTime VrijemeKraj { get; set; }
    }
}
