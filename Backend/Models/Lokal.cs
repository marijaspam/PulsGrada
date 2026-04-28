using System.ComponentModel.DataAnnotations.Schema;
namespace PulsGrada.Models
{
    /// <summary>
    /// Predstavlja osnovni entitet ugostiteljskog objekta.
    /// Sadrži detaljne informacije o lokalu, njegovim značajkama i pravilima.
    /// Mapira se na tablicu 'lokali' u PostgreSQL bazi podataka.
    /// </summary>
    [Table("lokali")]
    public class Lokal
    {
        public int Id { get; set; }

        [Column("naziv")]
        public string Naziv { get; set; } = string.Empty;

        [Column("adresa")]
        public string Adresa { get; set; } = string.Empty;

        [Column("lokacija")]
        public double KordinataX { get; set; }

        [Column("lokacija")]
        public double KordinataY { get; set; }

        [Column("radno_vrijeme")]
        public string RadnoVrijeme { get; set; } = string.Empty;

        [Column("opis")]
        public string Opis { get; set; } = string.Empty;

        [Column("ima_pusenje")]
        public bool ImaPusenje { get; set; }

        [Column("ima_biljar")]
        public bool ImaBiljar { get; set; }

        [Column("ima_pikado")]
        public bool ImaPikado { get; set; }

        [Column("url_cjenik")]
        public string UrlCjenik { get; set; } = string.Empty;

        [Column("is_premium")]
        public bool IsPremium { get; set; }
    }
}