using System.ComponentModel.DataAnnotations.Schema;
namespace PulsGrada.Models
{
    /// <summary>
    /// Predstavlja entitet popusta ili posebne ponude unutar lokala.
    /// Sadrži informacije o iznosu popusta, opisu pogodnosti i uvjetima korištenja.
    /// Mapira se na tablicu 'popusti' u PostgreSQL bazi podataka.
    /// </summary>
    [Table("popusti")]
    public class Popust
    {
        public int Id { get; set; }

        [Column("lokal_id")]
        public int LokalId { get; set; }

        [Column("korisnik_id")]
        public int KorisnikId { get; set; }

        [Column("naslov")]
        public string Naslov { get; set; } = string.Empty;

        [Column("opis_popusta")]
        public string OpisPopusta { get; set; } = string.Empty;

        [Column("iskoristenost")]
        public bool Iskoristenost { get; set; }

        [Column("potrebno_bodova")]
        public int PotrebnoBodova { get; set; }

        [Column("vrijedi_do")]
        public DateTime VrijediDo { get; set; }
    }
}
