using PulsGrada.Models;

namespace PulsGrada.Repositories
{
    public interface IDogadajRepository
    {
        List<Dogadaj> DohvatiSveDogadaje();
        Dogadaj? DohvatiPojediniDogadaj(int id);
        List<Dogadaj> DohvatiDogadajeULokalu(int idLokala);
        List<Dogadaj> PretraziDogadaje(string uneseniPojam);
        List<Dogadaj> FiltrirajDogadaje(
            int? idKvart,
            int? kategorijaId,
            DateTime? vrijemePocetka
            );
    }
}
