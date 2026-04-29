using PulsGrada.DTOs;
using PulsGrada.Models;

namespace PulsGrada.Services
{
    public interface IAuthService
    {
        Korisnik? Prijava(PrijavaKorisnikaDto podaciPrijave);
        string Registracija(RegistracijaDto podaciRegistracija);
    }
}
