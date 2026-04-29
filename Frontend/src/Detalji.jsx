import './Detalji.css'

function Detalji({ podaci, tip }) {
  return (
    <div className="detalji-container">
      {/* Gornji dio: Info i Glavna slika */}
      <div className="detalji-header">
        <div className="detalji-info-lijevo">
          <h1>
            {podaci.naslov}{' '}
            {podaci.ocjena && <span className="ocjena-broj">{podaci.ocjena}</span>}
          </h1>

          <ul className="info-lista">
            {podaci.stavke.map((stavka, index) => (
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
        </div> {/* <-- Ovdje je falio ovaj zatvoreni div za lijevu stranu! */}

        <div className="glavna-slika-desno">
          <img src={podaci.glavnaSlika} alt={podaci.naslov} />
        </div>
      </div>

      {/* Gumb sekcija */}
      <div className="akcija-sekcija">
        <button className="btn-omiljeno">DODAJ U OMILJENO</button>
        <span className="srce-ikona">❤️</span>
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
            {podaci.recenzije.map((r, i) => (
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
        {podaci.galerija.map((slika, index) => (
          <img key={index} src={slika} alt="galerija" className="galerija-slika" />
        ))}
      </div>
    </div>
  );
}

export default Detalji;