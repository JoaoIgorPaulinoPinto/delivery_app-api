using comaagora.Data;
using comaagora.DTO;
using comaagora.Services;
using comaagora.Services.MetodoPagamento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetodoPagamentoController : ControllerBase
    {
        private readonly IMetodoPagamentoService _service;

        public MetodoPagamentoController(IMetodoPagamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMetodosPagamento([FromHeader] string slug)
        {
            return Ok(await _service.GetAll(slug));
        }
    }
}
