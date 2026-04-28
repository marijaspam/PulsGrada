using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public class MockKategorijaService : IKategorijaService
    {
        public List<string> DohvatiSveKategorije()
        {
            return MockDataStore.Dogadaji
                .Select(d => d.KategorijaNaziv)
                .Distinct()
                .OrderBy(k => k)
                .ToList();
        }
    }
}
