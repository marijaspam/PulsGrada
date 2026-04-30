using PulsGrada.Models;
using PulsGrada.Repositories;
using PulsGrada.DTOs;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace PulsGrada.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _korisnikRepo;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository korisnikRepo, IConfiguration configuration)
        {
            _korisnikRepo = korisnikRepo;
            _configuration = configuration;
        }

        public string Registracija(RegistracijaDto podaci)
        {
            if (_korisnikRepo.DohvatiPoKorisnickomImenu(podaci.KorisnickoIme) != null) return "Korisničko ime zauzeto";

            var noviKorisnik = new Korisnik
            {
                KorisnickoIme = podaci.KorisnickoIme,
                Email = podaci.Email,
                Ime = podaci.Ime,
                Prezime = podaci.Prezime,
                Lozinka = BCrypt.Net.BCrypt.HashPassword(podaci.Lozinka),
                DatumRegistracije = DateTime.Now
            };

            return _korisnikRepo.RegistrirajKorisnika(noviKorisnik) ? "Uspješna registracija!" : "Greška";
        }

        public Korisnik? Prijava(PrijavaKorisnikaDto podaci)
        {
            var korisnik = _korisnikRepo.DohvatiPoKorisnickomImenu(podaci.KorisnikIdentifikator);
            if (korisnik == null) return null;

            if (!BCrypt.Net.BCrypt.Verify(podaci.Lozinka, korisnik.Lozinka)) return null;

            return korisnik;
        }

        public string GenerirajJwtToken(Korisnik korisnik)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var kljuc = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? "super_tajni_kljuc_123456789");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, korisnik.KorisnickoIme),
                    new Claim(ClaimTypes.NameIdentifier, korisnik.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(kljuc), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}