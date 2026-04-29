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
            return _dbContext.Dogadaji.ToList();
        }

        public Dogadaj? DohvatiPojediniDogadaj(int id)
        {
            return _dbContext.Dogadaji.FirstOrDefault(d => d.Id == id);
        }

        public List<Dogadaj> DohvatiDogadajeULokalu(int idLokala)
        {
            return _dbContext.Dogadaji.Where(d => d.LokalId == idLokala).ToList();
        }

        public List<Dogadaj> PretraziDogadaje(string uneseniPojam)
        {
            if (string.IsNullOrWhiteSpace(uneseniPojam)) return new List<Dogadaj>();

            var pojam = uneseniPojam.ToLower();

            return _dbContext.Dogadaji
                .Where(d => d.Naziv.ToLower().Contains(pojam) ||
                            d.Opis.ToLower().Contains(pojam))
                .ToList();
        }

        public List<Dogadaj> FiltrirajDogadaje(
            string? naziv,
            int? kategorijaId, 
            DateTime? vrijemePocetka)
        {
            var upit = _dbContext.Dogadaji.AsQueryable();

            if (!string.IsNullOrWhiteSpace(naziv))
            {
                upit = upit.Where(d => d.Naziv.ToLower().Contains(naziv.ToLower()));
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