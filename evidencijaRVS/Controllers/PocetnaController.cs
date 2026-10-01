using System.Diagnostics;
using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.Models;
using Microsoft.AspNetCore.Mvc;

namespace evidencijaRVS.Controllers
{
    public class PocetnaController : Controller
    {
        private readonly ILogger<PocetnaController> _logger;

        public PocetnaController(ILogger<PocetnaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View("~/Views/Home/Privacy.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
