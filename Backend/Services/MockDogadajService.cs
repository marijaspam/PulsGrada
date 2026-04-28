using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public class MockDogadajService:IDogadajService
    {
        public List<DogadajInfoDto> DohvatiSveDogadaje() 
        {
            return MockDataStore.Dogadaji.ToList();
        }
        public DogadajInfoDto? DohvatiPojediniDogadaj(int id)
        {
            return MockDataStore.Dogadaji.FirstOrDefault(d => d.Id == id);
        }
        public List<DogadajInfoDto> DohvatiDogadajeULokalu(int idLokala)
        {
            var lokal = MockDataStore.Lokali.FirstOrDefault(l => l.Id == idLokala);
            
            if (lokal == null)
            {
                return new List<DogadajInfoDto>();
            }
            return MockDataStore.Dogadaji.Where(d => d.LokalNaziv==lokal.Naziv).ToList();
        }
        public List<DogadajInfoDto> PretraziDogadaje(string uneseniPojam)
        {
            if(string.IsNullOrWhiteSpace(uneseniPojam))
            {
                return new List<DogadajInfoDto>();
            }

            return MockDataStore.Dogadaji
                .Where(d => d.NazivDogadaja.Contains(uneseniPojam, StringComparison.OrdinalIgnoreCase) ||
                d.Opis.Contains(uneseniPojam, StringComparison.OrdinalIgnoreCase) ||
                d.LokalNaziv.Contains(uneseniPojam, StringComparison.OrdinalIgnoreCase) ||
                d.OrganizatorNaziv.Contains(uneseniPojam, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public List<DogadajInfoDto> FiltrirajDogadaje(
            string? naziv,
            string? kategorija,
            DateTime? vrijemePocetka
            )
        {
            List<DogadajInfoDto> dogadaji = MockDataStore.Dogadaji.ToList();
            if (!string.IsNullOrWhiteSpace(naziv))
            {
                dogadaji = dogadaji.Where(d => d.NazivDogadaja.Contains(naziv, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if(!string.IsNullOrWhiteSpace(kategorija))
            {
                dogadaji = dogadaji.Where(d => d.KategorijaNaziv == kategorija).ToList();
            }
            if(vrijemePocetka != null)
            {
                dogadaji = dogadaji.Where(d => d.VrijemePocetka.Date == vrijemePocetka.Value.Date).ToList();
            }
            return dogadaji;
        }
    }
}
