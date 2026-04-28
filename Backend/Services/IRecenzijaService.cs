using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public interface IRecenzijaService
    {
        List<RecenzijaPrikaz> DohvatiSveRecenzije(int idLokal);
        bool DodajRecenziju(RecenzijaStvaranjeDto novaRecenzija);
        bool ObrisiRecenziju(int id);
    }
}
