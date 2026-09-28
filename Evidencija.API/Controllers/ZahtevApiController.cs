using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using evidencijaRVS.Evidencija.DAL.Models;
using Evidencija.DAL.Repozitorijumi;
using evidencijaRVS.Evidencija.BLL.Interfaces;
using Evidencija.BLL.Interfaces;
using Evidencija.BLL.Pravila;
using Evidencija.DAL;

namespace Evidencija.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZahtevApiController : ControllerBase
    {
        private readonly korisnikiservice _servis;
        public ZahtevApiController(korisnikiservice servis)
        {
            _servis = servis;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginZahtev z)
        {
            var k = await _servis.ValidateKorisnikAsync(z.Email, z.Lozinka);
            if (k == null) return Unauthorized();
            return Ok(new { k.korisnik_id, k.ime, k.prezime, k.email });
        }

        [ApiController]
        [Route("api/[controller]")]
        public class PreglediController : ControllerBase
        {
            private readonly Ipregledservice _servis;
            public PreglediController(Ipregledservice servis) { _servis = servis; }

            [HttpGet]
            public IActionResult Get(DateTime? datumOd, DateTime? datumDo, bool? hitanSlucaj, string? prioritet)
            {
                var lista = _servis.Filtriraj(datumOd, datumDo, hitanSlucaj, prioritet)
                    .Select(p => new {
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
            public IActionResult GetById(int id)
            {
                var p = _servis.DobaviPoID(id);
                return p == null ? NotFound() : Ok(p);
            }

            [HttpPost]
            public async Task<IActionResult> Post([FromBody] Pregled pregled)
            {
                await _servis.kreirajpregled(pregled);
                return Ok(new { pregled.pregled_id, pregled.hitanslucaj, pregled.prioritetpregleda });
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _servis.Obrisi(id);
                return NoContent();
            }
        }

        [ApiController]
        [Route("api/parametri")]
        public class ParametriController : ControllerBase
        {
            private readonly PravilaCitac _citac;
            public ParametriController(PravilaCitac citac) { _citac = citac; }

            [HttpGet("pravila")]
            public IActionResult Pravila() => Ok(_citac.Ucitaj());
        }

        public class LoginZahtev
        {
            public string Email { get; set; }
            public string Lozinka { get; set; }
        }
    }
}
