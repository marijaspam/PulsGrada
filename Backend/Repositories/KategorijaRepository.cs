using PulsGrada.Data;
using PulsGrada.Models;

namespace PulsGrada.Repositories
{
    public class KategorijaRepository
    {
        private readonly AppDbContext _dbcontext;
        public KategorijaRepository(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public List<Kategorija> DohvatiSveKategorije()
        {
            return _dbcontext.Kategorije.ToList();
        }
    }
}
