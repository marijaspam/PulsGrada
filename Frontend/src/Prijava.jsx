import React, { useState } from 'react'
import axios from 'axios'
import './Prijava.css'

function Prijava({onLogin}) {
  const [isLogin, setIsLogin] = useState(true)

  const [formData, setFormData] = useState({
    korisnickoIme: '',
    ime: '',
    prezime: '',
    email: '',
    lozinka: '',
    ponovljenaLozinka: '',
    korisnikIdentifikator: '',
  })

  const base = 'http://localhost:5018/api'

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    })
  }

  const handleSubmit = async (e) => {
    e.preventDefault()

    try {
      if (isLogin) {
        // LOGIN
        const res = await axios.post(`${base}/Auth/prijava`, {
          korisnikIdentifikator: formData.korisnikIdentifikator,
          lozinka: formData.lozinka
        })

        console.log('LOGIN USPJEH:', res.data)

        alert('Uspješna prijava!')
        localStorage.setItem('user', JSON.stringify(res.data))
        if(onLogin) onLogin()
        window.location.href = '/'

      } else {
        // REGISTRACIJA

        if (formData.lozinka !== formData.ponovljenaLozinka) {
          alert('Lozinke se ne poklapaju!')
          return
        }

        const res = await axios.post(`${base}/Auth/registracija`, {
          korisnickoIme: formData.korisnickoIme,
          ime: formData.ime,
          prezime: formData.prezime,
          email: formData.email,
          lozinka: formData.lozinka,
          ponovljenaLozinka: formData.ponovljenaLozinka
        })

        console.log('REGISTRACIJA USPJEH:', res.data)

        alert('Registracija uspješna! Možeš se prijaviti.')
        setIsLogin(true)

      }
    } catch (err) {
      console.error('Greška:', err)
      alert('Nešto nije u redu (provjeri podatke)')
    }
  }

  return (
    <div className="auth-kontejner">
      <div className="auth-box">
        <h2>{isLogin ? 'Prijava' : 'Registracija'}</h2>

        <form className="auth-forma" onSubmit={handleSubmit}>

          {!isLogin && (
            <>
              <div className="input-grupa">
                <label>Korisničko ime:</label>
                <input
                  type="text"
                  name="korisnickoIme"
                  onChange={handleChange}
                />
              </div>

              <div className="input-grupa">
                <label>Ime:</label>
                <input
                  type="text"
                  name="ime"
                  onChange={handleChange}
                />
              </div>

              <div className="input-grupa">
                <label>Prezime:</label>
                <input
                  type="text"
                  name="prezime"
                  onChange={handleChange}
                />
              </div>
            </>
          )}

          <div className="input-grupa">
            <label>Email ili korisničko ime</label>
            <input
              type="text"
              name="korisnikIdentifikator"
              placeholder='email ili korisničko ime'
              onChange={handleChange}
            />
          </div>

          <div className="input-grupa">
            <label>Lozinka:</label>
            <input
              type="password"
              name="lozinka"
              onChange={handleChange}
            />
          </div>

          {!isLogin && (
            <div className="input-grupa">
              <label>Ponovi lozinku:</label>
              <input
                type="password"
                name="ponovljenaLozinka"
                onChange={handleChange}
              />
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
  )
}

export default Prijava