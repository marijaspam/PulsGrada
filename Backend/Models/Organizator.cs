using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Predstavlja entitet organizatora događanja (npr. udruga, agencija ili tvrtka).
/// Sadrži podatke o nazivu, kontakt informacijama i povezanim događajima.
/// Mapira se na tablicu 'organizatori' u PostgreSQL bazi podataka.
/// </summary>
namespace PulsGrada.Models
{
    [Table("organizatori")]
    public class Organizator
    {
        public int Id {get; set;}

        [Column("naziv")]
        public string Naziv { get; set; } = string.Empty;

        [Column("opis")]
        public string Opis{ get; set; } = string.Empty;

        [Column("Kontakt_email")]
        public string KontaktEmail { get; set; } = string.Empty;
    }
}
