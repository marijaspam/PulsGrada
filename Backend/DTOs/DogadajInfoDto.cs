namespace PulsGrada.DTOs
{
    public class DogadajInfoDto
    {
        public int Id { get; set; }
        public string LokalNaziv { get; set; } = string.Empty;
        public string OrganizatorNaziv { get; set; } = string.Empty;
        public string KategorijaNaziv { get; set; } = string.Empty;
        public string NazivDogadaja { get; set; } = string.Empty;
        public DateTime VrijemePocetka { get; set; }
        public string Opis { get; set; } = string.Empty;
        public string UrlSlike { get; set; } = string.Empty;
    }
}
