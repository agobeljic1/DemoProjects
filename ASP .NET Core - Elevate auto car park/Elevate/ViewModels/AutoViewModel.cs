using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elevate.ViewModels
{
    public class AutoViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        //[Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        //[Required]
        [Display(Name = "Broj šasije")]
        //[SestocifrenBrojMotora]
        public int BrojSasije { get; set; }  // mora imati sest cifara

        //[Required]
        [Display(Name = "Broj motora")]
        //[SestocifrenBrojMotora]
        public int BrojMotora { get; set; } // mora imati sest cifara

        //[Required]
        [Display(Name = "Snaga motora")]
        public double SnagaMotora { get; set; } // u kilowatima

        [Display(Name = "Jedinica snage motora")]
        public string JedinicaSnageMotora { get; set; } // KW, KS

        //[Required]
        [Display(Name = "Godina proizvodnje")]
        public int GodinaProizvodnje { get; set; } // godina u proslosti

        //[Required]
        [Display(Name = "Vrsta goriva")]

        public int VrstaGoriva { get; set; } // benzin, dizel, plin

        




    }
}
