using PulsGrada.Models;

namespace PulsGrada.Repositories
{
    public interface IAuthRepository
    {
        Korisnik? DohvatiPoKorisnickomImenu(string korisnickoIme);

        Korisnik? DohvatiPoEmailu(string email);

        bool RegistrirajKorisnika(Korisnik noviKorisnik);
    }
}