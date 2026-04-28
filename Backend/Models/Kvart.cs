using System.ComponentModel.DataAnnotations.Schema;

namespace PulsGrada.Models
{
    [Table("kvartovi")]
    public class Kvart
    {
        public int Id { get; set; }
        [Column("naziv")]
        public string Naziv { get; set; } = string.Empty;

    }
}
