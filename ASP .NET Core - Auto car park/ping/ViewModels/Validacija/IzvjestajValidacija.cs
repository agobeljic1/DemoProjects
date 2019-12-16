using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ping.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ping.Models.Validacija
{
    public class ValidacijaIzvjestajViewModelId : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            var izvjestaj = (IzvjestajViewModel)validationContext.ObjectInstance;
            if(izvjestaj.SviAutomobili)
                return ValidationResult.Success;
            var context = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));


            if (izvjestaj.AutoId<=0)
                return new ValidationResult("Morate unijeti id kao pozitivan cijeli broj");
            try
            {
                Auto auto = context.Auto.Single(car => car.Id == izvjestaj.AutoId);
            }
            catch(Exception e)
            {

                return new ValidationResult("Ne postoji automobil sa ovim id-em");
            }                
            return ValidationResult.Success;
        }


    }
    public class ValidacijaIzvjestajViewModelVrijemePocetak : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var izvjestaj = (IzvjestajViewModel)validationContext.ObjectInstance;
            if(izvjestaj.VrijemePocetak==null || izvjestaj.VrijemePocetak.Year < 1900)
                return new ValidationResult("Unijeli ste neispravan datum");
            
            return ValidationResult.Success;
        }


    }
    public class ValidacijaIzvjestajViewModelVrijemeKraj : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var izvjestaj = (IzvjestajViewModel)validationContext.ObjectInstance;
            if (izvjestaj.VrijemePocetak == null || izvjestaj.VrijemeKraj.Year<1900)
                return new ValidationResult("Unijeli ste neispravan datum");
            if (izvjestaj.VrijemePocetak > izvjestaj.VrijemeKraj)
                return new ValidationResult("Vrijeme kraja mora biti nakon vremena početka");
            
            return ValidationResult.Success;
        }


    }
}