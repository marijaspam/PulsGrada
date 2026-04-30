import { User, Heart, Search } from 'lucide-react';
import { Link } from 'react-router-dom';
import './Navbar.css';

function Navbar({ prijavljen }) {
  return (
    <nav className="navbar">
      <div className="navbar-logo">
        <Link to="/" className="logo-link">PULS GRADA</Link>
      </div>

      <div className="navbar-desno">
        {prijavljen ? (
          // Što vidi PRIJAVLJEN (Srce + Profil)
          <div className="user-icons">
            <Link to="/omiljeno"><Heart className="nav-ikona" size={24} /></Link>
            <Link to="/profil"><User className="nav-ikona" size={24} /></Link>
          </div>
        ) : (
          // Što vidi NEPRIJAVLJEN (Gumb Prijava)
          <Link to="/prijava" className="prijava-btn">PRIJAVA</Link>
        )}
                {/* Search bar koji vide SVI */}
        <div className="search-bar">
          <input type="text" placeholder="Pretraži" />
          <Search className="search-ikona" size={18} />
        </div>
      </div>
    </nav>
  );
}

export default Navbar;