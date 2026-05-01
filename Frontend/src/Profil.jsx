import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import axios from 'axios'
import './Profil.css'

function Profil() {
  const [favoriti, setFavoriti] = useState([])
  const navigate = useNavigate()

  const user = JSON.parse(localStorage.getItem('user'))

  useEffect(() => {
    const dohvatiFavorite = async () => {
      if (!user) return

      const korisnikId = user.idKorisnik || user.korisnikId || user.id

      try {
        const res = await axios.get(`http://localhost:5018/api/Favorit/${korisnikId}`)
        setFavoriti(res.data.slice(0, 4))
      } catch (err) {
        console.error('Greška pri dohvaćanju favorita:', err)
      }
    }

    dohvatiFavorite()
  }, [])

  const odjava = () => {
    localStorage.removeItem('user')
    navigate('/')
    window.location.reload()
  }

  if (!user) {
    return (
      <div className="profil-kontejner">
        <h1>Profil</h1>
        <p>Moraš biti prijavljena za prikaz profila.</p>
        <Link to="/prijava" className="gumb-spremi">Prijava</Link>
      </div>
    )
  }

  return (
    <div className="profil-kontejner">
      <header className="profil-header">
        <div className="profil-avatar-okvir">
          <span className="profil-avatar-slovo">
            {(user.korisnickoIme || user.ime || 'K')[0].toUpperCase()}
          </span>
        </div>

        <div className="profil-podaci">
          <h1>{user.ime && user.prezime ? `${user.ime} ${user.prezime}` : user.korisnickoIme}</h1>
          <p>@{user.korisnickoIme}</p>
        </div>

        <button className="odjava-link" onClick={odjava}>
          Odjava
        </button>
      </header>

      <section className="profil-sekcija">
        <h2>Omiljeno</h2>

        <div className="profil-omiljeno-red">
          {favoriti.length > 0 ? (
            favoriti.map((stavka) => (
              <Link
                to={`/detalji/kafici/${stavka.id}`}
                key={stavka.id}
                className="profil-kvadrat-kartica"
              >
                <img src={stavka.urlSlike} alt={stavka.naziv} />
              </Link>
            ))
          ) : (
            <p>Još nemaš omiljenih kafića.</p>
          )}
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
            <p>Tvoj omiljeni kafić ima novi događaj ovaj tjedan.</p>
            <div className="obavijest-akcije">
              <span>Obriši</span>
              <span>Pogledaj</span>
            </div>
          </div>

          <div className="obavijest-box">
            <p>Ne propusti novi pub kviz u blizini.</p>
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
        <p className="loyalty-tekst">
          Pokaži QR kod u omiljenom lokalu za dostupne pogodnosti.
        </p>

        <div className="qr-kod-okvir">
          <img
            src={`https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=PulsGrada-${user.korisnickoIme}`}
            alt="QR Kod"
          />
        </div>
      </section>
    </div>
  )
}

export default Profil