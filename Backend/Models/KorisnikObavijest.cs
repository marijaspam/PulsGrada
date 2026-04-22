using System.ComponentModel.DataAnnotations.Schema;
namespace PulsGrada.Models
{
    /// <summary>
    /// Među-tablica koja povezuje korisnike s primljenim obavijestima.
    /// Omogućuje slanje iste obavijesti većem broju korisnika (Many-to-Many) 
    /// te praćenje statusa (npr. je li pročitana) za svakog pojedinca.
    /// Mapira se na tablicu 'korisnik_obavijesti' u PostgreSQL bazi podataka.
    /// </summary>
    [Table("korisnik_obavijest")]
    public class KorisnikObavijest
    {
        [Column("korisnik_id")]
        public int KorisnikId { get; set; }

        [Column("obavijest_id")]
        public int ObavijestId { get; set; }

        [Column("procitano")]
        public bool Procitano { get; set; }
    }
}
