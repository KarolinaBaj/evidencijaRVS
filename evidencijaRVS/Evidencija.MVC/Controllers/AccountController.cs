using Microsoft.AspNetCore.Mvc;

namespace evidencijaRVS.Evidencija.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult stranazalogovanje()
        {
            return View("~/Evidencija.MVC/Views/Home/stranazalogovanje.cshtml");
        }
        public IActionResult kreiranjenaloga()
        {
            return View("~/Evidencija.MVC/Views/Home/kreiranjenaloga.cshtml");
        }
    }
}
