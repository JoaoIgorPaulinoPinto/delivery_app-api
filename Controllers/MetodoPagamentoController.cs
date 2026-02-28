using comaagora.Services.MetodoPagamento;
using Microsoft.AspNetCore.Mvc;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetodoPagamentoController : ControllerBase
    {
        private readonly IMetodoPagamentoService _service;

        public MetodoPagamentoController(IMetodoPagamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMetodosPagamento([FromQuery] string slug)
        {
            try
            {
                return Ok(await _service.GetAll(slug));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
