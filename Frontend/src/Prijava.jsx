import React, { useState } from 'react'
import axios from 'axios'
import './Prijava.css'

function Prijava({ onLogin }) {
  const [isLogin, setIsLogin] = useState(true)

  const praznaForma = {
    korisnickoIme: '',
    ime: '',
    prezime: '',
    email: '',
    lozinka: '',
    ponovljenaLozinka: '',
    korisnikIdentifikator: ''
  }

  const [formData, setFormData] = useState(praznaForma)

  const base = 'http://localhost:5018/api'

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    })
  }

  const prebaciFormu = () => {
    setFormData(praznaForma)
    setIsLogin(!isLogin)
  }

  const handleSubmit = async (e) => {
    e.preventDefault()

    try {
      if (isLogin) {
        const res = await axios.post(`${base}/Auth/prijava`, {
          korisnikIdentifikator: formData.korisnikIdentifikator,
          lozinka: formData.lozinka
        })

        localStorage.setItem('user', JSON.stringify(res.data))

        if (onLogin) onLogin()

        window.location.href = '/'
      } else {
        if (formData.lozinka !== formData.ponovljenaLozinka) {
          alert('Lozinke se ne poklapaju!')
          return
        }

        await axios.post(`${base}/Auth/registracija`, {
          korisnickoIme: formData.korisnickoIme,
          ime: formData.ime,
          prezime: formData.prezime,
          email: formData.email,
          lozinka: formData.lozinka,
          ponovljenaLozinka: formData.ponovljenaLozinka
        })

        alert('Registracija uspješna! Možeš se prijaviti.')

        setFormData(praznaForma)
        setIsLogin(true)
      }
    } catch (err) {
      console.error('Greška:', err)
      alert('Nešto nije u redu. Provjeri podatke.')
    }
  }

  return (
    <div className="auth-kontejner">
      <div className="auth-box">
        <h2>{isLogin ? 'Prijava' : 'Registracija'}</h2>

        <form
          className="auth-forma"
          onSubmit={handleSubmit}
          autoComplete="off"
        >
          {!isLogin && (
            <>
              <div className="input-grupa">
                <label>Korisničko ime:</label>
                <input
                  type="text"
                  name="korisnickoIme"
                  value={formData.korisnickoIme}
                  onChange={handleChange}
                  autoComplete="off"
                />
              </div>

              <div className="input-grupa">
                <label>Ime:</label>
                <input
                  type="text"
                  name="ime"
                  value={formData.ime}
                  onChange={handleChange}
                  autoComplete="off"
                />
              </div>

              <div className="input-grupa">
                <label>Prezime:</label>
                <input
                  type="text"
                  name="prezime"
                  value={formData.prezime}
                  onChange={handleChange}
                  autoComplete="off"
                />
              </div>
            </>
          )}

          <div className="input-grupa">
            <label>{isLogin ? 'Email ili korisničko ime:' : 'Email:'}</label>
            <input
              type={isLogin ? 'text' : 'email'}
              name={isLogin ? 'korisnikIdentifikator' : 'email'}
              placeholder={isLogin ? 'email ili korisničko ime' : 'email'}
              value={isLogin ? formData.korisnikIdentifikator : formData.email}
              onChange={handleChange}
              autoComplete="off"
            />
          </div>

          <div className="input-grupa">
            <label>Lozinka:</label>
            <input
              type="password"
              name="lozinka"
              value={formData.lozinka}
              onChange={handleChange}
              autoComplete="new-password"
            />
          </div>

          {!isLogin && (
            <div className="input-grupa">
              <label>Ponovi lozinku:</label>
              <input
                type="password"
                name="ponovljenaLozinka"
                value={formData.ponovljenaLozinka}
                onChange={handleChange}
                autoComplete="new-password"
              />
            </div>
          )}

          <button type="submit" className="btn-auth">
            {isLogin ? 'PRIJAVI ME' : 'REGISTRIRAJ ME'}
          </button>
        </form>

        <p className="auth-toggle-tekst">
          {isLogin ? 'Nemaš račun?' : 'Već imaš račun?'}
          <span onClick={prebaciFormu}>
            {isLogin ? ' Registriraj se' : ' Prijavi se'}
          </span>
        </p>
      </div>
    </div>
  )
}

export default Prijava