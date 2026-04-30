using PulsGrada.DTOs;
using PulsGrada.Models;

namespace PulsGrada.Services
{
    public interface IKategorijaService
    {
        List<Kategorija> DohvatiSveKategorije();
    }
}
