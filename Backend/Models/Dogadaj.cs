using System.ComponentModel.DataAnnotations.Schema;

namespace PulsGrada.Models
{
    [Table("dogadaji")]
    public class Dogadaj
    {
        [Column("id")]
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
        public string UrlSlike { get; set; } = string.Empty;

        [ForeignKey("LokalId")]
        public virtual Lokal? Lokal { get; set; }

        [ForeignKey("KategorijaId")]
        public virtual Kategorija? Kategorija { get; set; }

        [ForeignKey("OrganizatorId")]
        public virtual Organizator? Organizator { get; set; }
    }
}