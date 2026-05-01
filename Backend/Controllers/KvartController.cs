using Microsoft.AspNetCore.Mvc;
using PulsGrada.Services;
using PulsGrada.Models;
using System.Collections.Generic;

namespace PulsGrada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KvartController : ControllerBase
    {
        private readonly IKvartService _kvartService;

        public KvartController(IKvartService kvartService)
        {
            _kvartService = kvartService;
        }

        [HttpGet]
        public IActionResult DohvatiSveKvartove()
        {
            var kvartovi = _kvartService.DohvatiSveKvartove();
            
            if (kvartovi == null || kvartovi.Count == 0)
            {
                return NotFound(new { poruka = "Nema pronađenih kvartova u bazi." });
            }

            return Ok(kvartovi);
        }
    }
}