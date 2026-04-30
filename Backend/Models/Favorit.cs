using System.ComponentModel.DataAnnotations.Schema;
namespace PulsGrada.Models
{
    /// <summary>
    /// Među-tablica koja povezuje korisnike i njihove omiljene lokale.
    /// Implementira Many-to-Many relaciju između entiteta Korisnik i Lokal.
    /// Mapira se na tablicu 'favoriti' u PostgreSQL bazi podataka.
    /// </summary>
    [Table("favoriti")]
    public class Favorit
    {
        [Column("korisnik_id")]
        public int KorisnikId { get; set; }

        [Column("lokal_id")]
        public int LokalId { get; set; }

        [ForeignKey("LokalId")]
        public virtual Lokal? Lokal { get; set; } = null;
    }
}
