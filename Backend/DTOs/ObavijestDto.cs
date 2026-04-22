namespace PulsGrada.DTOs
{
    public class ObavijestDto
    {
        public int Id { get; set; }
        public string Naslov { get; set; } = string.Empty;
        public string Sadrzaj { get; set; } = string.Empty;
        public DateTime DatumSlanja { get; set; }
        public bool Procitano { get; set; }
    }
}
