using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public interface ILokalService
    {
        List<LokalInfoDto> DohvatiSveLokale();
        LokalInfoDto? DohvatiPojediniLokal(int id); 
        List<LokalInfoDto> PretraziLokale(string uneseniPojam);
        List<LokalInfoDto> DohvatiPremiumLokale();
        List<LokalInfoDto> FilterLokala(
            string? adresa,
            bool? imaPusenje, 
            bool? imaBiljar,
            bool? imaPikado,
            int? idKvart);

    }
}
