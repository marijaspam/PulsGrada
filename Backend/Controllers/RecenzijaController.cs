using Microsoft.AspNetCore.Mvc;
using PulsGrada.DTOs;
using PulsGrada.Services;

namespace PulsGrada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecenzijaController : ControllerBase
    {
        private readonly IRecenzijaService _recenzijaService;

        public RecenzijaController(IRecenzijaService recenzijaService)
        {
            _recenzijaService = recenzijaService;
        }

        [HttpGet("{id}")]
        public IActionResult DohvatiSveRecenzije(int id)
        {
            var recenzije = _recenzijaService.DohvatiRecenzijeZaLokal(id);

            if (recenzije == null)
            {
                return NotFound(new { poruka = "Recenzije nisu pronađene" });
            }
            return Ok(recenzije);
        }

        [HttpPost]
        public IActionResult ObjaviRecenziju([FromBody] RecenzijaStvaranjeDto novaRecenzija)
        {
            if (novaRecenzija == null)
            {
                return BadRequest(new { poruka = "Podaci nisu ispravno poslani" });
            }

            _recenzijaService.DodajRecenziju(novaRecenzija);

            return CreatedAtAction(nameof(DohvatiSveRecenzije), new { id = novaRecenzija.IdLokal }, novaRecenzija);
        }
        [HttpDelete]
        public IActionResult ObrisiRecenziju(int id)
        {
            var uspjeh = _recenzijaService.ObrisiRecenziju(id);
            if (!uspjeh)
            {
                return NotFound(new { poruka = "Recenzija nije pronađena" });
            }
            return NoContent();
        }
    }
}