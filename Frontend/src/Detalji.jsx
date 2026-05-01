import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import axios from 'axios'
import './Detalji.css'

function Detalji() {
  const { tip, id } = useParams()
  const [podaci, setPodaci] = useState(null)
  const [loading, setLoading] = useState(true)
  const [isSpremljeno, setIsSpremljeno] = useState(false)

  const base = 'http://localhost:5018/api'

  useEffect(() => {
    const endpoint =
      tip === 'kafici'
        ? `${base}/Lokal/${id}`
        : `${base}/Dogadaj/${id}`

    setLoading(true)

    axios
      .get(endpoint)
      .then((res) => {
        const d = res.data

        const prilagodeno = {
          naslov: d.nazivDogadaja || d.naziv || 'Bez naziva',
          glavnaSlika: d.urlSlike || d.slikaUrl || '/placeholder.jpg',
          opis: d.opis || 'Nema opisa.',
          podnaslov: d.kategorijaNaziv || 'Opis',
          lokacija: d.lokalNaziv || d.adresa || 'Nepoznata lokacija',
          ocjena: d.ocjena || null,
          stavke: [
            d.lokalNaziv || d.adresa || 'Lokacija nepoznata',
            d.vrijemePocetka
              ? d.vrijemePocetka.split('T')[0]
              : d.radnoVrijeme || 'Radno vrijeme nepoznato'
          ],
          mapaUrl:
            d.mapaUrl ||
            'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2781.789048633719!2d15.9772036!3d45.8118105!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4765d69324545931%3A0x679462725e2e845e!2sTrg%20Bana%20Jela%C4%8Di%C4%87a!5e0!3m2!1shr!2shr!4v1700000000000',
          galerija: d.galerija || null
        }

        setPodaci(prilagodeno)
      })
      .catch((err) => {
        console.error('Greška pri dohvaćanju detalja:', err)
      })
      .finally(() => {
        setLoading(false)
      })
  }, [id, tip])

  useEffect(() => {
    const provjeriJeLiOmiljeno = async () => {
      if (tip !== 'kafici') return

      const user = JSON.parse(localStorage.getItem('user'))
      if (!user) return

      const korisnikId = user.idKorisnik || user.korisnikId || user.id

      try {
        const res = await axios.get(`${base}/Favorit/${korisnikId}`)

        const postoji = res.data.some((f) => {
          const lokalId = f.id || f.lokalId || f.idLokal
          return Number(lokalId) === Number(id)
        })

        setIsSpremljeno(postoji)
      } catch (err) {
        console.error('Greška pri provjeri favorita:', err)
      }
    }

    provjeriJeLiOmiljeno()
  }, [id, tip])

  const toggleOmiljeno = async () => {
    if (tip !== 'kafici') return

    const user = JSON.parse(localStorage.getItem('user'))
    if (!user) return

    const korisnikId = user.idKorisnik || user.korisnikId || user.id
    const lokalId = Number(id)

    try {
      if (isSpremljeno) {
        await axios.delete(`${base}/Favorit/obrisi`, {
          data: {
            korisnikId,
            lokalId
          }
        })

        setIsSpremljeno(false)
      } else {
        await axios.post(`${base}/Favorit/dodaj`, {
          korisnikId,
          lokalId
        })

        setIsSpremljeno(true)
      }
    } catch (err) {
      const poruka = err.response?.data?.poruka

      if (poruka?.includes('već postoji')) {
        setIsSpremljeno(true)
      } else {
        console.error('Greška s favoritom:', err)
      }
    }
  }

  if (loading) {
    return (
      <div style={{ color: 'white', textAlign: 'center', marginTop: '50px' }}>
        Učitavanje detalja...
      </div>
    )
  }

  if (!podaci) {
    return (
      <div style={{ color: 'white', textAlign: 'center', marginTop: '50px' }}>
        Podatak nije pronađen.
      </div>
    )
  }

  return (
    <div className="detalji-container">
      <div className="detalji-header">
        <div className="detalji-info-lijevo">
          <h1>
            {podaci.naslov}{' '}
            {podaci.ocjena && (
              <span className="ocjena-broj">{podaci.ocjena}</span>
            )}
          </h1>

          <ul className="info-lista">
            {podaci.stavke.map((stavka, index) => (
              <li key={index}>
                <span className="info-ikona">📍</span>
                {typeof stavka === 'object' ? JSON.stringify(stavka) : stavka}
              </li>
            ))}
          </ul>

          <div className="mapa-kontejner">
            <h3>Lokacija</h3>
            <iframe
              src={podaci.mapaUrl}
              width="100%"
              height="300"
              style={{ border: 0, borderRadius: '20px', marginTop: '15px' }}
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

      {tip === 'kafici' && (
        <div className="akcija-sekcija">
          <button
            className={`btn-omiljeno ${isSpremljeno ? 'aktivno' : ''}`}
            onClick={toggleOmiljeno}
          >
            {isSpremljeno ? 'UKLONI IZ OMILJENIH' : 'DODAJ U OMILJENO'}
          </button>
        </div>
      )}

      <div className="detalji-sadrzaj">
        <div className="opis-box">
          <h3>{podaci.podnaslov}</h3>
          <p>{podaci.opis}</p>
        </div>
      </div>

      {podaci.galerija && (
        <div className="galerija-grid">
          {podaci.galerija.map((slika, index) => (
            <img
              key={index}
              src={slika}
              alt="galerija"
              className="galerija-slika"
            />
          ))}
        </div>
      )}
    </div>
  )
}

export default Detalji