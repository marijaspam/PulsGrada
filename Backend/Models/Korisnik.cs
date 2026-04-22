using System.ComponentModel.DataAnnotations.Schema;
namespace PulsGrada.Models
{
    /// <summary>
    /// Predstavlja entitet korisnika sustava
    /// Mapira se na tablicu 'korisnici' u PostgreSQL bazi podataka.
    /// </summary>
    [Table("korisnici")]
    public class Korisnik
    {
        public int Id { get; set; }

        [Column("korisnicko_ime")]
        public string KorisnickoIme { get; set; } = string.Empty;

        [Column("ime")]
        public string Ime { get; set; } = string.Empty;

        [Column("prezime")]
        public string Prezime { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("lozinka")]
        public string Lozinka { get; set; } = string.Empty;

        [Column("datum_registracije")]
        public DateTime DatumRegistracije { get; set; } 
    }
}
