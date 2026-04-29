namespace PulsGrada.DTOs
{
    public class LokalInfoDto
    {
        public int Id { get; set; }
        public string KvartNaziv { get; set; } = string.Empty;
        public int IdKvart { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public double KordinataX { get; set; }
        public double KordinataY { get; set; }
        public string RadnoVrijeme { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public bool ImaPusenje { get; set; }
        public bool ImaBiljar { get; set; }
        public bool ImaPikado { get; set; }
        public string UrlCjenik { get; set; } = string.Empty;
        public double ProsjecnaOcjena { get; set; }
        public int BrojRecenzija { get; set; }
        public bool IsPremium { get; set; }
    }
}
