using PulsGrada.DTOs;

namespace PulsGrada.Services
{
    public interface ILokalService
    {
        List<LokalInfoDto> DohvatiSveLokale();
        LokalInfoDto DohvatiPojediniLokal(int Id); 
        List<LokalInfoDto> PretraziLokale(string UneseniPojam);
        List<LokalInfoDto> DohvatiPremiumLokale(bool Premium);
        List<LokalInfoDto> FilterLokala(string? Lokacija,bool? ImaPusenje, bool? ImaBiljar,bool? ImaPikado,int? MinOcjena);

    }
}
