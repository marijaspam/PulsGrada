using PulsGrada.Data;
using PulsGrada.Models;

namespace PulsGrada.Repositories
{
    public class KvartRepository : IKvartRepository
    {
        private readonly AppDbContext _dbcontext;

        public KvartRepository(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public List<Kvart> DohvatiSveKvartove()
        {
            return _dbcontext.Kvartovi.ToList();
        }
    }
}