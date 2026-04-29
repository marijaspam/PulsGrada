
-- 1. BRISANJE SVIH POSTOJEĆIH TABLICA (Clean Start)
DROP TABLE IF EXISTS korisnik_obavijest, favoriti, recenzije, popusti, dogadaji, kategorije, organizatori, lokali, kvartovi, obavijesti, korisnici CASCADE;

-- 2. KORISNICI
CREATE TABLE korisnici (
    id SERIAL PRIMARY KEY,
    korisnicko_ime VARCHAR(50) UNIQUE NOT NULL,
    ime VARCHAR(50),
    prezime VARCHAR(50),
    email VARCHAR(100) UNIQUE NOT NULL,
    lozinka_hash TEXT NOT NULL,
    datum_registracije TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 3. KVARTOVI (Za filtriranje po lokaciji)
CREATE TABLE kvartovi (
    id SERIAL PRIMARY KEY,
    naziv VARCHAR(100) NOT NULL
);

-- 4. LOKALI 
CREATE TABLE lokali (
    id SERIAL PRIMARY KEY,
    kvart_id INTEGER REFERENCES kvartovi(id) ON DELETE SET NULL,
    naziv VARCHAR(100) NOT NULL,
    adresa TEXT,
    lat DOUBLE PRECISION, -- Geografska širina za ASP.NET/Leaflet
    lng DOUBLE PRECISION, -- Geografska dužina za ASP.NET/Leaflet
    radno_vrijeme TEXT,
    opis TEXT,
    ima_pusenje BOOLEAN DEFAULT false,
    ima_biljar BOOLEAN DEFAULT false,
    ima_pikado BOOLEAN DEFAULT false,
    url_cjenik TEXT,
    is_premium BOOLEAN DEFAULT false,
    url_slika VARCHAR(500) DEFAULT ''
);

-- 5. ORGANIZATORI
CREATE TABLE organizatori (
    id SERIAL PRIMARY KEY,
    naziv VARCHAR(100) NOT NULL,
    opis TEXT,
    kontakt_email VARCHAR(100)
);

-- 6. KATEGORIJE (Koncert, Kviz, Party...)
CREATE TABLE kategorije (
    id SERIAL PRIMARY KEY,
    naziv VARCHAR(50) NOT NULL
);

-- 7. DOGAĐAJI
CREATE TABLE dogadaji (
    id SERIAL PRIMARY KEY,
    lokal_id INTEGER REFERENCES lokali(id) ON DELETE CASCADE,
    organizator_id INTEGER REFERENCES organizatori(id) ON DELETE SET NULL,
    kategorija_id INTEGER REFERENCES kategorije(id) ON DELETE SET NULL,
    naziv VARCHAR(100) NOT NULL,
    vrijeme_pocetka TIMESTAMP NOT NULL,
    opis TEXT,
    url_slike TEXT
);

-- 8. OBAVIJESTI 
CREATE TABLE obavijesti (
    id SERIAL PRIMARY KEY,
    naslov VARCHAR(100),
    sadrzaj TEXT NOT NULL,
    datum_slanja TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 9. POPUSTI 
CREATE TABLE popusti (
    id SERIAL PRIMARY KEY,
    lokal_id INTEGER REFERENCES lokali(id) ON DELETE CASCADE,
    korisnik_id INTEGER REFERENCES korisnici(id) ON DELETE CASCADE,
    naslov VARCHAR(100),
    opis_popusta TEXT NOT NULL,
    iskoristenost BOOLEAN DEFAULT false,
    vrijedi_do TIMESTAMP
);

-- 10. MEĐUTABLICE (N:M veze)

-- Veza Korisnici <-> Obavijesti
CREATE TABLE korisnik_obavijest (
    korisnik_id INTEGER REFERENCES korisnici(id) ON DELETE CASCADE,
    obavijest_id INTEGER REFERENCES obavijesti(id) ON DELETE CASCADE,
    procitano BOOLEAN DEFAULT false,
    PRIMARY KEY (korisnik_id, obavijest_id)
);

-- Veza Korisnici <-> Favoriti (Lokali)
CREATE TABLE favoriti (
    korisnik_id INTEGER REFERENCES korisnici(id) ON DELETE CASCADE,
    lokal_id INTEGER REFERENCES lokali(id) ON DELETE CASCADE,
    PRIMARY KEY (korisnik_id, lokal_id)
);

-- 11. RECENZIJE
CREATE TABLE recenzije (
    id SERIAL PRIMARY KEY,
    korisnik_id INTEGER REFERENCES korisnici(id) ON DELETE SET NULL,
    lokal_id INTEGER REFERENCES lokali(id) ON DELETE CASCADE,
    ocjena INTEGER CHECK (ocjena >= 1 AND ocjena <= 5),
    komentar TEXT,
    datum_objave TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);