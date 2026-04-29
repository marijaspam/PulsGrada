using PulsGrada.Models;

namespace PulsGrada.Repositories
{
    public interface IRecenzijaRepository
    {
        List<Recenzija> DohvatiRecenzijeZaLokal(int idLokal);
        bool DodajRecenziju(Recenzija novaRecenzija);
        bool ObrisiRecenziju(int id);
    }
}
