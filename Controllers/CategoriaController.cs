using comaagora.Services.Categoria;
using Microsoft.AspNetCore.Mvc;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategorias([FromQuery]string slug)
        {
            try
            {
                return Ok(await _service.GetCategorias(slug));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
