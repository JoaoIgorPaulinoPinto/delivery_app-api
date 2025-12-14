using comaagora.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoService _estabelecimentoService;

        public EstabelecimentoController(IEstabelecimentoService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBySlug([FromQuery]string slug)
        {
            return Ok(await _estabelecimentoService.GetIdBySlug(slug));
        }
    }
}
