using PulsGrada.Data;
using PulsGrada.Models;
using System.Linq;

namespace PulsGrada.Repositories
{
    public class KorisnikRepository : IKorisnikRepository
    {
        private readonly AppDbContext _dbcontext;

        public KorisnikRepository(AppDbContext context)
        {
            _dbcontext = context;
        }

        public Korisnik? DohvatiPoKorisnickomImenu(string korisnickoIme)
        {
            return _dbcontext.Korisnici
                .FirstOrDefault(k => k.KorisnickoIme.ToLower() == korisnickoIme.ToLower());
        }

        public Korisnik? DohvatiPoEmailu(string email)
        {
            return _dbcontext.Korisnici
                .FirstOrDefault(k => k.Email.ToLower() == email.ToLower());
        }

        public bool RegistrirajKorisnika(Korisnik noviKorisnik)
        {
            _dbcontext.Korisnici.Add(noviKorisnik);

            return _dbcontext.SaveChanges() > 0;
        }
    }
}