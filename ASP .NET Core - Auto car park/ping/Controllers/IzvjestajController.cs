using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ping.Models;
using ping.ViewModels;

namespace ping.Controllers
{
    [Authorize]

    public class IzvjestajController : Controller
    {
        private DatabaseContext context;
        private ILogger<IzvjestajController> logger;
        public IzvjestajController(DatabaseContext _context, ILogger<IzvjestajController> _logger)
        {
            context = _context;
            logger = _logger;
        }
        public IActionResult Index()
        {
            ViewBag.Data = context.Auto;
            //return RedirectToAction("PrikazIzvjestaja", "Izvjestaj");
            return View();
        }

        public IActionResult PrikazIzvjestaja(IzvjestajViewModel izvjestaj)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            int brojNaloga = 0;
            int nalogEvidentiran = 0;
            int nalogPotvrdjen = 0;
            int nalogOdbijen = 0;
            int nalogZavrsen = 0;
            ViewBag.Izvjestaj = izvjestaj;

            double zauzetiBrojDana = 0;
            if (!izvjestaj.SviAutomobili)
            {
                ViewBag.Auto = context.Auto.Single(car => car.Id == izvjestaj.AutoId);

                double ukupniBrojDana = (izvjestaj.VrijemeKraj - izvjestaj.VrijemePocetak).TotalDays+1;
                foreach (Nalog nalog in ViewBag.Auto.Nalozi)
                {
                    if (!(nalog.VrijemeKraj <= izvjestaj.VrijemePocetak || nalog.VrijemePocetak >= izvjestaj.VrijemeKraj))
                    {
                        brojNaloga++;
                        zauzetiBrojDana += (nalog.VrijemeKraj - nalog.VrijemePocetak).TotalDays + 1;
                        if (nalog.NalogStatus.Naziv == "Evidentiran")
                            nalogEvidentiran++;
                        else if (nalog.NalogStatus.Naziv == "Potvrdjen")
                            nalogPotvrdjen++;
                        else if (nalog.NalogStatus.Naziv == "Odbijen")
                            nalogOdbijen++;
                        else if (nalog.NalogStatus.Naziv == "Završen")
                            nalogZavrsen++;
                    }
                }
            }
            else
            {
                var automobili = context.Auto;
                int brojAutomobila = 0;
                foreach (Auto auto in automobili)
                {
                    brojAutomobila++;
                    double zauzetiBrojDanaUnit = 0;
                    int brojNalogaUnit = 0;
                    foreach (Nalog nalog in auto.Nalozi)
                    {
                        if (!(nalog.VrijemeKraj <= izvjestaj.VrijemePocetak || nalog.VrijemePocetak >= izvjestaj.VrijemeKraj))
                        {
                            zauzetiBrojDanaUnit += (nalog.VrijemeKraj - nalog.VrijemePocetak).TotalDays + 1;
                            brojNalogaUnit++;
                            if (nalog.NalogStatus.Naziv == "Evidentiran")
                                nalogEvidentiran++;
                            else if (nalog.NalogStatus.Naziv == "Potvrdjen")
                                nalogPotvrdjen++;
                            else if (nalog.NalogStatus.Naziv == "Odbijen")
                                nalogOdbijen++;
                            else if (nalog.NalogStatus.Naziv == "Završen")
                                nalogZavrsen++;
                        }
                    }
                    if(brojNalogaUnit!=0)
                        zauzetiBrojDana+= zauzetiBrojDanaUnit/brojNalogaUnit;
                    brojNaloga += brojNalogaUnit;
                }
                ViewBag.BrojAutomobila = brojAutomobila;
            }
            
            ViewBag.BrojNaloga = brojNaloga;
            ViewBag.NalogEvidentiran = nalogEvidentiran;
            ViewBag.NalogPotvrdjen = nalogPotvrdjen;
            ViewBag.NalogOdbijen = nalogOdbijen;
            ViewBag.NalogZavrsen = nalogZavrsen;
            ViewBag.ProcenatNalogEvidentiran = (brojNaloga == 0) ? 0 : (int)((nalogEvidentiran/brojNaloga)*100);
            ViewBag.ProcenatNalogPotvrdjen = (brojNaloga == 0) ? 0 : (int)((nalogPotvrdjen / brojNaloga)*100);
            ViewBag.ProcenatNalogOdbijen = (brojNaloga == 0) ? 0 : (int)((nalogOdbijen / brojNaloga)*100);
            ViewBag.ProcenatNalogZavrsen = (brojNaloga == 0) ? 0 : (int)((nalogZavrsen / brojNaloga)*100);
            ViewBag.ZauzetiBrojDana = zauzetiBrojDana;
            ViewBag.NezauzetiBrojDana = (izvjestaj.VrijemeKraj - izvjestaj.VrijemePocetak).TotalDays + 1 - zauzetiBrojDana;

            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}