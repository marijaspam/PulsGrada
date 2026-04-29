using PulsGrada.DTOs;
using PulsGrada.Models;

namespace PulsGrada.Services
{

    public static class MockDataStore
    {
        public static List<LokalInfoDto> Lokali = new List<LokalInfoDto>
        {
            new LokalInfoDto {
                Id = 1,
                Naziv = "Caffe Bar Puls",
                Adresa = "Maksimirska cesta 10, Zagreb",
                KordinataX = 15.9819,
                KordinataY = 45.8150,
                RadnoVrijeme = "07:00 - 23:00",
                Opis = "Legendarno mjesto u kvartu s najboljom terasom i pogledom na park. Poznati po vrhunskoj kavi i opuštenoj atmosferi.",
                ImaPusenje = true,
                ImaBiljar = false,
                ImaPikado = false,
                UrlCjenik = "https://puls-grada.hr/cjenik/puls.pdf",
                ProsjecnaOcjena = 4.8,
                BrojRecenzija = 124
            },
            new LokalInfoDto {
                Id = 2,
                Naziv = "Arena Score Pub",
                Adresa = "Ulica Vice Vukova 6, Zagreb",
                KordinataX = 15.9390,
                KordinataY = 45.7725,
                RadnoVrijeme = "09:00 - 02:00",
                Opis = "Mjesto za prave ljubitelje sporta. Gledanje utakmica na velikim ekranima uz biljar i pikado turnire svakog vikenda.",
                ImaPusenje = true,
                ImaBiljar = true,
                ImaPikado = true,
                UrlCjenik = "https://puls-grada.hr/cjenik/arena-score.pdf",
                ProsjecnaOcjena = 4.3,
                BrojRecenzija = 89
            },
            new LokalInfoDto {
                Id = 3,
                Naziv = "Lounge Bar Sky",
                Adresa = "Radnička cesta 52, Zagreb",
                KordinataX = 15.9960,
                KordinataY = 45.8055,
                RadnoVrijeme = "08:00 - 00:00",
                Opis = "Moderan interijer u poslovnoj zoni. Idealno za after-work druženja. Prostor je u potpunosti nepušački s naglaskom na craft koktele.",
                ImaPusenje = false,
                ImaBiljar = false,
                ImaPikado = false,
                UrlCjenik = "https://puls-grada.hr/cjenik/sky-lounge.pdf",
                ProsjecnaOcjena = 4.6,
                BrojRecenzija = 56
            }
        }; 

        public static List<DogadajInfoDto> Dogadaji = new List<DogadajInfoDto>
        {
            new DogadajInfoDto {
                Id = 1,
                LokalNaziv = "Caffe Bar Puls",
                OrganizatorNaziv = "Puls Grada Tim",
                KategorijaNaziv = "Kviz",
                NazivDogadaja = "Retro Pub Kviz 80-ih",
                VrijemePocetka = new DateTime(2026, 4, 30, 20, 0, 0),
                Opis = "Vratite se s nama u osamdesete! Nagrade za najbolje ekipe i tematska glazba cijelu večer.",
                UrlSlike = "https://images.unsplash.com/photo-1511671782779-c97d3d27a1d4"
            },
            new DogadajInfoDto {
                Id = 2,
                LokalNaziv = "Arena Score Pub",
                OrganizatorNaziv = "Udruga Pivopija",
                KategorijaNaziv = "Party",
                NazivDogadaja = "Praznik rada uz Rock & Beer",
                VrijemePocetka = new DateTime(2026, 5, 1, 19, 0, 0),
                Opis = "Proslavite 1. maj uz live rock bend i promotivne cijene domaćih craft piva.",
                UrlSlike = "https://images.unsplash.com/photo-1514525253361-bee871871771"
            },
            new DogadajInfoDto {
                Id = 3,
                LokalNaziv = "Lounge Bar Sky",
                OrganizatorNaziv = "Sky Events",
                KategorijaNaziv = "Koncert",
                NazivDogadaja = "Smooth Jazz Night",
                VrijemePocetka = new DateTime(2026, 5, 2, 21, 0, 0),
                Opis = "Opuštajući zvuci saksofona i najbolji kokteli u gradu. Savršen završetak tjedna.",
                UrlSlike = "https://images.unsplash.com/photo-1511192336575-5a79af67a629"
            }
        };

        public static List<RecenzijaPrikaz> Recenzije = new List<RecenzijaPrikaz>
        {

            new RecenzijaPrikaz { IdLokal = 1, KorisnickoIme = "Ana", Ocjena = 5, Komentar = "Super!", DatumObjave = DateTime.Now },
            new RecenzijaPrikaz { IdLokal = 2, KorisnickoIme = "Marko", Ocjena = 4, Komentar = "Dobro je.", DatumObjave = DateTime.Now }
        };
        public static List<Korisnik> Korisnici = new List<Korisnik>
    {
        new Korisnik
        {
            Id = 1,
            KorisnickoIme = "testko",
            Ime = "Test",
            Prezime = "Korisnik",
            Email = "test@pulsgrada.hr",
            Lozinka = "12345678",
            DatumRegistracije = DateTime.Now.AddMonths(-2)
        },
        new Korisnik
        {
            Id = 2,
            KorisnickoIme = "admin",
            Ime = "Glavni",
            Prezime = "Administrator",
            Email = "admin@pulsgrada.hr",
            Lozinka = "admin123",
            DatumRegistracije = DateTime.Now.AddDays(-10)
        }
    };
        public static List<Favorit> Favoriti = new List<Favorit>
        {
            new Favorit { KorisnikId = 1, LokalId = 1 }, 
            new Favorit { KorisnikId = 1, LokalId = 3 }, 
            new Favorit { KorisnikId = 2, LokalId = 2 } 
        };
    }
}