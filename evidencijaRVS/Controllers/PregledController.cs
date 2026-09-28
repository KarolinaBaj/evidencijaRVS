using Microsoft.AspNetCore.Mvc;
using evidencijaRVS.ViewModels;
using evidencijaRVS.Evidencija.BLL.Servicess;
using Evidencija.BLL.Interfaces;

namespace evidencijaRVS.Controllers
{
    public class PregledController : Controller
    {
        private readonly Ipregledservice _servis;

        public PregledController(Ipregledservice servis)
        {
            _servis = servis;
        }
        public IActionResult Index(DateTime? datumod,DateTime? datumdo, bool? hitanslucaj,string prioritet)
        {
            var model = new PregledlistaViewModel
            {
                Pregledi = _servis.Filtriraj(datumod, datumdo, hitanslucaj, prioritet),
                Datumod = datumod,
                datumdo = datumdo,
                hitanslucaj = hitanslucaj,
                Prioritet = prioritet
            };
            return View(model);
        }
    }
}
