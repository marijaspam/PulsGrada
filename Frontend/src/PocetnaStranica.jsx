import { Link } from 'react-router-dom'
import { useState, useEffect } from 'react'
import axios from 'axios'
import Kartica from './Kartica'
import './Pocetna.css'

function PocetnaStranica() {
  const [dogadaji, setDogadaji] = useState([])
  const [loading, setLoading] = useState(true)

  const [kvartovi, setKvartovi] = useState([])
  const [kategorije, setKategorije] = useState([])

  const [odabraniKvartId, setOdabraniKvartId] = useState('')
  const [odabranaKategorija, setOdabranaKategorija] = useState('')
  const [odabranoVrijeme, setOdabranoVrijeme] = useState('')

  const base = 'http://localhost:5018/api'

  useEffect(() => {
    const dohvatiOpcije = async () => {
      try {
        const [resKvartovi, resKategorije] = await Promise.all([
          axios.get(`${base}/Kvart`),
          axios.get(`${base}/Kategorija`)
        ])

        setKvartovi(resKvartovi.data)
        setKategorije(resKategorije.data)
      } catch (err) {
        console.error('Greška pri dohvaćanju opcija:', err)
      }
    }

    dohvatiOpcije()
  }, [])

  useEffect(() => {
    const dohvatiDogadaje = async () => {
      setLoading(true)

      try {
        const params = {
          idKvart: odabraniKvartId || undefined,
          kategorija: odabranaKategorija || undefined,
          vrijeme: odabranoVrijeme || undefined
        }

        console.log('POČETNA PARAMS:', params)

        const res = await axios.get(`${base}/Dogadaj/filter`, { params })
        setDogadaji(res.data)
      } catch (err) {
        console.error('Greška pri filtriranju događaja:', err)
        setDogadaji([])
      } finally {
        setLoading(false)
      }
    }

    dohvatiDogadaje()
  }, [odabraniKvartId, odabranaKategorija, odabranoVrijeme])

  const scrollajDesno = (e) => {
    const slider = e.currentTarget.parentElement.querySelector('.slider-kontejner')
    slider.scrollBy({ left: 350, behavior: 'smooth' })
  }

  const scrollajLijevo = (e) => {
    const slider = e.currentTarget.parentElement.querySelector('.slider-kontejner')
    slider.scrollBy({ left: -350, behavior: 'smooth' })
  }

  return (
    <>
      <header className="hero">
        <h1 className="naslov">Otkrij. Izađi. Poveži se.</h1>

        <div className="glavni-filteri">
          <Link to="/dogadaji" className="filter-glavni-link">
            Događaji
          </Link>
          <Link to="/kafici" className="filter-glavni-link">
            Kafići
          </Link>
        </div>

        <div className="dropdown-filteri">
          <select
            value={odabraniKvartId}
            onChange={(e) => setOdabraniKvartId(e.target.value)}
          >
            <option value="">Svi kvartovi</option>

            {kvartovi.map((kvart) => (
              <option key={kvart.id} value={kvart.id}>
                {kvart.naziv}
              </option>
            ))}
          </select>

          <select
            value={odabranaKategorija}
            onChange={(e) => setOdabranaKategorija(e.target.value)}
          >
            <option value="">Sve kategorije</option>

            {kategorije.map((kategorija) => (
              <option key={kategorija.id} value={kategorija.naziv}>
                {kategorija.naziv}
              </option>
            ))}
          </select>

          <select
            value={odabranoVrijeme}
            onChange={(e) => setOdabranoVrijeme(e.target.value)}
          >
            <option value="">Vrijeme</option>
            <option value={new Date().toISOString().split('T')[0]}>
              Danas
            </option>
          </select>
        </div>
      </header>

      <section className="sekcija">
        <h2 className="sekcija-naslov">Srce večeri</h2>

        <button className="strelica-slider lijevo" onClick={scrollajLijevo}>
          {'<'}
        </button>

        <div className="slider-kontejner">
          {loading ? (
            <p style={{ color: 'white', padding: '20px' }}>
              Učitavam događaje...
            </p>
          ) : dogadaji.length > 0 ? (
            dogadaji.map((d) => <Kartica key={d.id} {...d} />)
          ) : (
            <p style={{ color: 'white', padding: '20px' }}>
              Nema događaja za odabrane filtere.
            </p>
          )}
        </div>

        <button className="strelica-slider desno" onClick={scrollajDesno}>
          {'>'}
        </button>
      </section>

      <section className="sekcija">
        <h2 className="sekcija-naslov">Točke života</h2>

        <button className="strelica-slider lijevo" onClick={scrollajLijevo}>
          {'<'}
        </button>

        <div className="slider-kontejner">
          {loading ? (
            <p style={{ color: 'white', padding: '20px' }}>
              Učitavam događaje...
            </p>
          ) : dogadaji.length > 0 ? (
            dogadaji
              .slice()
              .reverse()
              .map((d) => <Kartica key={`copy-${d.id}`} {...d} />)
          ) : (
            <p style={{ color: 'white', padding: '20px' }}>
              Nema događaja za odabrane filtere.
            </p>
          )}
        </div>

        <button className="strelica-slider desno" onClick={scrollajDesno}>
          {'>'}
        </button>
      </section>

      <section className="mapa-sekcija">
        <h2 className="sekcija-naslov">Krvotok grada</h2>   
        <div className="google-mapa-okvir">
          <iframe
          title="Google mapa Zagreba"
          src="https://www.google.com/maps?q=Zagreb&output=embed"
          width="100%"
          height="450"
          style={{ border: 0 }}
          allowFullScreen=""
          loading="lazy"
          referrerPolicy="no-referrer-when-downgrade"
          ></iframe>
        </div>
      </section>
    </>
  )
}

export default PocetnaStranica