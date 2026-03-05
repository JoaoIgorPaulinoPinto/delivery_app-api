using comaagora.Services.Localizacao;
using Microsoft.AspNetCore.Mvc;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacaoController : ControllerBase
    {
        private readonly ILocalizacaoService _service;

        public LocalizacaoController(ILocalizacaoService service)
        {
            _service = service;
        }

        [HttpGet("estados")]
        public async Task<IActionResult> GetEstados()
        {
            return Ok(await _service.GetEstadosAsync());
        }

        [HttpGet("cidades")]
        public async Task<IActionResult> GetCidades([FromQuery] int estadoId)
        {
            try
            {
                return Ok(await _service.GetMunicipiosByEstadoIdAsync(estadoId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}
