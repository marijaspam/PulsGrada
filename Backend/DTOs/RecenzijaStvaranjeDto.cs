using System.ComponentModel.DataAnnotations;

namespace PulsGrada.DTOs
{
    public class RecenzijaStvaranjeDto
    {
        [Required]
        public int IdLokal { get; set; }

        public int KorisnickId { get; set; }

        [Required]
        [Range(1,5)]
        public int Ocjena { get; set; }

        public string Komentar { get; set; } = string.Empty;

    }
}
