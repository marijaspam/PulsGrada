using Microsoft.AspNetCore.Mvc;
using PulsGrada.Services;
namespace PulsGrada.Controllers
{
    [ApiController]
    [Route("api/controller")]
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
        [HttpGet]
        public IActionResult DohavtiDogadajPoId(int id)
        {
            var dogadaj = _dogadajService.DohvatiPojediniDogadaj(id);

            if(dogadaj == null)
            {
                return NotFound(new { poruka = "dogadaj nije pronaden" });
            }
            return Ok(dogadaj);
        }
    }
}
