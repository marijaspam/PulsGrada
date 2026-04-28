using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public interface IRecenzijaService
    {
        List<RecenzijaPrikaz> DohvatiSveRecenzije(int IdLokal);
        bool DodajRecenziju(RecenzijaStvaranjeDto NovaRecenzija);
    }
}
