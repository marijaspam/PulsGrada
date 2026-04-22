namespace PulsGrada.DTOs
{
    public class RecenzijaPrikaz
    {

        public string KorisnickoIme { get; set; } = string.Empty;
        public int Ocjena { get; set; }
        public string Komentar { get; set; } = string.Empty;
        public DateTime DatumObjave { get; set; }
    }
}
