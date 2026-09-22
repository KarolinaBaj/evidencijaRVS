using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using evidencijaRVS.Evidencija.DAL;
using evidencijaRVS.Evidencija.DAL.Models;

namespace evidencijaRVS.Evidencija.MVC.Controllers
{
    public class AccountController : Controller
    {
        //private readonly EvidencijaDBcontext _context;
        //public AccountController(EvidencijaDBcontext context)
        //{
        //    _context = context;
        //}
        public IActionResult stranazalogovanje(Korisnik korisnik)
        {

            return View("~/Evidencija.MVC/Views/Home/stranazalogovanje.cshtml");
        }
        public IActionResult kreiranjenaloga()
        {
            return View("~/Evidencija.MVC/Views/Home/kreiranjenaloga.cshtml");
        }
    }
}
