import React, { useEffect, useState } from 'react'
import axios from 'axios'
import Kartica from './Kartica'
import './Omiljeno.css'

function Omiljeno() {
  const [favoriti, setFavoriti] = useState([])
  const [loading, setLoading] = useState(true)
  const obrisiFavorit = async (lokalId) => {
  const user = JSON.parse(localStorage.getItem('user'))
  const korisnikId = user.idKorisnik || user.korisnikId || user.id

  try {
    await axios.delete('http://localhost:5018/api/Favorit/obrisi', {
      data: {
        korisnikId: korisnikId,
        lokalId: lokalId
      }
    })

    setFavoriti(favoriti.filter((f) => 
      (f.id || f.lokalId || f.idLokal) !== lokalId
    ))

  } catch (err) {
    console.error('Greška pri brisanju favorita:', err)
  }
}

  useEffect(() => {
    const dohvatiFavorite = async () => {
      try {
        const user = JSON.parse(localStorage.getItem('user'))

        if (!user) {
          setFavoriti([])
          setLoading(false)
          return
        }

        const korisnikId = user.idKorisnik || user.korisnikId || user.id

        const res = await axios.get(`http://localhost:5018/api/Favorit/${korisnikId}`)

        console.log('FAVORITI:', res.data)

        setFavoriti(res.data)
      } catch (err) {
        console.error('Greška pri dohvaćanju favorita:', err)
        setFavoriti([])
      } finally {
        setLoading(false)
      }
    }

    dohvatiFavorite()
  }, [])

  return (
    <div className="stranica-omiljeno">
      <h1 className="naslov-stranice">Omiljeno</h1>

      <div className="grid-kartica">
        {loading ? (
          <p style={{ color: 'white', gridColumn: '1 / -1' }}>
            Učitavam omiljeno...
          </p>
        ) : favoriti.length > 0 ? (
          favoriti.map((stavka) => (
            <Kartica
              key={stavka.id || stavka.lokalId || stavka.idLokal}
              {...stavka}
            />
          ))
        ) : (
          <p style={{ color: 'white', gridColumn: '1 / -1' }}>
            Još nemaš omiljenih kafića.
          </p>
        )}
      </div>
    </div>
  )
}

export default Omiljeno