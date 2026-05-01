import { User, Heart } from 'lucide-react';
import { Link } from 'react-router-dom';
import './Navbar.css';

const HeartIcon = (props) => <Heart {...props} />;
const UserIcon = (props) => <User {...props} />;

function Navbar({ prijavljen }) {
  return (
    <nav className="navbar">
      <div className="navbar-logo">
        <Link to="/" className="logo-link">PULS GRADA</Link>
      </div>

      <div className="navbar-desno">
        {prijavljen ? (
          /* Što vidi PRIJAVLJEN (Srce + Profil) */
          <div className="user-icons">
            <Link to="/omiljeno" className="nav-ikona-link">
              Omiljeno
            </Link>
            <Link to="/profil" className="nav-ikona-link">
              Profil
            </Link>
          </div>
        ) : (
          /* Što vidi NEPRIJAVLJEN (Gumb Prijava) */
          <Link to="/prijava" className="prijava-btn">PRIJAVA</Link>
        )}

        {/* Search bar BEZ ikone */}
        <div className="search-bar">
          <input type="text" placeholder="Pretraži..." />
        </div>
      </div>
    </nav>
  );
}

export default Navbar;