using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Elevate.Models;
using Elevate.Models.DatabaseKlase;
using Elevate.ViewModels;

namespace Elevate.Controllers
{
    [Authorize]
    public class AutomobiliController : Controller
    {
        private DatabaseContext context;
        private ILogger<AutomobiliController> logger;
        private double KOLIKO_IMA_KW_U_KS = 0.745;
        private double KOLIKO_IMA_KS_U_KW = 1.341;

        public AutomobiliController(DatabaseContext _context, ILogger<AutomobiliController> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public ActionResult Index()
        {
            ViewBag.Data = context.Auto;
            ViewBag.KOLIKO_IMA_KW_U_KS = KOLIKO_IMA_KW_U_KS;
            ViewBag.KOLIKO_IMA_KS_U_KW = KOLIKO_IMA_KS_U_KW;
            return View();
        }


        public ActionResult AzurirajAuto(int autoId)
        {
            ViewBag.Data = context.Auto.Single(car => car.Id == autoId);
            ViewBag.Gorivo = context.Gorivo;
            return View();
        }
        public ActionResult PrikazAuta(int autoId)
        {
            ViewBag.Data = context.Auto.Single(car => car.Id == autoId);
            ViewBag.KOLIKO_IMA_KS_U_KW = KOLIKO_IMA_KS_U_KW;

            return View();
        }
        public ActionResult ObrisiAuto(int autoId)
        {
            Auto auto = context.Auto.Single(car => car.Id == autoId);
            var list = auto.Nalozi;
            foreach (Nalog nalog in list)
            {
                context.Nalog.Remove(nalog);
            }
            context.Attach(auto);
            context.Remove(auto);
            context.SaveChanges();
            return RedirectToAction("Index", "Automobili");
        }
        public ActionResult DodajAuto()
        {
            ViewBag.Gorivo = context.Gorivo;
            return View();
        }

        public ActionResult PretragaAuta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SpasiPromjeneAuto(AutoViewModel auto)
        {
            if (!ModelState.IsValid)
            {
                return View("AzurirajAuto");
            }
            double snagaMotora = auto.SnagaMotora;
            if (auto.JedinicaSnageMotora == "KS")
                snagaMotora *= KOLIKO_IMA_KW_U_KS;
            Gorivo gorivo = context.Gorivo.Single(fuel => fuel.Id == auto.VrstaGoriva);
            context.Entry(context.Auto.FirstOrDefault(x => x.Id == auto.Id)).CurrentValues.SetValues(new Auto(
                auto.Id,
                auto.Model,
                auto.GodinaProizvodnje,
                gorivo,
                snagaMotora,
                auto.BrojSasije,
                auto.BrojMotora
                ));
            context.SaveChanges();

            return RedirectToAction("PrikazAuta", "Automobili", new { autoId = auto.Id });
        }
        [HttpPost]
        public ActionResult SpasiAuto(AutoViewModel auto)
        {
            if (!ModelState.IsValid)
            {
                return View("DodajAuto");
            }
            double snagaMotora = auto.SnagaMotora;
            if (auto.JedinicaSnageMotora == "KS")
                snagaMotora *= KOLIKO_IMA_KW_U_KS;

            Gorivo gorivo = context.Gorivo.Single(fuel => fuel.Id == auto.VrstaGoriva);
            context.Auto.Add(new Auto(
                auto.Model,
                auto.GodinaProizvodnje,
                gorivo,
                snagaMotora,
                auto.BrojSasije,
                auto.BrojMotora
                ));
            context.SaveChanges();

            return RedirectToAction("Index", "Automobili");
        }
    }
}