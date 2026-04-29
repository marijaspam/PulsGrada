import { Link } from 'react-router-dom';

function Navbar() {
  return (
    <nav className="navbar">
      <Link to="/" style={{ textDecoration: 'none', color: 'inherit' }}>
        <h1 className="logo-tekst">PULS GRADA</h1>
      </Link>
      <div className="nav-desno">
        <Link to="/prijava" className="prijava-btn">Prijava</Link>
        <div className="search-bar">
          <input type="text" placeholder="Pretraži" />
          <span className="search-icon">O</span>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;