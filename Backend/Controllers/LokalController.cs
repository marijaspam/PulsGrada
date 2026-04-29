using Microsoft.AspNetCore.Mvc;
using PulsGrada.Services;

namespace PulsGrada.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class LokalController : ControllerBase 
    {
        private readonly ILokalService _lokalService;

        public LokalController(ILokalService lokalService)
        {
            _lokalService = lokalService;
        }

        [HttpGet]
        public IActionResult DohvatiSveLokale()
        {
            var lokali = _lokalService.DohvatiSveLokale();

            return Ok(lokali);
        }
        [HttpGet("{id}")]
        public IActionResult DohvatiLokalPoId(int id)
        {
            var lokal = _lokalService.DohvatiPojediniLokal(id);
            if(lokal == null)
            {
                return NotFound(new { poruka = "Lokal nije pronađen" });
            }
            return Ok(lokal);
        }
        [HttpGet("filter")]
        public IActionResult FiltrirajLokale(
            [FromQuery] string? adresa,
            [FromQuery] bool? imaPusenje,
            [FromQuery] bool? imaBiljar,
            [FromQuery] bool? imaPikado,
            [FromQuery] int? idKvart
            )
        {
            var rezultatiLokali = _lokalService.FilterLokala(adresa, imaPusenje, imaBiljar, imaPikado, idKvart);
            if(rezultatiLokali == null)
            {
                return NotFound(new { poruka = "Nije pronaden takav lokal" });
            }
            return Ok(rezultatiLokali);
        }
    }
}