using Microsoft.AspNetCore.Mvc;
using Evidencija.BLL.Interfaces;
using evidencijaRVS.Evidencija.BLL.Interfaces;

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
    }

    public class LoginZahtev
    {
        public string Email { get; set; }
        public string Lozinka { get; set; }
    }
}