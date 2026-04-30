import { Link } from 'react-router-dom'
import Kartica from './Kartica'
import './StranicaLista.css'

function StranicaLista({ naslov, tip }) {
  const dogadajiPodaci = [
    { id: 1, naslov: "Taking the Trash out", lokacija: "Zagrebački velesajam", vrijeme: "23:00 h" },
    { id: 2, naslov: "Opća verzija", lokacija: "ZAGS caffe", vrijeme: "20:00 h" },
    { id: 3, naslov: "Aleksandar Lazić", lokacija: "Cristero pub", vrijeme: "20:00 h" },
    { id: 4, naslov: "Beer pong", lokacija: "Mala kavana", vrijeme: "21:00 h" },
    { id: 5, naslov: "Tamburaši", lokacija: "The Place", vrijeme: "19:00 h" },
    { id: 6, naslov: "Ex Zodiac band", lokacija: "River pub", vrijeme: "21:00 h" },
  ];

  const kaficiPodaci = [
    { id: 7, naslov: "Caffe Bar Puls", lokacija: "Centar", vrijeme: "07:00 - 23:00" },
    { id: 8, naslov: "Johann Franck", lokacija: "Trg bana Jelačića", vrijeme: "08:00 - 02:00" },
    { id: 9, naslov: "History Village", lokacija: "Tkalčićeva", vrijeme: "09:00 - 00:00" },
  ];

  const trenutniPodaci = tip === 'dogadaji' ? dogadajiPodaci : kaficiPodaci;

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
          {/* MAP metoda koja generira kartice iz nizova iznad */}
          {trenutniPodaci.map((stavka) => (
            <Kartica 
              key={stavka.id} 
              naslov={stavka.naslov} 
              lokacija={stavka.lokacija} 
              vrijeme={stavka.vrijeme} 
            />
          ))}
        </div>
        
        <button className="btn-prikazi-vise">PRIKAŽI VIŠE</button>
      </main>
    </div>
  )
}

export default StranicaLista