import { Link } from 'react-router-dom'
import { useEffect, useState } from 'react'
import axios from 'axios'
import Kartica from './Kartica'
import './StranicaLista.css'

function StranicaLista({ naslov, tip }) {
  const [podaci, setPodaci] = useState([])
  const [loading, setLoading] = useState(true)

  const [kvartovi, setKvartovi] = useState([])
  const [kategorije, setKategorije] = useState([])

  const [odabraniKvartId, setOdabraniKvartId] = useState('')
  const [odabranaKategorija, setOdabranaKategorija] = useState('')
  const [odabranoVrijeme, setOdabranoVrijeme] = useState('')

  const base = 'http://localhost:5018/api'

  useEffect(() => {
    const dohvatiFilterOpcije = async () => {
      try {
        const [resKvartovi, resKategorije] = await Promise.all([
          axios.get(`${base}/Kvart`),
          axios.get(`${base}/Kategorija`)
        ])

        setKvartovi(resKvartovi.data)
        setKategorije(resKategorije.data)
      } catch (err) {
        console.error('Greška pri dohvaćanju kvartova/kategorija:', err)
      }
    }

    dohvatiFilterOpcije()
  }, [])

  useEffect(() => {
    const dohvatiPodatke = async () => {
      setLoading(true)

      try {
        const url =
          tip === 'dogadaji'
            ? `${base}/Dogadaj/filter`
            : `${base}/Lokal/filter`

        const params =
          tip === 'dogadaji'
            ? {
                idKvart: odabraniKvartId || undefined,
                kategorija: odabranaKategorija || undefined,
                vrijeme: odabranoVrijeme || undefined
              }
            : {
                idKvart: odabraniKvartId || undefined
              }
        
        console.log('URL:', url)
        console.log('PARAMS:', params)

        const res = await axios.get(url, { params })
        setPodaci(res.data)
      } catch (err) {
        console.error('Greška pri filtriranju:', err)
        setPodaci([])
      } finally {
        setLoading(false)
      }
    }

    dohvatiPodatke()
  }, [tip, odabraniKvartId, odabranaKategorija, odabranoVrijeme])

  return (
    <div className="stranica-lista-kontejner">
      <header className="lista-header">
        <h1 className="lista-glavni-naslov">{naslov}</h1>

        <div className="lista-nav-opcije">
          <Link
            to="/dogadaji"
            className={tip === 'dogadaji' ? 'opcija aktivno' : 'opcija'}
          >
            Događaji
          </Link>

          <Link
            to="/kafici"
            className={tip === 'kafici' ? 'opcija aktivno' : 'opcija'}
          >
            Kafići
          </Link>
        </div>

        <div className="lista-filteri-red">
          <select
            className="lista-select"
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

          {tip === 'dogadaji' && (
            <>
              <select
                className="lista-select"
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
                className="lista-select"
                value={odabranoVrijeme}
                onChange={(e) => setOdabranoVrijeme(e.target.value)}
              >
                <option value="">Bilo kada</option>
                <option value={new Date().toISOString().split('T')[0]}>
                  Danas
                </option>
              </select>
            </>
          )}
        </div>
      </header>

      <main className="lista-sadrzaj">
        {loading ? (
          <h2 style={{ color: 'white', textAlign: 'center' }}>Tražim...</h2>
        ) : (
          <div className="kartice-grid">
            {podaci && podaci.length > 0 ? (
              podaci.map((stavka) => (
                <Kartica
                  key={stavka.id || stavka.idDogadaj || stavka.idLokal}
                  {...stavka}
                />
              ))
            ) : (
              <p
                style={{
                  color: 'white',
                  gridColumn: '1/-1',
                  textAlign: 'center'
                }}
              >
                Nema rezultata za tvoju pretragu.
              </p>
            )}
          </div>
        )}
      </main>
    </div>
  )
}

export default StranicaLista