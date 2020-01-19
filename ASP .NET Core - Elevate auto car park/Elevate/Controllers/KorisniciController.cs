using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Elevate.Models;
using System.Security.Claims;

namespace Elevate.Controllers
{
    [Authorize]
    public class KorisniciController : Controller
    {
        private DatabaseContext context;
        private ILogger<KorisniciController> logger;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;


        public KorisniciController(DatabaseContext _context, ILogger<KorisniciController> _logger, UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            context = _context;
            logger = _logger;
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Index()
        {
            ViewBag.Data = context.Users;
            ViewBag.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        public IActionResult DodajKorisnika()
        {
            return LocalRedirect("/Identity/Account/Register");
        }

        public IActionResult IzbrisiKorisnika(string korisnikId)
        {
            if (context.Users.Count() == 1)
            {
                return RedirectToAction("Index", "Korisnici", new { errorMsg = "Ne možete izbrisati jedinog korisnika" });
            }
            IdentityUser user = context.Users.First(c => c.Id == korisnikId);
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index", "Korisnici");
        }
    }
}