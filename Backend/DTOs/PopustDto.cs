namespace PulsGrada.DTOs
{
    public class PopustDto
    {
        public int Id { get; set; }
        public string NazivLokala { get; set; } = string.Empty;
        public string Naslov { get; set; } = string.Empty;
        public string OpisPopusta { get; set; } = string.Empty;
        public int PotrebnoBodova { get; set; }
        public DateTime VrijediDo { get; set; }
    }
}
