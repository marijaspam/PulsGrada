import React, { useState } from 'react';
import './Prijava.css';

function Prijava() {
  const [isLogin, setIsLogin] = useState(true); 

  return (
    <div className="auth-kontejner">
      <div className="auth-box">
        <h2>{isLogin ? 'Prijava' : 'Registracija'}</h2>
        
        <form className="auth-forma">
          <div className="input-grupa">
            <label>Unesite email:</label>
            <input type="email" placeholder="pr. ivan.horvat@gmail.com" />
          </div>

          <div className="input-grupa">
            <label>Unesite lozinku:</label>
            <input type="password" placeholder="lozinka" />
          </div>

          {/* Ovo polje se vidi SAMO ako NIJE prijava (nego registracija) */}
          {!isLogin && (
            <div className="input-grupa">
              <label>Ponovite lozinku:</label>
              <input type="password" placeholder="ponovljena lozinka" />
            </div>
          )}

          <button type="submit" className="btn-auth">
            {isLogin ? 'PRIJAVI ME' : 'REGISTRIRAJ ME'}
          </button>
        </form>

        <p className="auth-toggle-tekst">
          {isLogin ? "Nemaš račun?" : "Već imaš račun?"} 
          <span onClick={() => setIsLogin(!isLogin)}>
            {isLogin ? ' Registriraj se' : ' Prijavi se'}
          </span>
        </p>
      </div>
    </div>
  );
}

export default Prijava;