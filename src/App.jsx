import { Routes, Route, useParams } from 'react-router-dom'
import './App.css'
import Navbar from './Navbar'
import Footer from './Footer'
import PocetnaStranica from './PocetnaStranica'
import StranicaLista from './StranicaLista'
import Detalji from './Detalji'
import Prijava from './Prijava';
import { useState } from 'react';
import { fejkBaza } from './baza';

function App() {
  // Prekidač: false znači nismo prijavljeni
  const [jePrijavljen, setJePrijavljen] = useState(false);

  // Funkcija koju ćemo poslati stranici Prijava.jsx
  const loginHandler = () => {
    setJePrijavljen(true);
  };

  return (
    <Router>
      {/* Navbaru šaljemo informaciju o prijavi */}
      <Navbar prijavljen={jePrijavljen} />
      
      <Routes>
        <Route path="/" element={<PocetnaStranica />} />
        
        {/* Stranici za prijavu šaljemo funkciju da nas može "prijaviti" */}
        <Route path="/prijava" element={<Prijava onLogin={loginHandler} />} />
        
        {/* Ostale rute... */}
      </Routes>
      <Footer />
    </Router>
  );
}

// Pomoćna komponenta koja će sutra raditi "fetch" iz prave baze
function DetaljiWrapper() {
  const { id } = useParams()
  
  // SUTRA: Ovdje ćeš dodati useEffect i pozvati svoj backend API
  // npr. axios.get(`http://localhost:5000/dogadaj/${id}`)
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
  return (
    <div className="glavni-kontejner">
      <Navbar />
      
      <Routes>
        {/* Početna stranica */}
        <Route path="/" element={<PocetnaStranica />} />
        
        {/* Liste događaja i kafića */}
        <Route 
          path="/dogadaji" 
          element={<StranicaLista naslov="Ovdje počinju svi planovi!" tip="dogadaji" />} 
        />
        <Route 
          path="/kafici" 
          element={<StranicaLista naslov="Adrese na koje se vraćaš!" tip="kafici" />} 
        />

        {/* Dinamička ruta za pojedinačni događaj/kafić */}
        <Route path="/detalji/:id" element={<DetaljiWrapper />} />

        <Route path="/prijava" element={<Prijava />} />
      </Routes>

      <Footer />
    </div>
  )
}

export default App