using PulsGrada.DTOs;
using PulsGrada.Models;
using PulsGrada.Repositories;


namespace PulsGrada.Services
{
    public class DogadajService : IDogadajService
    {
        private readonly IDogadajRepository _dogadajRepo;

        public DogadajService(IDogadajRepository dogadajRepo)
        {
            _dogadajRepo = dogadajRepo;
        }

        public List<DogadajInfoDto> DohvatiSveDogadaje()
        {
            return _dogadajRepo.DohvatiSveDogadaje()
                .Select(d => MapirajUInfoDto(d))
                .ToList();
        }

        public DogadajInfoDto? DohvatiPojediniDogadaj(int id)
        {
            var dogadaj = _dogadajRepo.DohvatiPojediniDogadaj(id);
            return dogadaj != null ? MapirajUInfoDto(dogadaj) : null;
        }

        public List<DogadajInfoDto> DohvatiDogadajeULokalu(int idLokala)
        {
            return _dogadajRepo.DohvatiSveDogadaje()
                .Where(d => d.LokalId == idLokala)
                .Select(d => MapirajUInfoDto(d))
                .ToList();
        }

        public List<DogadajInfoDto> PretraziDogadaje(string uneseniPojam)
        {
            if (string.IsNullOrWhiteSpace(uneseniPojam))
                return new List<DogadajInfoDto>();

            return _dogadajRepo.PretraziDogadaje(uneseniPojam)
                .Select(d => MapirajUInfoDto(d))
                .ToList();
        }

        public List<DogadajInfoDto> FiltrirajDogadaje(string? naziv, string? kategorija, DateTime? vrijemePocetka)
        {
            var dogadajiQuery = _dogadajRepo.DohvatiSveDogadaje().AsQueryable();

            if (!string.IsNullOrWhiteSpace(naziv))
            {
                dogadajiQuery = dogadajiQuery.Where(d => d.Naziv.Contains(naziv, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(kategorija))
            {
                dogadajiQuery = dogadajiQuery.Where(d => d.Kategorija != null &&
                                d.Kategorija.Naziv.Contains(kategorija, StringComparison.OrdinalIgnoreCase));
            }

            if (vrijemePocetka.HasValue)
            {
                dogadajiQuery = dogadajiQuery.Where(d => d.VrijemePocetka.Date == vrijemePocetka.Value.Date);
            }

            return dogadajiQuery.Select(d => MapirajUInfoDto(d)).ToList();
        }

        /// <summary>
        /// Pomoćna metoda za pretvorbu Modela (Baza) u DTO (Frontend)
        /// </summary>
        private DogadajInfoDto MapirajUInfoDto(Dogadaj d)
        {
            return new DogadajInfoDto
            {
                Id = d.Id,
                NazivDogadaja = d.Naziv,
                Opis = d.Opis ?? "Nema opisa",
                VrijemePocetka = d.VrijemePocetka,

                LokalNaziv = d.Lokal?.Naziv ?? "Nepoznat lokal",

                KategorijaNaziv = d.Kategorija?.Naziv ?? "Ostalo",

                OrganizatorNaziv = d.Organizator?.Naziv ?? "Nepoznat organizator",

                UrlSlike = d.UrlSlike ?? "default-image.jpg"
            };
        }
    }
}