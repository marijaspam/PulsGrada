using PulsGrada.Models;

namespace PulsGrada.Repositories
{
    public interface ILokalRepository
    {
        List<Lokal> DohvatiSveLokale();
        Lokal? DohvatiPojediniLokal(int id);
        List<Lokal> PretraziLokale(string uneseniPojam);
        List<Lokal> DohvatiPremiumLokale();
        List<Lokal> FilterLokala(
            string? adresa,
            bool? imaPusenje,
            bool? imaBiljar,
            bool? imaPikado,
            int? idKvart);
    }
}
