import { Routes, Route, useParams } from 'react-router-dom'
import './Global.css'
import Navbar from './Navbar'
import Footer from './Footer'
import PocetnaStranica from './PocetnaStranica'
import StranicaLista from './StranicaLista'
import Detalji from './Detalji'
import Prijava from './Prijava'
import Omiljeno from './Omiljeno';
import Profil from './Profil';
import { useState } from 'react'
import { fejkBaza } from './baza'

// 1. POMOĆNA KOMPONENTA (izvan glavne App funkcije)
function DetaljiWrapper() {
  const { id } = useParams()
  const podaci = fejkBaza[id]

  if (!podaci) {
    return (
      <div style={{ color: 'white', padding: '100px', textAlign: 'center' }}>
        <h2>Učitavanje ili objekt nije pronađen...</h2>
      </div>
    )
  }

  return <Detalji podaci={podaci} tip={podaci.tip} />
}

function App() {
  const [jePrijavljen, setJePrijavljen] = useState(true);

  const loginHandler = () => {
    setJePrijavljen(true);
  };

  return (
    <div className="glavni-kontejner">
      <Navbar prijavljen={jePrijavljen} />
      
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

        <Route path="/detalji/:id" element={<DetaljiWrapper />} />

        <Route path="/prijava" element={<Prijava onLogin={loginHandler} />} />

        <Route path="/omiljeno" element={<Omiljeno />} />
        <Route path="/profil" element={<Profil />} />
      </Routes>

      <Footer />
    </div>
  )
}

export default App;