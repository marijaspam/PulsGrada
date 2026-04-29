using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public interface IRecenzijaService
    {
        List<RecenzijaPrikaz> DohvatiRecenzijeZaLokal(int idLokal);
        bool DodajRecenziju(RecenzijaStvaranjeDto novaRecenzija);
        bool ObrisiRecenziju(int id);
    }
}
