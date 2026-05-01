using PulsGrada.Models;

namespace PulsGrada.Repositories
{
    public interface IKvartRepository
    {
        List<Kvart> DohvatiSveKvartove();
    }
}