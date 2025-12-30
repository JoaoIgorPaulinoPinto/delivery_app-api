using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using comaagora.Services.Categoria;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetCategorias([FromHeader] int estabelecimentoId)
        {
            return Ok(await _service.GetCategorias(estabelecimentoId));
        }
    }
}
