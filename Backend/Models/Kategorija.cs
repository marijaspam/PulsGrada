using System.ComponentModel.DataAnnotations.Schema;
namespace PulsGrada.Models
{
    /// <summary>
    /// Predstavlja entitet kategorije događaja (npr. koncert, festival, party).
    /// Služi za klasifikaciju i lakše filtriranje događaja unutar aplikacije.
    /// Mapira se na tablicu 'kategorije' u PostgreSQL bazi podataka.
    /// </summary>
    [Table("kategorije")]
    public class Kategorija
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("naziv")]
        public string Naziv { get; set; } = string.Empty;
    }
}
