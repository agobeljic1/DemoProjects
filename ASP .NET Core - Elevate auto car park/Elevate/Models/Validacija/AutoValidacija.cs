using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elevate.Models.Validacija
{
    public class ValidacijaModela : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var auto = (Auto)validationContext.ObjectInstance;

            if (auto.Model.Length <= 2)
                return new ValidationResult("Model mora imati najmanje tri karaktera");

            return ValidationResult.Success;
        }
    }
    public class SestocifrenBrojSasije : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var auto = (Auto)validationContext.ObjectInstance;
                if (auto.BrojSasije < 100000 || auto.BrojSasije > 999999)
                    return new ValidationResult("Broj sasije mora biti sestocifren broj");

            return ValidationResult.Success;
        }
    }

    public class SestocifrenBrojMotora : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var auto = (Auto)validationContext.ObjectInstance;

            if (auto.BrojMotora < 100000 || auto.BrojMotora > 999999)
                return new ValidationResult("Broj motora mora biti sestocifren broj");

            return ValidationResult.Success;
        }
    }

    public class ValidacijaVrstaGoriva : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var auto = (Auto)validationContext.ObjectInstance;

            if (auto.BrojSasije < 100000 || auto.BrojSasije > 999999)
                return new ValidationResult("Broj sasije mora biti sestocifren broj");

            return ValidationResult.Success;
        }
    }

    public class ValidacijaGodinaProizvodnje : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var auto = (Auto)validationContext.ObjectInstance;

            if (auto.BrojSasije < 100000 || auto.BrojSasije > 999999)
                return new ValidationResult("Broj sasije mora biti sestocifren broj");

            return ValidationResult.Success;
        }
    }
    /*

    [Required]
    [Display(Name = "Model")]
    public string Model { get; set; }

    [Required]
    [Display(Name = "Broj šasije")]
    [SestocifrenBrojMotora]
    public int BrojSasije { get; set; }  // mora imati sest cifara

    [Required]
    [Display(Name = "Broj motora")]
    [SestocifrenBrojMotora]
    public int BrojMotora { get; set; } // mora imati sest cifara

    [Required]
    [Display(Name = "Snaga motora")]
    public double SnagaMotora { get; set; } // u kilowatima

    [Required]
    [Display(Name = "Vrsta goriva")]
    public Gorivo VrstaGoriva { get; set; } // benzin, dizel, plin

    [Required]
    [Display(Name = "Godina proizvodnje")]
    public int GodinaProizvodnje { get; set; } // godina u proslosti
    */
}