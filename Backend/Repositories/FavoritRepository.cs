using Microsoft.EntityFrameworkCore;
using PulsGrada.Data;
using PulsGrada.Models;

namespace PulsGrada.Repositories
{
    public class FavoritRepository : IFavoritRepository
    {
        private readonly AppDbContext _dbcontext;

        public FavoritRepository(AppDbContext context)
        {
            _dbcontext = context;
        }

        public List<Favorit> DohvatiFavoriteKorisnika(int idkorisnik)
        {
            return _dbcontext.Favoriti
                .Include(f => f.Lokal!)                 
                .ThenInclude(l => l.Recenzije!)
                .Where(f => f.KorisnikId == idkorisnik)
                .ToList();
        }

        public Favorit? DohvatiFavorit(int idKorisnika, int idLokala)
        {
            return _dbcontext.Favoriti
                .FirstOrDefault(f => f.KorisnikId == idKorisnika && f.LokalId == idLokala);
        }

        public bool DodajFavorit(Favorit favorit)
        {
            var lokalPostoji = _dbcontext.Lokali.Any(l => l.Id == favorit.LokalId);
            if (!lokalPostoji) return false;

            var vecJeFavorit = _dbcontext.Favoriti.Any(f =>
                f.KorisnikId == favorit.KorisnikId &&
                f.LokalId == favorit.LokalId);

            if (vecJeFavorit) return false;

            _dbcontext.Favoriti.Add(favorit);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool ObrisiFavorit(Favorit favorit)
        {
            var favoritZaUkloniti = _dbcontext.Favoriti.FirstOrDefault(f =>
                f.KorisnikId == favorit.KorisnikId &&
                f.LokalId == favorit.LokalId);

            if (favoritZaUkloniti == null) return false;

            _dbcontext.Favoriti.Remove(favoritZaUkloniti);
            return _dbcontext.SaveChanges() > 0;
        }
    }
}