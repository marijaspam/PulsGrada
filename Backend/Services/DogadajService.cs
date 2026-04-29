using PulsGrada.DTOs;
using PulsGrada.Models;
using PulsGrada.Repositories;
using Microsoft.EntityFrameworkCore;

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
            // Dohvaćamo modele iz baze i mapiramo ih u DTO listu
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
            // Filtriramo na temelju stranog ključa LokalId
            return _dogadajRepo.DohvatiSveDogadaje()
                .Where(d => d.LokalId == idLokala)
                .Select(d => MapirajUInfoDto(d))
                .ToList();
        }

        public List<DogadajInfoDto> PretraziDogadaje(string uneseniPojam)
        {
            if (string.IsNullOrWhiteSpace(uneseniPojam))
                return new List<DogadajInfoDto>();

            // Koristimo metodu iz repozitorija za pretragu po nazivu ili opisu
            return _dogadajRepo.PretraziDogadaje(uneseniPojam)
                .Select(d => MapirajUInfoDto(d))
                .ToList();
        }

        public List<DogadajInfoDto> FiltrirajDogadaje(string? naziv, string? kategorija, DateTime? vrijemePocetka)
        {
            // Pretvaramo u AsQueryable kako bismo mogli dinamički slagati filtere
            var dogadajiQuery = _dogadajRepo.DohvatiSveDogadaje().AsQueryable();

            if (!string.IsNullOrWhiteSpace(naziv))
            {
                dogadajiQuery = dogadajiQuery.Where(d => d.Naziv.Contains(naziv, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(kategorija))
            {
                // Dodaj .Naziv nakon d.Kategorija
                dogadajiQuery = dogadajiQuery.Where(d => d.Kategorija != null &&
                                d.Kategorija.Naziv.Contains(kategorija, StringComparison.OrdinalIgnoreCase));
            }

            if (vrijemePocetka.HasValue)
            {
                // Filtriranje po datumu (zanemarujemo sate/minute)
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

                // OVDJE JE BIO PROBLEM:
                // d.Lokal je objekt, moraš dodati .Naziv da dobiješ string
                LokalNaziv = d.Lokal?.Naziv ?? "Nepoznat lokal",

                // d.Kategorija je objekt, moraš dodati .Naziv
                KategorijaNaziv = d.Kategorija?.Naziv ?? "Ostalo",

                // d.Organizator je objekt, moraš dodati .Naziv
                OrganizatorNaziv = d.Organizator?.Naziv ?? "Puls Grada",

                // Pazi na naziv polja: u modelu je UrlSlike
                UrlSlike = d.UrlSlike ?? "default-image.jpg"
            };
        }
    }
}