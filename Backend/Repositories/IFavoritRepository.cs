using PulsGrada.Models;

namespace PulsGrada.Repositories
{
    public interface IFavoritRepository
    {
        public List<Lokal> DohvatiFavoriteKorisnika(int idkorisnik);
        public bool DodajFavorit(Favorit favorit);
        public bool ObrisiFavorit(Favorit favorit);
    }
}
