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

        [ForeignKey("kvart_id")]
        public int KvartId { get; set; }

        [ForeignKey("KvartId")]
        public virtual Kvart? Kvart { get; set; }

        [Column("naziv")]
        public string Naziv { get; set; } = string.Empty;

        [Column("adresa")]
        public string Adresa { get; set; } = string.Empty;

        [Column("lat")]
        public double KordinataX { get; set; }

        [Column("lng")]
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

        [Column("url_slike")]
        public string UrlSlike { get; set; } = string.Empty;

        [Column("kategorija_id")]
        public int KategorijaId { get; set; }

        [ForeignKey("KategorijaId")]
        public virtual Kategorija? Kategorija { get; set; }

        [NotMapped]
        public double ProsjecnaOcjena
        {
            get
            {
                if (Recenzije == null || !Recenzije.Any()) return 0;
                return (double)Recenzije.Average(r => r.Ocjena);
            }
        }
        public virtual ICollection<Recenzija> Recenzije { get; set; } = new List<Recenzija>();

    }
}