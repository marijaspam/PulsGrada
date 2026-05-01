import { Link } from 'react-router-dom'
import { useState } from 'react'
import axios from 'axios'
import './Kartica.css'

function Kartica({
  id,
  nazivDogadaja,
  lokalNaziv,
  urlSlike,
  vrijemePocetka,
  naziv,
  adresa,
  radnoVrijeme,
  pocetnoOmiljeno = false,
  onMakniIzOmiljenog
}) {
  const putanjaTip = nazivDogadaja ? 'dogadaji' : 'kafici'
  const [omiljeno, setOmiljeno] = useState(pocetnoOmiljeno)

  const naslov = nazivDogadaja || naziv || 'Bez naziva'
  const lokacija = lokalNaziv || adresa || 'Lokacija nepoznata'
  const slika = urlSlike || ''
  const vrijeme = vrijemePocetka
    ? vrijemePocetka.split('T')[0]
    : radnoVrijeme || ''

  const toggleOmiljeno = async (e) => {
    e.preventDefault()
    e.stopPropagation()

    const user = JSON.parse(localStorage.getItem('user'))
    if (!user || putanjaTip !== 'kafici') return

    const korisnikId = user.idKorisnik || user.korisnikId || user.id

    try {
      if (omiljeno) {
        await axios.delete('http://localhost:5018/api/Favorit/obrisi', {
          data: {
            korisnikId,
            lokalId: id
          }
        })

        setOmiljeno(false)

        if (onMakniIzOmiljenog) {
          onMakniIzOmiljenog(id)
        }
      } else {
        await axios.post('http://localhost:5018/api/Favorit/dodaj', {
          korisnikId,
          lokalId: id
        })

        setOmiljeno(true)
      }
    } catch (err) {
      const poruka = err.response?.data?.poruka

      if (poruka?.includes('već postoji')) {
        setOmiljeno(true)
      } else {
        console.error('Greška s favoritom:', err)
      }
    }
  }

  return (
    <Link to={`/detalji/${putanjaTip}/${id}`} className="kartica-link-wrapper">
      <div className="kartica">
        <div
          className="kartica-slika"
          style={{
            backgroundImage: slika ? `url(${slika})` : 'none',
            backgroundColor: '#2a2a2a'
          }}
        />

        <div className="kartica-tekst-kontejner">
          <div className="kartica-info">
            <h4>{naslov}</h4>
            <p className="lokacija-tekst">{lokacija}</p>
            <p className="vrijeme-tekst">{vrijeme}</p>
          </div>

          {putanjaTip === 'kafici' && (
            <button
              type="button"
              className={`kartica-srce ${omiljeno ? 'aktivno' : ''}`}
              onClick={toggleOmiljeno}
            >
              <svg
                width="24"
                height="24"
                viewBox="0 0 24 24"
                fill={omiljeno ? 'currentColor' : 'none'}
                stroke="currentColor"
                strokeWidth="2"
              >
                <path d="M20.84 4.61a5.5 5.5 0 0 0-7.78 0L12 5.67l-1.06-1.06a5.5 5.5 0 0 0-7.78 7.78l1.06 1.06L12 21.23l7.78-7.78 1.06-1.06a5.5 5.5 0 0 0 0-7.78z" />
              </svg>
            </button>
          )}
        </div>
      </div>
    </Link>
  )
}

export default Kartica