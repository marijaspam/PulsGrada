using Microsoft.AspNetCore.Mvc;
using PulsGrada.DTOs;
using PulsGrada.Models;
using PulsGrada.Services;

namespace PulsGrada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritController : ControllerBase
    {
        private readonly IFavoritService _favoritService;

        public FavoritController(IFavoritService favoritService)
        {
            _favoritService = favoritService;
        }

        [HttpGet("{korisnikId}")]
        public IActionResult DohvatiFavorite(int korisnikId)
        {
            var favoriti = _favoritService.DohvatiFavoriteKorisnika(korisnikId);

            return Ok(favoriti);
        }

        [HttpPost("dodaj")]
        public IActionResult DodajFavorit([FromBody] FavoritDto favorit)
        {
            if (favorit == null)
            {
                return BadRequest(new { poruka = "Podaci nisu ispravno poslani." });
            }

            var uspjeh = _favoritService.DodajFavorit(favorit);

            if (!uspjeh)
            {
                return BadRequest(new { poruka = "Lokal već postoji u favoritima ili ne postoji u sustavu." });
            }

            return Ok(new { poruka = "Lokal uspješno dodan u favorite!" });
        }

        [HttpDelete("obrisi")]
        public IActionResult ObrisiFavorit([FromBody] FavoritDto favorit)
        {
            var uspjeh = _favoritService.ObrisiFavorit(favorit);

            if (!uspjeh)
            {
                return NotFound(new { poruka = "Favorit nije pronađen, pa ga nije moguće obrisati." });
            }

            return Ok(new { poruka = "Uspješno obrisano iz favorita." });
        }
    }
}