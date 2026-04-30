using PulsGrada.Models;
namespace PulsGrada.Repositories
{
    public interface IKategorijaRepository
    {
        List<Kategorija> DohvatiSveKategorije();
    }
}
