using System.ComponentModel.DataAnnotations.Schema;
namespace PulsGrada.Models
{
/// <summary>
/// Predstavlja entitet korisničke recenzije za određeni lokal.
/// Sadrži brojčanu ocjenu, tekstualni komentar i vremensku oznaku objave.
/// Mapira se na tablicu 'recenzije' u PostgreSQL bazi podataka.
/// </summary>
    [Table("recenzije")]
    public class Recenzija
    {
        public int Id { get; set; }

        [ForeignKey("korisnik_id")]
        public int KorisnikId { get; set; }

        [ForeignKey("lokal_id")]
        public int LokalId { get; set; }

        [Column("ocjena")]
        public int Ocjena { get; set; }

        [Column("komentar")]
        public string Komentar { get; set; } = string.Empty;

        [Column("datum_objave")]
        public DateTime DatumObjave { get; set; }
    }
}
