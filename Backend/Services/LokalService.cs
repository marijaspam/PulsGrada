using PulsGrada.DTOs;
using PulsGrada.Models;
using PulsGrada.Repositories;

namespace PulsGrada.Services
{
    public class LokalService : ILokalService
    {
        private readonly ILokalRepository _lokalRepo;
        public LokalService(ILokalRepository lokalRepo)
        {
            _lokalRepo = lokalRepo;
        }
        public List<LokalInfoDto> DohvatiSveLokale()
        {
            return _lokalRepo.DohvatiSveLokale()
                .Select(l => MapirajULokalInfoDto(l))
                .ToList();
        }
        public LokalInfoDto? DohvatiPojediniLokal(int id)
        {
            var lokal = _lokalRepo.DohvatiPojediniLokal(id);
            if (lokal != null)
            {
                return MapirajULokalInfoDto(lokal);
            }
            else
            {
                return null;
            }
        }
        public List<LokalInfoDto> PretraziLokale(string uneseniPojam)
        {
            if (string.IsNullOrWhiteSpace(uneseniPojam))
            {
                return new List<LokalInfoDto>();
            }
            return _lokalRepo.PretraziLokale(uneseniPojam)
                .Select(l => MapirajULokalInfoDto(l))
                .ToList();

        }
        public List<LokalInfoDto> DohvatiPremiumLokale()
        {
            var premiumLoakli = _lokalRepo.DohvatiPremiumLokale().ToList();
            if(premiumLoakli == null)
            {
                return new List<LokalInfoDto>();
            }
            return premiumLoakli
                .Select(l=>MapirajULokalInfoDto(l))
                .ToList();
        }
        public List<LokalInfoDto> FilterLokala(
            string? adresa,
            bool? imaPusenje,
            bool? imaBiljar,
            bool? imaPikado,
            int? idKvart)
        {
            var lokaliQuery = _lokalRepo.DohvatiSveLokale().AsQueryable();

            if (!string.IsNullOrWhiteSpace(adresa))
            {
                var pojam = adresa.ToLower();
                lokaliQuery = lokaliQuery.Where(l => l.Adresa.ToLower().Contains(pojam));
            }

            if (imaPusenje.HasValue)
            {
                lokaliQuery = lokaliQuery.Where(l => l.ImaPusenje == imaPusenje.Value);
            }

            if (imaBiljar.HasValue)
            {
                lokaliQuery = lokaliQuery.Where(l => l.ImaBiljar == imaBiljar.Value);
            }

            if (imaPikado.HasValue)
            {
                lokaliQuery = lokaliQuery.Where(l => l.ImaPikado == imaPikado.Value);
            }

            if (idKvart.HasValue)
            {
                lokaliQuery = lokaliQuery.Where(l => l.KvartId == idKvart.Value);
            }

            return lokaliQuery
                .ToList()
                .Select(l => MapirajULokalInfoDto(l))
                .ToList();
        }

        private LokalInfoDto MapirajULokalInfoDto(Lokal l)
        {
            return new LokalInfoDto
            {
                Id = l.Id,
                KvartNaziv = l.Kvart?.Naziv ?? "Nepoznat kvart",
                IdKvart = l.KvartId,
                Naziv = l.Naziv,
                Adresa = l.Adresa,
                KordinataX = l.KordinataX,
                KordinataY = l.KordinataY,
                RadnoVrijeme = l.RadnoVrijeme,
                Opis = l.Opis,
                ImaPusenje = l.ImaPusenje,
                ImaBiljar = l.ImaBiljar,
                ImaPikado = l.ImaPikado,
                UrlCjenik = l.UrlCjenik,
                ProsjecnaOcjena = l.ProsjecnaOcjena,
                IsPremium = l.IsPremium,
                UrlSlike = l.UrlSlike

            };
        }
    }   
}
