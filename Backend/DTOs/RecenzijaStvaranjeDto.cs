using System.ComponentModel.DataAnnotations;

namespace PulsGrada.DTOs
{
    public class RecenzijaStvaranjeDto
    {
        [Required]
        public int LokalId { get; set; }

        public string Korisnickoime { get; set; } = string.Empty;

        [Required]
        [Range(1,5)]
        public int Ocjena { get; set; }

        public string Komentar { get; set; } = string.Empty;

    }
}
