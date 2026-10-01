using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.ViewModels;

namespace evidencijaRVS.Controllers
{
    public class PregledController : Controller
    {
        private readonly HttpClient _klijent;

        public PregledController(IHttpClientFactory fabrika)
        {
            _klijent = fabrika.CreateClient("api");
        }




        public async Task<IActionResult> Index(DateTime? datumod, DateTime? datumdo, bool? hitanslucaj, string? prioritet)
        {
            var parametri = new List<string>();
            if (datumod.HasValue) parametri.Add($"datumOd={datumod:yyyy-MM-dd}");
            if (datumdo.HasValue) parametri.Add($"datumDo={datumdo:yyyy-MM-dd}");
            if (hitanslucaj.HasValue) parametri.Add($"hitanSlucaj={hitanslucaj.Value.ToString().ToLower()}");
            if (!string.IsNullOrWhiteSpace(prioritet)) parametri.Add($"prioritet={Uri.EscapeDataString(prioritet)}");

            var upit = parametri.Count > 0 ? "?" + string.Join("&", parametri) : "";
            var pregledi = await _klijent.GetFromJsonAsync<List<Pregled>>("api/pregledi" + upit) ?? new List<Pregled>();

            var model = new PregledlistaViewModel
            {
                Pregledi = pregledi,
                Datumod = datumod,
                datumdo = datumdo,
                hitanslucaj = hitanslucaj,
                Prioritet = prioritet
            };
            return View(model);
        }

       
        [HttpGet]
        public IActionResult Dodaj()
        {
            return View(new Pregled { datumpregleda = DateTime.Today });
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj(Pregled pregled)
        {
            if (!ModelState.IsValid) return View(pregled);

            var odgovor = await _klijent.PostAsJsonAsync("api/pregledi", pregled);
            if (odgovor.IsSuccessStatusCode) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Čuvanje pregleda nije uspelo.");
            return View(pregled);
        }


        [HttpGet]
        public async Task<IActionResult> Izmeni(int id)
        {
            var pregled = await _klijent.GetFromJsonAsync<Pregled>($"api/pregledi/{id}");
            if (pregled == null) return NotFound();
            return View(pregled);
        }

        [HttpPost]
        public async Task<IActionResult> Izmeni(int id, Pregled pregled)
        {
            if (!ModelState.IsValid) return View(pregled);

            var odgovor = await _klijent.PutAsJsonAsync($"api/pregledi/{id}", pregled);
            if (odgovor.IsSuccessStatusCode) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Izmena pregleda nije uspela.");
            return View(pregled);
        }

       
        [HttpPost]
        public async Task<IActionResult> Obrisi(int id)
        {
            await _klijent.DeleteAsync($"api/pregledi/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}