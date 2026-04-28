using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public interface IDogadajService
    {
        List<DogadajInfoDto> DohvatiSveDogadaje();
        DogadajInfoDto DohvatiPojediniDogadaj(int Id);
        List<DogadajInfoDto> DohvatiDogadajeULokalu(int IdLokala);
        List<DogadajInfoDto> PretraziDogadaje(string UneseniPojam);
        List<DogadajInfoDto> DohvatiPremiumDogadaj(bool Premium);
        List<DogadajInfoDto> FiltrirajDogadaje(
            string? Naziv,
            string? Kategorija,
            DateTime? VrijemePocetka
            );


    }
}
