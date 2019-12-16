using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ping.Models.Validacija;
using ping.Models.DatabaseKlase;
using System.ComponentModel.DataAnnotations.Schema;

namespace ping.Models
{
    public class Auto
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

        

        //[Required]
        [Display(Name = "Godina proizvodnje")]
        public int GodinaProizvodnje { get; set; } // godina u proslosti

        //[Required]
        [Display(Name = "Vrsta goriva")]

        public virtual Gorivo VrstaGoriva { get; set; } // benzin, dizel, plin

        //[Required]
        [Display(Name = "Nalozi")]

        public virtual ICollection<Nalog> Nalozi { get; set; } // benzin, dizel, plin

        public Auto() { }

        public Auto(int id)
        {
            Id = id;
        }
        public Auto(string model, int godinaProizvodnje, Gorivo vrstaGoriva, double snagaMotora, int brojSasije, int brojMotora)
        {
            Model = model;
            GodinaProizvodnje = godinaProizvodnje;
            VrstaGoriva = vrstaGoriva;
            SnagaMotora = snagaMotora;

            BrojSasije = brojSasije;
            BrojMotora = brojMotora;        
            
        }

        public Auto(int id, string model, int godinaProizvodnje, Gorivo vrstaGoriva, double snagaMotora, int brojSasije, int brojMotora)
        {
            Id = id;
            Model = model;
            GodinaProizvodnje = godinaProizvodnje;
            VrstaGoriva = vrstaGoriva;
            SnagaMotora = snagaMotora;

            BrojSasije = brojSasije;
            BrojMotora = brojMotora;

        }


        /*public Auto(string model, int brojSasije, int brojMotora, double snagaMotora, Gorivo vrstaGoriva, int godinaProizvodnje)
        {
            Model = model;
            BrojSasije = brojSasije;
            BrojMotora = brojMotora;
            SnagaMotora = snagaMotora;
            VrstaGoriva = vrstaGoriva;
            GodinaProizvodnje = godinaProizvodnje;
        }

        public Auto() { }*/
    }
}