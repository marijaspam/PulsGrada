import React from 'react';
import { fejkBaza } from './baza';
import { UserCircle } from 'lucide-react'; // Placeholder ikona
import './Profil.css';

function Profil() {
  const omiljeniKratko = Object.values(fejkBaza).slice(0, 4);

  return (
    <div className="profil-kontejner">
      <header className="profil-header">
        <div className="profil-avatar-okvir">
          <UserCircle color="#FF5A7E" size={120} strokeWidth={1} />
        </div>
        <div className="profil-podaci">
          <h1>Ana Horvat</h1>
          <p>anci94</p>
        </div>
        <button className="odjava-link">Odjava</button>
      </header>

      <section className="profil-sekcija">
        <h2>Omiljeno</h2>
        <div className="profil-omiljeno-red">
            {omiljeniKratko.map((stavka, index) => (
                <div key={index} className="profil-kvadrat-kartica">
                    <img src={stavka.slika} alt={stavka.naslov} />
                </div>))}
        </div>
      </section>

      <section className="profil-sekcija">
        <div className="obavijesti-naslov-red">
          <h2>Obavijesti</h2>
          <div className="obavijesti-filteri">
            <input type="checkbox" id="sve" />
            <label htmlFor="sve">Sve</label>
            <input type="checkbox" id="samo-ovdje" />
            <label htmlFor="samo-ovdje">Samo ovdje</label>
            <input type="checkbox" id="email" />
            <label htmlFor="email">Samo na email</label>
            <button className="gumb-spremi">SPREMI</button>
          </div>
        </div>

        <div className="obavijesti-grid">
          <div className="obavijest-box">
            <p>30.4. The Club slavi PRAZNIK NERADA! Moraš doći i ti doživjeti nezaboravnu atmosferu.</p>
            <div className="obavijest-akcije">
              <span>Obriši</span>
              <span>Pogledaj</span>
            </div>
          </div>
          <div className="obavijest-box">
            <p>Tvoj omiljeni kafić organizira natjecanje u beer pongu!</p>
            <div className="obavijest-akcije">
              <span>Obriši</span>
              <span>Pogledaj</span>
            </div>
          </div>
          <div className="obavijest-box">
            <p>Ne propusti novi kviz u Comodu.</p>
            <div className="obavijest-akcije">
              <span>Obriši</span>
              <span>Pogledaj</span>
            </div>
          </div>
          <div className="vise-kontejner">
             <button className="gumb-vise">VIŠE</button>
          </div>
        </div>
      </section>

      <section className="profil-sekcija">
        <h2>Loyalty popusti</h2>
        <p className="loyalty-tekst">Pokaži u Potteru za besplatan kolač uz kavu</p>
        <div className="qr-kod-okvir">
          <img src="https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=PulsGradaAna" alt="QR Kod" />
        </div>
      </section>
    </div>
  );
}

export default Profil;