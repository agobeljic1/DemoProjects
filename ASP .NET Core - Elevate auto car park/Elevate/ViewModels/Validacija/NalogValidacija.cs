using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Elevate.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elevate.Models.Validacija
{
    public class ValidacijaNalogViewModelVrijemeKraj : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            var nalogVM = (NalogViewModel)validationContext.ObjectInstance;
            var context = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));

            Auto auto = context.Auto.Single(car => car.Id == nalogVM.AutoId);
            foreach (Nalog nalog in auto.Nalozi)
            {
                if ((nalog.NalogStatus.Naziv=="Evidentiran" || nalog.NalogStatus.Naziv=="Potvrdjen") && !(nalogVM.VrijemeKraj <= nalog.VrijemePocetak || nalogVM.VrijemePocetak >= nalog.VrijemeKraj))
                {
                    return new ValidationResult("Automobil je zauzet tokom ovog perioda");
                }
            }                
            return ValidationResult.Success;
        }


    }
    
}