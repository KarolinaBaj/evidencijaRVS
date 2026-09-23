using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using evidencijaRVS.Evidencija.DAL;
using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.Evidencija.BLL.Interfaces;
using evidencijaRVS.Evidencija.BLL.Servicess;

namespace evidencijaRVS.Evidencija.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly korisnikiservice KorisnikService;
     
        public AccountController(korisnikiservice korisnikService)
        {
            KorisnikService = korisnikService;
        }

        [HttpPost]

        public async Task<IActionResult> stranazalogovanje(Korisnik korisnik)
        {    
            var korisnik1 = await KorisnikService.ValidateKorisnikAsync(korisnik.email, korisnik.lozinka);
            if (korisnik1 == null)
            { 
            return View("~/Evidencija.MVC/Views/Home/stranazalogovanje.cshtml");
            }
            return RedirectToAction("Index", "Home");

        }
      

        [HttpPost]
        public async Task<IActionResult>  kreiranjenaloga(Korisnik korisnik)
        {
            //return View("~/Evidencija.MVC/Views/Home/kreiranjenaloga.cshtml");
            try { 
              var korisnik2 = await KorisnikService.CreateKorisnikAsync(korisnik);
               return View("~/Evidencija.MVC/Views/Home/stranazalogovanje.cshtml");
            }
            catch
            { 
                return View("~/Evidencija.MVC/Views/Home/kreiranjenaloga.cshtml");
            }


        }

    }
}
