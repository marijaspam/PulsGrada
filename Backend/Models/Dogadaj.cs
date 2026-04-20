using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Predstavlja entitet događaja koji je povezan s određenim lokalom.
/// Sadrži informacije o nazivu, opisu i vremenu održavanja (timestamp).
/// Implementira One-to-Many relaciju prema entitetu Lokal.

namespace PulsGrada.Models
{
    [Table ("dogadaji")]
    public class Dogadaj
    {
        public int Id { get; set; }

        [Column("lokal_id")]
        public int LokalId { get; set; }

        [Column("organizator_id")]
        public int OrganizatorId { get; set; }

        [Column("kategorija_id")]
        public int KategorijaId { get; set; }

        [Column("naziv")]
        public string Naziv { get; set; } = string.Empty;

        [Column("vrijeme_pocetka")]
        public DateTime VrijemePocetka { get; set; }

        [Column("opis")]
        public string Opis { get; set; } = string.Empty;

        [Column("url_slike")]
        public int UrlSlike { get; set; }
    }
}
