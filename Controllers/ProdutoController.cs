using comaagora.Data;
using comaagora.Models;
using comaagora.Services;
using Microsoft.AspNetCore.Mvc;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] int estabelecimentoId)
        {
            return Ok(await _produtoService.GetAll( estabelecimentoId));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromHeader]int estabelecimentoId, int id)
        {
            return Ok(await _produtoService.GetByID(id, estabelecimentoId));
        }
    }
}
