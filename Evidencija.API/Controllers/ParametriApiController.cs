using Microsoft.AspNetCore.Mvc;
using Evidencija.BLL.Pravila;

namespace Evidencija.API.Controllers
{
    [ApiController]
    [Route("api/parametri")]
    public class ParametriApiController : ControllerBase
    {
        private readonly PravilaCitac _citac;

        public ParametriApiController(PravilaCitac citac)
        {
            _citac = citac;
        }

        [HttpGet("pravila")]
        public IActionResult Pravila() => Ok(_citac.Ucitaj());
    }
}
