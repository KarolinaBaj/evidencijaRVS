using Microsoft.AspNetCore.Mvc;
using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.Evidencija.BLL.Interfaces;
using Evidencija.BLL.Interfaces;

namespace Evidencija.API.Controllers
{
    [ApiController]
    [Route("api/pregledi")]
    public class PreglediApiController : ControllerBase
    {
        private readonly Ipregledservice _servis;

        public PreglediApiController(Ipregledservice servis)
        {
            _servis = servis;
        }

        
        [HttpGet]
        public IActionResult DobaviSve(DateTime? datumOd, DateTime? datumDo, bool? hitanSlucaj, string? prioritet)
        {
            var lista = _servis.Filtriraj(datumOd, datumDo, hitanSlucaj, prioritet)
                .Select(p => new
                {
                    p.pregled_id,
                    p.datumpregleda,
                    p.telesna_temperatura,
                    p.dijagnoza,
                    p.hitanslucaj,
                    p.prioritetpregleda
                });
            return Ok(lista);
        }

        
        [HttpGet("{id}")]
        public IActionResult DobaviPoId(int id)
        {
            var pregled = _servis.DobaviPoID(id);
            return pregled == null ? NotFound() : Ok(pregled);
        }

        
        [HttpPost]
        public async Task<IActionResult> Dodaj([FromBody] Pregled pregled)
        {
            await _servis.kreirajpregled(pregled);
            return Ok(new { pregled.pregled_id, pregled.hitanslucaj, pregled.prioritetpregleda });
        }

        
        [HttpPut("{id}")]
        public IActionResult Izmeni(int id, [FromBody] Pregled pregled)
        {
            var postojeci = _servis.DobaviPoID(id);
            if (postojeci == null) return NotFound();

            pregled.pregled_id = id;
            _servis.izmeni(pregled);

            return Ok(new { pregled.pregled_id, pregled.hitanslucaj, pregled.prioritetpregleda });
        }

      
        [HttpDelete("{id}")]
        public IActionResult Obrisi(int id)
        {
            _servis.Obrisi(id);
            return NoContent();
        }
    }
}