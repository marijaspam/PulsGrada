using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public class MockRecenzijaService : IRecenzijaService
    {
        public List<RecenzijaPrikaz> DohvatiSveRecenzije(int idLokal)
        {
            return MockDataStore.Recenzije.Where(r => r.IdLokal == idLokal).ToList();
        }
        public bool DodajRecenziju(RecenzijaStvaranjeDto novaRecenzija)
        {
            var NovaRecenzija = new RecenzijaPrikaz
            {
                IdLokal = novaRecenzija.IdLokal,
                KorisnickoIme = novaRecenzija.KorisnickoIme,
                Ocjena = novaRecenzija.Ocjena,
                Komentar = novaRecenzija.Komentar,
                DatumObjave = DateTime.Now
            };
            MockDataStore.Recenzije.Add(NovaRecenzija);
            return true;
        }
    }
}
