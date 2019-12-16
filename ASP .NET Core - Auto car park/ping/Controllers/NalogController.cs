using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ping.Models;
using ping.Models.DatabaseKlase;
using ping.ViewModels;

namespace ping.Controllers
{
    [Authorize]

    public class NalogController : Controller
    {
        private DatabaseContext context;
        private ILogger<NalogController> logger;
        public NalogController(DatabaseContext _context, ILogger<NalogController> _logger)
        {
            context = _context;
            logger = _logger;
        }

        // GET: Nalog
        public ActionResult Index()
        {
            ViewBag.Data = context.Nalog;
            return View();
        }

        public ActionResult DodajNalog(int autoId)
        {
            Auto auto = context.Auto.Single(car => car.Id == autoId);
            ViewBag.AutoId = auto.Id;
            ViewBag.AutoModel = auto.Model;
            return View();
        }

        public ActionResult PrikazNaloga(int nalogId)
        {
            ViewBag.Data = context.Nalog.Single(nalog => nalog.Id == nalogId);
            return View();
        }

        public ActionResult SpasiNalog(NalogViewModel nalogVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AutoId = nalogVM.AutoId;
                ViewBag.AutoModel = nalogVM.Auto;

                return View("DodajNalog");
            }
            NalogStatus nalogStatus =  context.NalogStatus.Single(status => status.Id == 1); // 1 evidentiran
            Auto auto = context.Auto.Single(car => car.Id == nalogVM.AutoId);
            context.Nalog.Add(new Nalog(
                nalogVM.VrijemePocetak,
                nalogVM.VrijemeKraj, 
                nalogVM.PolaznaLokacija, 
                nalogVM.DolaznaLokacija, 
                nalogVM.ImePrezimeVozaca,
                nalogVM.BrojPutnikaUAutomobilu,
                nalogStatus,
                auto
                ));
            context.SaveChanges();
            return RedirectToAction("Index", "Nalog");
        }

        public ActionResult PromijeniNalog(int nalogId, int nalogStatusId)
        {
            Nalog nalog = context.Nalog.Single(nalog => nalog.Id == nalogId);
            nalog.NalogStatus = context.NalogStatus.Single(status => status.Id == nalogStatusId);
            context.Entry(context.Nalog.FirstOrDefault(x => x.Id == nalogId)).CurrentValues.SetValues(nalog);
            context.SaveChanges();
            return RedirectToAction("PrikazNaloga", "Nalog", new { nalogId = nalogId });
        }

    }
}