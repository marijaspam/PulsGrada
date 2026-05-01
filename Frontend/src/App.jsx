import { Routes, Route, useParams } from 'react-router-dom'
import './Global.css'
import Navbar from './Navbar'
import Footer from './Footer'
import PocetnaStranica from './PocetnaStranica'
import StranicaLista from './StranicaLista'
import Detalji from './Detalji'
import Prijava from './Prijava'
import Omiljeno from './Omiljeno'
import Profil from './Profil'
import { useEffect, useState } from 'react'
import axios from 'axios'

// --- POMOĆNA KOMPONENTA ZA DETALJE ---
function DetaljiWrapper() {
  const { id } = useParams()
  const [podaci, setPodaci] = useState(null)
  const [loading, setLoading] = useState(true)

  useEffect(() => {

    axios.get(`http://localhost:5018/api/Lokal/${id}`)
      .then(res => {
        setPodaci(res.data)
        setLoading(false)
      })
      .catch(err => {
        console.error("Greška pri dohvaćanju detalja:", err)
        setLoading(false)
      })
  }, [id])

  if (loading) {
    return (
      <div style={{ color: 'white', padding: '100px', textAlign: 'center' }}>
        <h2>Učitavanje podataka iz baze...</h2>
      </div>
    )
  }

  if (!podaci) {
    return (
      <div style={{ color: 'white', padding: '100px', textAlign: 'center' }}>
        <h2>Objekt pod ID-om {id} nije pronađen u bazi.</h2>
      </div>
    )
  }

  return <Detalji podaci={podaci} tip="kafici" />
}

// --- GLAVNA APP KOMPONENTA ---
function App() {
  const [jePrijavljen, setJePrijavljen] = useState(
    localStorage.getItem('user') !== null
  )

  return (
    <div className="glavni-kontejner">
      <Navbar prijavljen={jePrijavljen} setPrijavljen={setJePrijavljen} />

      <Routes>
        <Route path="/" element={<PocetnaStranica />} />

        <Route
          path="/dogadaji"
          element={<StranicaLista naslov="Ovdje počinju svi planovi!" tip="dogadaji" />}
        />

        <Route
          path="/kafici"
          element={<StranicaLista naslov="Adrese na koje se vraćaš!" tip="kafici" />}
        />

        <Route path="/detalji/:tip/:id" element={<Detalji />} />

        <Route
          path="/prijava"
          element={<Prijava onLogin={() => setJePrijavljen(true)} />}
        />

        <Route path="/omiljeno" element={<Omiljeno />} />
        <Route path="/profil" element={<Profil />} />
      </Routes>

      <Footer />
    </div>
  )
}

export default App;