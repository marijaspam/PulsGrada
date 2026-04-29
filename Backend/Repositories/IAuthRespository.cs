using PulsGrada.Models;

namespace PulsGrada.Repositories
{
    public interface IKorisnikRepository
    {
        Korisnik? DohvatiPoKorisnickomImenu(string korisnickoIme);

        Korisnik? DohvatiPoEmailu(string email);

        bool RegistrirajKorisnika(Korisnik noviKorisnik);
    }
}