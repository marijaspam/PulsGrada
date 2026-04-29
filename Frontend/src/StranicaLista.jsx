import { Link } from 'react-router-dom' // DODAJ OVO
import Kartica from './Kartica'

function StranicaLista({ naslov, tip }) {
  return (
    <div className="stranica-lista-kontejner">
      <header className="lista-header">
        <h1 className="lista-glavni-naslov">{naslov}</h1>
        
        <div className="lista-nav-opcije">
          {/* Sada su ovo pravi linkovi koji rade */}
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
          {tip === 'dogadaji' ? (
            <>
              <select className="lista-select"><option>Vrijeme</option></select>
              <select className="lista-select"><option>Vrsta događaja</option></select>
              <select className="lista-select"><option>Karta</option></select>
            </>
          ) : (
            <select className="lista-select"><option>Karta</option></select>
          )}
          <button className="filter-ikona-gumb">--</button>
        </div>
      </header>

      <main className="lista-sadrzaj">
        <div className="kartice-grid">
          <Kartica naslov="Taking the Trash out" lokacija="Zagrebački velesajam" vrijeme="23:00 h" />
          <Kartica naslov="Opća verzija" lokacija="ZAGS caffe" vrijeme="20:00 h" />
          <Kartica naslov="Aleksandar Lazić" lokacija="Cristero pub" vrijeme="20:00 h" />
          <Kartica naslov="Beer pong" lokacija="Mala kavana" vrijeme="21:00 h" />
          <Kartica naslov="Tamburaši" lokacija="The Place" vrijeme="19:00 h" />
          <Kartica naslov="Ex Zodiac band" lokacija="River pub" vrijeme="21:00 h" />
        </div>
        
        <button className="btn-prikazi-vise">PRIKAŽI VIŠE</button>
      </main>
    </div>
  )
}

export default StranicaLista