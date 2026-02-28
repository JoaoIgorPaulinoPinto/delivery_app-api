using comaagora.Services.Estabelecimento;
using Microsoft.AspNetCore.Mvc;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoService _estabelecimentoService;

        public EstabelecimentoController(IEstabelecimentoService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBySlug([FromQuery] string slug)
        {
            try
            {
                var est = await _estabelecimentoService.GetBySlug(slug);
                return est == null ? NotFound() : Ok(est);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
