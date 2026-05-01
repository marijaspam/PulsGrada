using PulsGrada.Data;
using PulsGrada.Models;
using Microsoft.EntityFrameworkCore;

namespace PulsGrada.Repositories
{
    public class LokalRepository : ILokalRepository
    {
        private readonly AppDbContext _dbcontext;

        public LokalRepository(AppDbContext context)
        {
            _dbcontext = context;
        }

        public List<Lokal> DohvatiSveLokale()
        {
            return _dbcontext.Lokali
                .Include(l => l.Kvart) 
                .ToList();
        }

        public Lokal? DohvatiPojediniLokal(int id)
        {
            return _dbcontext.Lokali
                .Include(l => l.Kvart)
                .FirstOrDefault(l => l.Id == id);
        }

        public List<Lokal> PretraziLokale(string uneseniPojam)
        {
            if (string.IsNullOrWhiteSpace(uneseniPojam))
            {
                return new List<Lokal>();
            }

            var pojam = uneseniPojam.ToLower();

            return _dbcontext.Lokali
                .Include(l => l.Kvart)
                .Where(l => l.Naziv.ToLower().Contains(pojam) ||
                            (l.Opis != null && l.Opis.ToLower().Contains(pojam)))
                .ToList();
        }

        public List<Lokal> DohvatiPremiumLokale()
        {
            return _dbcontext.Lokali
                .Include(l => l.Kvart)
                .Where(l => l.IsPremium)
                .ToList();
        }

        public List<Lokal> FilterLokala(
            string? adresa,
            bool? imaPusenje,
            bool? imaBiljar,
            bool? imaPikado,
            int? idKvart)
        {
            var upit = _dbcontext.Lokali
                .Include(l => l.Kvart)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(adresa))
            {
                upit = upit.Where(l => l.Adresa.ToLower().Contains(adresa.ToLower()));
            }

            if (imaPusenje == true)
            {
                upit = upit.Where(l => l.ImaPusenje == true);
            }

            if (imaBiljar == true)
            {
                upit = upit.Where(l => l.ImaBiljar == true);
            }

            if (imaPikado == true)
            {
                upit = upit.Where(l => l.ImaPikado == true);
            }

            if (idKvart.HasValue)
            {
                upit = upit.Where(l => l.KvartId == idKvart.Value);
            }

            return upit.ToList();
        }
    }
}