using PulsGrada.DTOs;
using PulsGrada.Models;
using PulsGrada.Repositories;
using Microsoft.EntityFrameworkCore;
namespace PulsGrada.Services
{
    public class KategorijaService :IKategorijaService
    {
        private readonly IKategorijaRepository _kategorijaRepo;

        public KategorijaService(IKategorijaRepository kategorijaRepo)
        {
            _kategorijaRepo = kategorijaRepo;
        }
        public List<Kategorija> DohvatiSveKategorije()
        {
            var KategorijeIzBaze = _kategorijaRepo.DohvatiSveKategorije().ToList();
            return KategorijeIzBaze;
        }
    }
}
