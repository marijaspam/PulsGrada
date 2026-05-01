using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public interface IDogadajService
    {
        List<DogadajInfoDto> DohvatiSveDogadaje();
        DogadajInfoDto? DohvatiPojediniDogadaj(int id);
        List<DogadajInfoDto> DohvatiDogadajeULokalu(int idLokala);
        List<DogadajInfoDto> PretraziDogadaje(string uneseniPojam);
        List<DogadajInfoDto> FiltrirajDogadaje(
            int? idKvart,
            string? kategorija,
            DateTime? vrijemePocetka
            );
    }
}
