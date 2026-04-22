namespace PulsGrada.DTOs
{
    public class OrganizatorDto
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public string KontaktEmail { get; set; } = string.Empty;
    }
}
