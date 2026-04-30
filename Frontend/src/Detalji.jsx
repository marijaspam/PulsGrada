import React, { useState } from 'react';
import './Detalji.css';
import { Heart } from 'lucide-react';

function Detalji({ podaci, tip }) {
  const [isSpremljeno, setIsSpremljeno] = useState(false);

  // Sigurnosna provjera
  if (!podaci) return <div style={{color: 'white', textAlign: 'center', marginTop: '50px'}}>Učitavanje...</div>;

  return (
    <div className="detalji-container">
      <div className="detalji-header">
        <div className="detalji-info-lijevo">
          <h1>
            {podaci.naslov}{' '}
            {podaci.ocjena && <span className="ocjena-broj">{podaci.ocjena}</span>}
          </h1>

          <ul className="info-lista">
            {podaci.stavke && podaci.stavke.map((stavka, index) => (
              <li key={index}>
                <span className="info-ikona">📍</span> {stavka}
              </li>
            ))}
          </ul>

          <div className="mapa-kontejner">
            <h3>Lokacija</h3>
            <iframe
              src={podaci.mapaUrl}
              width="100%"
              height="300"
              style={{ border: 0, borderRadius: "20px", marginTop: "15px" }}
              allowFullScreen=""
              loading="lazy"
              referrerPolicy="no-referrer-when-downgrade"
              title="Google Mapa"
            ></iframe>
          </div>
        </div>

        <div className="glavna-slika-desno">
          <img src={podaci.glavnaSlika} alt={podaci.naslov} />
        </div>
      </div>

      <div className="akcija-sekcija">
        <button className="btn-omiljeno" onClick={() => setIsSpremljeno(!isSpremljeno)}>
          {isSpremljeno ? "UKLONI IZ OMILJENIH" : "DODAJ U OMILJENO"}
        </button>
        <Heart 
          className="srce-ikona-detalji" 
          size={35} 
          fill={isSpremljeno ? "#ff4d6d" : "none"}
          color="#ff4d6d"
          onClick={() => setIsSpremljeno(!isSpremljeno)}
          style={{cursor: 'pointer'}}
        />
      </div>

      {/* Opis ili Recenzije */}
      <div className="detalji-sadrzaj">
        {tip === 'dogadaj' ? (
          <div className="opis-box">
            <h3>{podaci.podnaslov}</h3>
            <p>{podaci.opis}</p>
          </div>
        ) : (
          <div className="recenzije-sekcija">
            <h3>Recenzije</h3>
            {podaci.recenzije && podaci.recenzije.map((r, i) => (
              <div key={i} className="recenzija-kartica">
                <div className="recenzija-header">
                  <strong>{r.ime}</strong> <span>{"⭐".repeat(r.zvijezdice)}</span>
                </div>
                <p>{r.tekst}</p>
              </div>
            ))}
          </div>
        )}
      </div>

      {/* Galerija slika na dnu */}
      <div className="galerija-grid">
        {podaci.galerija && podaci.galerija.map((slika, index) => (
          <img key={index} src={slika} alt="galerija" className="galerija-slika" />
        ))}
      </div>
    </div>
  );
}

export default Detalji;