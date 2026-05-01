using PulsGrada.Data;
using PulsGrada.Models;
using Microsoft.EntityFrameworkCore;

namespace PulsGrada.Repositories
{
    public class DogadajRepository : IDogadajRepository
    {
        private readonly AppDbContext _dbContext;

        public DogadajRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Dogadaj> DohvatiSveDogadaje()
        {
            return _dbContext.Dogadaji
                .Include(d => d.Lokal)
                .Include(d => d.Organizator)
                .Include(d => d.Kategorija)
                .ToList();
        }

        public Dogadaj? DohvatiPojediniDogadaj(int id)
        {
            return _dbContext.Dogadaji
                .Include(d => d.Lokal)
                .Include(d => d.Organizator)
                .Include(d => d.Kategorija)
                .FirstOrDefault(d => d.Id == id);
        }

        public List<Dogadaj> DohvatiDogadajeULokalu(int idLokala)
        {
            return _dbContext.Dogadaji
            .Include(d => d.Lokal)
            .Include(d => d.Organizator)
            .Include(d => d.Kategorija)
            .Where(d => d.LokalId == idLokala)
            .ToList();
        }

        public List<Dogadaj> PretraziDogadaje(string uneseniPojam)
        {
            if (string.IsNullOrWhiteSpace(uneseniPojam)) return new List<Dogadaj>();

            var pojam = uneseniPojam.ToLower();

            return _dbContext.Dogadaji
                .Include(d => d.Lokal)
                .Include(d => d.Organizator) 
                .Include(d => d.Kategorija)  
                .Where(d => d.Naziv.ToLower().Contains(pojam) ||
                            d.Opis.ToLower().Contains(pojam))
                .ToList();
        }

        public List<Dogadaj> FiltrirajDogadaje(
            int? idKvart,
            int? kategorijaId, 
            DateTime? vrijemePocetka)
        {
            var upit = _dbContext.Dogadaji
            .Include(d => d.Lokal)
            .Include(d => d.Organizator)
            .Include(d => d.Kategorija)
            .AsQueryable();

            if (idKvart.HasValue)
            {
                upit = upit.Where(d => d.Lokal != null && d.Lokal.KvartId == idKvart.Value);
            }

            if (kategorijaId.HasValue)
            {
                upit = upit.Where(d => d.KategorijaId == kategorijaId.Value);
            }

            if (vrijemePocetka.HasValue)
            {
                upit = upit.Where(d => d.VrijemePocetka.Date == vrijemePocetka.Value.Date);
            }

            return upit.ToList();
        }
    }
}