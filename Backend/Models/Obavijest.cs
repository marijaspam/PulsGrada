using System.ComponentModel.DataAnnotations.Schema;
namespace PulsGrada.Models
{
    /// <summary>
    /// Predstavlja entitet sustavne ili korisničke obavijesti.
    /// Sadrži naslov, sadržaj poruke i metapodatke o vremenu slanja.
    /// Mapira se na tablicu 'obavijesti' u PostgreSQL bazi podataka.
    /// </summary>
    [Table("obavijesti")]
    public class Obavijest
    {
        public int Id { get; set; }

        [Column("naslov")]
        public string Naslov { get; set; } = string.Empty;

        [Column("sadrzaj")]
        public string Sadrzaj { get; set; } = string.Empty;

        [Column("datum_slanja")]
        public DateTime DatumSlanja { get; set; } 
    }
}
