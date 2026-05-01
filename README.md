## Puls grada
Vaš prozor u ritam Zagreba.

Puls grada je inovativna platforma koja premošćuje jaz između mladih željnih autentičnog izlaska i ugostitelja koji žele modernizirati svoje poslovanje. Fokusirana na zagrebačku scenu, aplikacija omogućuje studentima i mladim profesionalcima da u manje od dvije minute pronađu idealan kafić na temelju specifičnih filtera (pikado, biljar, pub kvizovi, dozvoljeno pušenje, ažurni cjenici), dok vlasnicima lokala pruža moćan alat za digitalni marketing i upravljanje događajima.

## Struktura projekta
Projekt je organiziran kao monorepo ili odvojeni klijent/server moduli radi lakšeg skaliranja:

Plaintext
PulsGrada/
├── backend/                # ASP.NET Core Web API (C#)
│   ├── PulsGrada.API/      # Kontroleri, Middleware, DTOs
│   ├── PulsGrada.Core/     # Poslovna logika, Sučelja (Interfaces), Entiteti
│   ├── PulsGrada.Data/     # PostgreSQL pristup (Entity Framework Core)
│   └── PulsGrada.Tests/    # Unit i Integration testovi
├── frontend/               # React aplikacija (SPA)
│   ├── src/
│   │   ├── components/     # Reusable UI komponente (Navbar, Cards, Modals)
│   │   ├── pages/          # Stranice (Home, Profile, Map, Dashboard)
│   │   ├── hooks/          # Custom React hooks za API pozive
│   │   └── context/        # State management (User auth, Global state)
│   └── public/             # Statičke datoteke i ikone
└── docs/                   # Dokumentacija, dijagrami baze i mockupovi
## Tehnološki stog (Tech Stack)
Frontend: React – za dinamično i brzo korisničko iskustvo.

Backend: ASP.NET Core (C#) – za siguran, skalabilan i robustan API.

Baza podataka: PostgreSQL – za pouzdano upravljanje relacijskim podacima i lokacijama.

Dizajn: Figma – vizualni identitet i UI/UX prototip.

## Upute za pokretanje
1. Preduvjeti
.NET 8 SDK

Node.js (LTS verzija)

PostgreSQL instaliran i pokrenut

2. Postavljanje baze i Backenda
Uđite u backend direktorij: cd backend

Konfigurirajte vezu s bazom u appsettings.json pod ConnectionStrings:DefaultConnection.

Pokrenite migracije kako biste kreirali tablice:

Bash
dotnet ef database update
Pokrenite API server:

Bash
dotnet run
API će biti dostupan na: https://localhost:5001

3. Postavljanje Frontenda
Uđite u frontend direktorij: cd frontend

Instalirajte ovisnosti:

Bash
npm install
Pokrenite razvojni server:

Bash
npm start

   *Aplikacija će se otvoriti na: `http://localhost:3000`*

---

## 👥 Tim "Puls grada"

*   **Paula Nikolić (Design):** Voditeljica vizualnog identiteta i UX dizajna. Fokusirana na stvaranje intuitivnog i atraktivnog sučelja koje privlači mlade korisnike.
*   **Marija Božić (Frontend):** Zadužena za implementaciju dizajna u Reactu. Osigurava visoku responzivnost i besprijekoran rad na svim uređajima.
*   **Marija Barišić (Backend):** Razvija srce sustava u ASP.NET-u. Zadužena za arhitekturu baze podataka, API servise i sigurnost platforme.

---

## 📝 Planirane funkcionalnosti (MVP)
- [x] Pretraživanje kafića prema specifičnim sadržajima (biljar, pikado, kvizovi).
- [x] Transparentni podaci o cjenicima i pušačkim zonama.
- [ ] Interaktivna mapa Zagreba s aktualnim događanjima u realnom vremenu.
- [ ] Dashboard za ugostitelje za samostalno uređivanje profila.
