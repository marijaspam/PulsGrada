using PulsGrada.Data;
using PulsGrada.Models;
using PulsGrada.Services;

namespace PulsGrada.Repositories
{
    public class RecenzijaRepository : IRecenzijaRepository
    {
        private readonly AppDbContext _dbcontext;

        public RecenzijaRepository(AppDbContext context)
        {
            _dbcontext = context;
        }

        public List<Recenzija> DohvatiRecenzijeZaLokal(int idLokal)
        {
            return _dbcontext.Recenzije
                .Where(r => r.LokalId == idLokal)
                .ToList();
        }

        public bool DodajRecenziju(Recenzija novaRecenzija)
        {
            novaRecenzija.DatumObjave = DateTime.Now;

            _dbcontext.Recenzije.Add(novaRecenzija);

            return _dbcontext.SaveChanges() > 0;
        }

        public bool ObrisiRecenziju(int id)
        {
            var recenzija = _dbcontext.Recenzije.FirstOrDefault(r => r.Id == id);

            if (recenzija == null) return false;

            _dbcontext.Recenzije.Remove(recenzija);

            return _dbcontext.SaveChanges() > 0;
        }
    }
}
