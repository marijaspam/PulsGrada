using System.ComponentModel.DataAnnotations;

namespace PulsGrada.DTOs
{
    public class PrijavaKorisnikaDto
    {
        [Required]
        public string KorisnikIdentifikator { get; set; } = string.Empty;

        [Required]
        public string Lozinka { get; set; } = string.Empty;
    }
}
