import { Link } from 'react-router-dom';

function Kartica({ id, naslov, lokacija, vrijeme, slika }) {
  return (
    <Link to={`/detalji/${id}`} className="kartica-link-wrapper">
      <div className="kartica">
        <div 
          className="kartica-slika" 
          style={{ backgroundImage: `url(${slika})` }}
        >
          {/* Slika je gore, srce ide u donji dio */}
        </div>
        <div className="kartica-tekst-kontejner">
          <div className="kartica-info">
            <h4>{naslov}</h4>
            <p className="lokacija-tekst">{lokacija}</p>
            <p className="vrijeme-tekst">{vrijeme}</p>
          </div>
          <div className="kartica-srce">
            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2">
              <path d="M20.84 4.61a5.5 5.5 0 0 0-7.78 0L12 5.67l-1.06-1.06a5.5 5.5 0 0 0-7.78 7.78l1.06 1.06L12 21.23l7.78-7.78 1.06-1.06a5.5 5.5 0 0 0 0-7.78z"></path>
            </svg>
          </div>
        </div>
      </div>
    </Link>
  );
}

export default Kartica;