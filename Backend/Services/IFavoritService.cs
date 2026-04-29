using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public interface IFavoritService
    {
        public List<LokalInfoDto> DohvatiFavoriteKorisnika(int idkorisnik);
        public bool DodajFavorit(FavoritDto favorit);
        public bool ObrisiFavorit(FavoritDto favorit);
    }
}
