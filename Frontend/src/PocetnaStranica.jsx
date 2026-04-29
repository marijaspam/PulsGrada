import { Link } from 'react-router-dom'
import Kartica from './Kartica'

function PocetnaStranica() {

const scrollajDesno = (e) => {
    // e.currentTarget osigurava da uvijek gledamo gumb, bez obzira na što unutar njega kliknuli
    const slider = e.currentTarget.parentElement.querySelector('.slider-kontejner');
    slider.scrollBy({ left: 350, behavior: 'smooth' });
  };

  const scrollajLijevo = (e) => {
    const slider = e.currentTarget.parentElement.querySelector('.slider-kontejner');
    slider.scrollBy({ left: -350, behavior: 'smooth' });
  };

  return (
    <>
      <header className="hero">
        <h1 className="naslov">Otkrij. Izađi. Poveži se.</h1>
        <div className="glavni-filteri">
          <Link to="/dogadaji" className="filter-glavni-link">Događaji</Link>
          <Link to="/kafici" className="filter-glavni-link">Kafići</Link>
        </div>
        <div className="dropdown-filteri">
          <select><option>Vrijeme</option></select>
          <select><option>Lokacija</option></select>
          <select><option>Vrsta događaja</option></select>
          <button className="filter-icon">/ \</button>
        </div>
      </header>

<section className="sekcija">
        <h2 className="sekcija-naslov">Srce večeri</h2>
        <button className="strelica-slider lijevo" onClick={scrollajLijevo}>{"<"}</button>
        <div className="slider-kontejner">
          <Kartica id="taking-the-trash-out" naslov="Taking the Trash out" lokacija="Velesajam" vrijeme="23:00 h" slika="/takingthetrashout.jpg" />
          <Kartica naslov="Trash kviz" lokacija="Zags" vrijeme="20:00 h" />
          <Kartica naslov="Techno Night" lokacija="Boogaloo" vrijeme="22:00 h" />
          <Kartica naslov="Vinski podrum" lokacija="Centar" vrijeme="19:00 h" />
          <Kartica naslov="Pub Quiz" lokacija="Vintage" vrijeme="20:30 h" />
          <Kartica naslov="Pub Quiz" lokacija="Vintage" vrijeme="20:30 h" />
          <Kartica naslov="Pub Quiz" lokacija="Vintage" vrijeme="20:30 h" />
          <Kartica naslov="Pub Quiz" lokacija="Vintage" vrijeme="20:30 h" />
        </div>
        <button className="strelica-slider desno" onClick={scrollajDesno}>{">"}</button>
      </section>
      <section className="sekcija">
        <h2 className="sekcija-naslov">Točke života</h2>
        <button className="strelica-slider lijevo" onClick={scrollajLijevo}>{"<"}</button>
        <div className="slider-kontejner">
          <Kartica naslov="Caffe bar Elite" lokacija="Črnomerec" vrijeme="Radno vrijeme: 08-23h" />
          <Kartica naslov="River Pub" lokacija="Savska" vrijeme="Radno vrijeme: 07-02h" />
          <Kartica naslov="Zags Caffe" lokacija="Selska" vrijeme="Radno vrijeme: 08-00h" />
          <Kartica naslov="Potter" lokacija="Maksimir" vrijeme="Radno vrijeme: 08-23h" />
          <Kartica naslov="Kavana Johann Franck" lokacija="Trg" vrijeme="Radno vrijeme: 08-02h" />
          <Kartica naslov="Kavana Johann Franck" lokacija="Trg" vrijeme="Radno vrijeme: 08-02h" />
          <Kartica naslov="Kavana Johann Franck" lokacija="Trg" vrijeme="Radno vrijeme: 08-02h" />
          <Kartica naslov="Kavana Johann Franck" lokacija="Trg" vrijeme="Radno vrijeme: 08-02h" />
        </div>
        <button className="strelica-slider desno" onClick={scrollajDesno}>{">"}</button>
      </section>

      <section className="mapa-sekcija">
        <h2 className="sekcija-naslov">Krvotok grada</h2>
        <div className="lazna-mapa">Ovdje ide Google Maps</div>
      </section>
    </>
  )
}

export default PocetnaStranica