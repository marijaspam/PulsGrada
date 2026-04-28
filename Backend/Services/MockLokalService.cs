using PulsGrada.DTOs;
using PulsGrada.Models;

namespace PulsGrada.Services
{
    public class MockLokalService : ILokalService
    {
        public List<LokalInfoDto> DohvatiSveLokale()
        {
            return MockDataStore.Lokali.ToList();
        }
        public LokalInfoDto? DohvatiPojediniLokal(int id)
        {
            return MockDataStore.Lokali.FirstOrDefault(l => l.Id == id);
        }
        public List<LokalInfoDto> PretraziLokale(string uneseniPojam)
        {
            if (string.IsNullOrWhiteSpace(uneseniPojam))
            {
                return new List<LokalInfoDto>();
            }
            return MockDataStore.Lokali
                .Where(l => l.Naziv.Contains(uneseniPojam, StringComparison.OrdinalIgnoreCase) ||
                       l.Opis.Contains(uneseniPojam,StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
        public List<LokalInfoDto> DohvatiPremiumLokale()
        {
            return MockDataStore.Lokali.Where(l => l.IsPremuim == true).ToList();
        }
        public List<LokalInfoDto> FilterLokala(
            string? lokacija,
            bool? imaPusenje,
            bool? imaBiljar,
            bool? imaPikado,
            int? idKvart)
        {
            List<LokalInfoDto> lokali = MockDataStore.Lokali;

            if (!string.IsNullOrWhiteSpace(lokacija))
            {
                lokali = lokali.Where(l => l.Adresa.Contains(lokacija, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if(imaPusenje.HasValue)
            {
                lokali = lokali.Where(l => l.ImaPusenje == true).ToList();
            }
            if (imaBiljar.HasValue)
            {
                lokali = lokali.Where(l => l.ImaBiljar == true).ToList();
            }
            if (imaPikado.HasValue)
            {
                lokali = lokali.Where(l => l.ImaPikado == true).ToList();
            }
            if (idKvart.HasValue)
            {
                lokali = lokali.Where(l => l.IdKvart == idKvart.Value).ToList();
            }
            return lokali;
        }
    }
}
