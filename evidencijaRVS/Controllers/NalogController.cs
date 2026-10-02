using Microsoft.AspNetCore.Mvc;
using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.Evidencija.BLL.Interfaces;
using evidencijaRVS.ViewModels;

namespace evidencijaRVS.Controllers
{
    public class NalogController : Controller
    {
        private readonly korisnikiservice KorisnikService;

        public NalogController(korisnikiservice korisnikService)
        {
            KorisnikService = korisnikService;
        }
        [HttpGet]
        public IActionResult stranazalogovanje()
        {
            return View("~/Views/Home/stranazalogovanje.cshtml", new PrijavaViewModel());
        }
        
       

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> stranazalogovanje(PrijavaViewModel model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Home/stranazalogovanje.cshtml", model);

            var korisnik = await KorisnikService.ValidateKorisnikAsync(model.Email, model.Lozinka);
            if (korisnik == null)
            {
                ModelState.AddModelError("", "Pogrešan email ili lozinka.");
                return View("~/Views/Home/stranazalogovanje.cshtml", model);
            }

            return RedirectToAction("Index", "Pregled");

        }
        public IActionResult kreiranjenaloga()
        {
            return View("~/Views/Home/kreiranjenaloga.cshtml", new RegistracijaViewModel());
        }

        [HttpGet, ValidateAntiForgeryToken]
        public async Task<IActionResult> kreiranjenaloga(RegistracijaViewModel model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Home/kreiranjenaloga.cshtml", model);

            var korisnik = new Korisnik
            {
                ime = model.Ime,
                prezime = model.Prezime,
                adresa = model.Adresa,
                email = model.Email,
                lozinka = model.Lozinka
            };

            try
            {
                await KorisnikService.CreateKorisnikAsync(korisnik);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Nalog nije kreiran. Pokušajte ponovo.");
                return View("~/Views/Home/kreiranjenaloga.cshtml", model);
            }

            
            return RedirectToAction("stranazalogovanje", "Nalog");
        }


    }
}
