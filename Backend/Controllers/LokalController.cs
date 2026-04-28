using Microsoft.AspNetCore.Mvc;
using PulsGrada.Services;

namespace PulsGrada.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class LokalController : ControllerBase 
    {
        private readonly ILokalService _lokalService;

        public LokalController(ILokalService lokalService)
        {
            _lokalService = lokalService;
        }

        [HttpGet]
        public IActionResult DohvatiSveLokale()
        {
            var lokali = _lokalService.DohvatiSveLokale();

            return Ok(lokali);
        }
        [HttpGet("{id}")]
        public IActionResult DohvatiLokalPoId(int id)
        {
            var lokal = _lokalService.DohvatiPojediniLokal(id);
            if(lokal == null)
            {
                return NotFound(new { poruka = $"Lokal nije pronađen" });
            }
            return Ok(lokal);
        }
    }
}