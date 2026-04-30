import React from 'react';
import { Heart } from 'lucide-react';
import { fejkBaza } from './baza';
import './Omiljeno.css';

function Omiljeno() {
  const omiljeniPredmeti = Object.values(fejkBaza).slice(0, 5);

  return (
    <div className="stranica-omiljeno">
      <h1 className="naslov-stranice">Omiljeno</h1>
      
      <div className="grid-kartica">
        {omiljeniPredmeti.map((stavka, index) => (
          <div key={index} className="kartica">
            <div className="kartica-slika-kontejner">
                <img src={stavka.slika} alt={stavka.naslov} className="kartica-slika" />
            </div>
            
            <div className="kartica-info-donji">
            <div className="info-tekst">
                <h3>{stavka.naslov}</h3>
                <p className="opis">{stavka.opis || stavka.adresa}</p>
                <p className="lokacija">{stavka.lokacija || stavka.grad}</p>
            </div>
              
              <div className="srce-ikona">
                <Heart fill="#FF5A7E" color="#FF5A7E" size={24} />
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default Omiljeno;