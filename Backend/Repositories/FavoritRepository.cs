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

        public List<Lokal> DohvatiFavoriteKorisnika(int idkorisnik)
        {

            var idsFavorita = _dbcontext.Favoriti
                .Where(f => f.KorisnikId == idkorisnik)
                .Select(f => f.LokalId)
                .ToList();

            return _dbcontext.Lokali
                .Where(l => idsFavorita.Contains(l.Id))
                .ToList();
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

            if (favoritZaUkloniti == null)
            {
                return false;
            }

            _dbcontext.Favoriti.Remove(favoritZaUkloniti);

            return _dbcontext.SaveChanges() > 0;
        }
    }
}