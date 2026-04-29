using PulsGrada.DTOs;
using PulsGrada.Models;
using System.Linq;

namespace PulsGrada.Services
{
    public class MockFavoritService : IFavoritService
    {
        public List<LokalInfoDto> DohvatiFavoriteKorisnika(int idkorisnik)
        {
            var idsFavorita = MockDataStore.Favoriti
                .Where(f => f.KorisnikId == idkorisnik)
                .Select(f => f.LokalId)
                .ToList();

            var omiljeniLokali = MockDataStore.Lokali
                .Where(l => idsFavorita.Contains(l.Id))
                .ToList();

            return omiljeniLokali;
        }

        public bool DodajFavorit(FavoritDto favorit)
        {
            var lokalPostoji = MockDataStore.Lokali.Any(l => l.Id == favorit.LokalId);
            if (!lokalPostoji)
            {
                return false;
            }

            var vecJeFavorit = MockDataStore.Favoriti.Any(
                f => f.KorisnikId == favorit.KorisnikId && f.LokalId == favorit.LokalId
            );

            if (vecJeFavorit)
            {
                return false;
            }

            MockDataStore.Favoriti.Add(new Favorit
            {
                KorisnikId = favorit.KorisnikId,
                LokalId = favorit.LokalId
            });

            return true;
        }

        public bool ObrisiFavorit(FavoritDto favorit)
        {
            var ukloniFavorit = MockDataStore.Favoriti.FirstOrDefault(f =>
                f.KorisnikId == favorit.KorisnikId && f.LokalId == favorit.LokalId);

            if (ukloniFavorit == null)
            {
                return false;
            }

            MockDataStore.Favoriti.Remove(ukloniFavorit);
            return true;
        }
    }
}