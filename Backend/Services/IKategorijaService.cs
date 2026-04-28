using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public interface IKategorijaService
    {
        List<KategorijaDto> DohvatiSveKategorije();
    }
}
