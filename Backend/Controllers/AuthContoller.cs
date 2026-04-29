using Microsoft.AspNetCore.Mvc;
using PulsGrada.DTOs;
using PulsGrada.Models;
using PulsGrada.Services;

namespace PulsGrada.Controllers
{
    [ApiController]
    [Route("api/[conroller]")]
    public class AuthContoller :ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthContoller(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet("prijava")]
        public IActionResult Prijava([FromBody]PrijavaKorisnikaDto podaciPrijave)
        {
            var korisnik = _authService.Prijava(podaciPrijave);
            if(korisnik == null)
            {
                return Unauthorized(new { poruka = "Neuspješni podaci za prijavu" });
            }
            return Ok(
            new
            {
                token = "simunacija-tokena-123456",
                IdKorisnik = korisnik.Id,
                KorisnickoIme = korisnik.KorisnickoIme
            });
        }
        [HttpPost("registracija")]
        public IActionResult Registracija([FromBody]RegistracijaDto podaciRegistracija)
        {
            if (podaciRegistracija == null)
            {
                return BadRequest(new { poruka = "Podaci nisu ispravno poslani." });
            }

            var rezultat = _authService.Registracija(podaciRegistracija);

            if (rezultat == "Uspješna registracija!")
            {
                return Ok(new { poruka = rezultat });
            }

            return BadRequest(new { poruka = rezultat });
        }
    }
}
