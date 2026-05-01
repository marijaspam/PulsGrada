using PulsGrada.Models;
using PulsGrada.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PulsGrada.Services
{
    public class KvartService : IKvartService
    {
        private readonly IKvartRepository _kvartRepo;

        public KvartService(IKvartRepository kvartRepo)
        {
            _kvartRepo = kvartRepo;
        }

        public List<Kvart> DohvatiSveKvartove()
        {
            var kvartovi = _kvartRepo.DohvatiSveKvartove();
            return kvartovi.ToList();
        }
    }
}