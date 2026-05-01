using Microsoft.AspNetCore.Mvc;
using PulsGrada.Services;
using PulsGrada.Models;
using System.Collections.Generic;

namespace PulsGrada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KategorijaController : ControllerBase
    {
        private readonly IKategorijaService _kategorijaService;

        public KategorijaController(IKategorijaService kategorijaService)
        {
            _kategorijaService = kategorijaService;
        }

        [HttpGet]
        public IActionResult DohvatiSveKategorije()
        {
            var kategorije = _kategorijaService.DohvatiSveKategorije();

            if (kategorije == null || kategorije.Count == 0)
            {
                return NotFound(new { poruka = "Nema pronađenih kategorija u bazi." });
            }

            return Ok(kategorije);
        }
    }
}