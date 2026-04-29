using Microsoft.AspNetCore.Mvc;
using PulsGrada.Services;
namespace PulsGrada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogadajController :ControllerBase
    {
        private readonly IDogadajService _dogadajService;
        public DogadajController(IDogadajService dogadajService)
        {
            _dogadajService = dogadajService;
        }
        [HttpGet]
        public IActionResult DohvatiSveDogadaje()
        {
            var dogadaji = _dogadajService.DohvatiSveDogadaje();
            return Ok(dogadaji);
        }
        [HttpGet("{id}")]
        public IActionResult DohavtiDogadajPoId(int id)
        {
            var dogadaj = _dogadajService.DohvatiPojediniDogadaj(id);

            if(dogadaj == null)
            {
                return NotFound(new { poruka = "dogadaj nije pronaden" });
            }
            return Ok(dogadaj);
        }
        [HttpGet("filter")]
        public IActionResult FiltrirajDogadaje(
            [FromQuery] string? naziv,
            [FromQuery] string? kategorija,
            [FromQuery] DateTime? vrijeme
            )
        {
            var rezultatiDogadaji = _dogadajService.FiltrirajDogadaje(naziv, kategorija, vrijeme);
            if(rezultatiDogadaji == null)
            {
                return NotFound(new { poruka = "Nije pronaden takav dogadaj" });
            }
            return Ok(rezultatiDogadaji);
        }
        [HttpGet("pretraga")]
        public IActionResult PretragaDogadaja([FromQuery] string uneseniPojam)
        {
            var rezultatiPretrage = _dogadajService.PretraziDogadaje(uneseniPojam);
            if(rezultatiPretrage == null || !rezultatiPretrage.Any())
            {
                return NotFound(new { poruka = "Nema rezultata za vašu pretragu." });
            }
            return Ok(rezultatiPretrage);
        }
    }
}
