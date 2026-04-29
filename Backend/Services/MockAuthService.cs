using PulsGrada.DTOs;
using PulsGrada.Models;

namespace PulsGrada.Services
{
    public class MockAuthService:IAuthService
    {
        public Korisnik? Prijava(PrijavaKorisnikaDto podaciPrijave)
        {
            return MockDataStore.Korisnici.FirstOrDefault(k => 
            (k.KorisnickoIme == podaciPrijave.KorisnikIdentifikator || 
            k.Email == podaciPrijave.KorisnikIdentifikator) &&
            k.Lozinka == podaciPrijave.Lozinka
            );
        }
        public string Registracija(RegistracijaDto podaciRegistracija)
        {
            if(MockDataStore.Korisnici.Any(k=>k.Email.Equals(podaciRegistracija.Email)))
            {
                return "Uneseni email vec postoji";
            }
            if (MockDataStore.Korisnici.Any(k => k.KorisnickoIme.Equals(podaciRegistracija.KorisnickoIme)))
            {
                return "Uneseno korisnicko ime vec postoji";
            }
            var noviKorisnik = new Korisnik
            {
                Id = MockDataStore.Korisnici.Any() ? MockDataStore.Korisnici.Max(k => k.Id) + 1 : 1,
                KorisnickoIme = podaciRegistracija.KorisnickoIme,
                Ime = podaciRegistracija.Ime,
                Prezime = podaciRegistracija.Prezime,
                Email = podaciRegistracija.Email,
                Lozinka = podaciRegistracija.Lozinka,
                DatumRegistracije =DateTime.Now
            };
            MockDataStore.Korisnici.Add(noviKorisnik);

            return "Registracija uspješna";
        }
    }
}
