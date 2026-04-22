using System.ComponentModel.DataAnnotations;
namespace PulsGrada.DTOs
{
    public class RegistracijaDto
    {
        [Required]
        public string KorisnickoIme { get; set; } = string.Empty;

        [Required]
        public string Ime { get; set; } = string.Empty;

        [Required]
        public string Prezime { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        public string Lozinka { get; set; } = string.Empty;

        [Required]
        [Compare("Lozinka")]
        public string PonovljenaLozinka { get; set; } = string.Empty;
    }
}
