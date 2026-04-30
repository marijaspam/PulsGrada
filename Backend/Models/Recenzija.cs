using System.ComponentModel.DataAnnotations.Schema;

namespace PulsGrada.Models
{
    [Table("recenzije")]
    public class Recenzija
    {
        public int Id { get; set; }

        [Column("korisnik_id")]
        public int KorisnikId { get; set; }

        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; } = null!;

        [Column("lokal_id")]
        public int LokalId { get; set; }

        [ForeignKey("LokalId")]
        public virtual Lokal Lokal { get; set; } = null!;

        [Column("ocjena")]
        public int Ocjena { get; set; }

        [Column("komentar")]
        public string Komentar { get; set; } = string.Empty;

        [Column("datum_objave")]
        public DateTime DatumObjave { get; set; }
    }
}