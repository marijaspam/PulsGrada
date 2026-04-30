using PulsGrada.DTOs;
using PulsGrada.Models;
using PulsGrada.Repositories;

namespace PulsGrada.Services
{
    public class FavoritService : IFavoritService
    {
        private readonly IFavoritRepository _favoritRepo;

        public FavoritService(IFavoritRepository favoritRepo)
        {
            _favoritRepo = favoritRepo;
        }

        public List<LokalInfoDto> DohvatiFavoriteKorisnika(int idkorisnik)
        {
            var favoriti = _favoritRepo.DohvatiFavoriteKorisnika(idkorisnik);

            return favoriti
                .Where(f => f.Lokal != null)
                .Select(f => new LokalInfoDto
                {
                    Id = f.Lokal!.Id,
                    Naziv = f.Lokal.Naziv,
                    Adresa = f.Lokal.Adresa,
                    Opis = f.Lokal.Opis,
                    UrlSlike = f.Lokal.UrlSlike,
                    ProsjecnaOcjena = f.Lokal.ProsjecnaOcjena
                }).ToList();
        }

        public bool DodajFavorit(FavoritDto favoritDto)
        {
            var postojeci = _favoritRepo.DohvatiFavorit(favoritDto.KorisnikId, favoritDto.LokalId);

            if (postojeci != null) return false;

            var noviFavorit = new Favorit
            {
                KorisnikId = favoritDto.KorisnikId,
                LokalId = favoritDto.LokalId
            };

            return _favoritRepo.DodajFavorit(noviFavorit);
        }

        public bool ObrisiFavorit(FavoritDto favoritDto)
        {
            var favorit = _favoritRepo.DohvatiFavorit(favoritDto.KorisnikId, favoritDto.LokalId);

            if (favorit == null) return false;

            return _favoritRepo.ObrisiFavorit(favorit);
        }
    }
}