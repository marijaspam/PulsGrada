using PulsGrada.DTOs;
using PulsGrada.Models;
using PulsGrada.Repositories;

namespace PulsGrada.Services
{
    public class RecenzijaService : IRecenzijaService
    {
        private readonly IRecenzijaRepository _recenzijaRepo;

        public RecenzijaService(IRecenzijaRepository recenzijaRepo)
        {
            _recenzijaRepo = recenzijaRepo;
        }

        public List<RecenzijaPrikaz> DohvatiRecenzijeZaLokal(int idLokal)
        {
            var recenzije = _recenzijaRepo.DohvatiRecenzijeZaLokal(idLokal);

            return recenzije.Select(r => new RecenzijaPrikaz
            {
                IdLokal = r.LokalId,
                Komentar = r.Komentar,
                Ocjena = r.Ocjena,
                KorisnickoIme = r.Korisnik?.Ime ?? "Anonimno",
                DatumObjave = DateTime.Now
            }).ToList();
        }

        public bool DodajRecenziju(RecenzijaStvaranjeDto novaRecenzija)
        {

            var recenzijaModel = new Recenzija
            {
                KorisnikId = novaRecenzija.KorisnickId,
                LokalId = novaRecenzija.IdLokal,
                Komentar = novaRecenzija.Komentar,
                Ocjena = novaRecenzija.Ocjena,
                DatumObjave = DateTime.Now 
            };

            return _recenzijaRepo.DodajRecenziju(recenzijaModel);
        }

        public bool ObrisiRecenziju(int id)
        {
            return _recenzijaRepo.ObrisiRecenziju(id);
        }
    }
}