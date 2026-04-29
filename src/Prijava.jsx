import React from 'react';
import './Prijava.css';

function Prijava() {
  return (
    <div className="prijava-stranica">
      <div className="prijava-sadrzaj">
        <div className="prijava-box">
          <div className="input-grupa">
            <label>Unesite email:</label>
            <input type="email" placeholder="pr. ivan.horvat@gmail.com" />
          </div>

          <div className="input-grupa">
            <label>Unesite lozinku:</label>
            <input type="password" placeholder="lozinka" />
          </div>

          <div className="input-grupa">
            <label>Ponovite lozinku:</label>
            <input type="password" placeholder="ponovljena lozinka" />
          </div>

          <button className="btn-prijavi">PRIJAVI ME</button>
        </div>
      </div>
    </div>
  );
}

export default Prijava;