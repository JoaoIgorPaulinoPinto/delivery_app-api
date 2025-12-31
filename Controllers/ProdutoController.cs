using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using comaagora.Services.Produto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context, IProdutoService produtoService)
        {
            _context = context;
            _produtoService = produtoService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string slug)
        {
            try
            {
                return Ok(await _produtoService.GetAll(slug));

            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromHeader]string slug, int id)
        {
            try
            {
                return Ok(await _produtoService.GetByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduto(CreateProdutoDTO produto, int id)
        {
            var res = await _produtoService.Update(produto, id);
            if (res)
            {
                return Ok(new { message = "Pedido atualizado" });
            }
            else
            {
                return NotFound(new { message = "Produto não encontrado." });
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduto(CreateProdutoDTO produto, int estabelecimentoId)
        {
            var res = await _produtoService.CreateProduto(produto, estabelecimentoId);
            if (res)
            {
                return Ok(new { message = "Produto Criado!" });
            }
            else
            {
                return NotFound(new { message = "Erro ao criar produto" });
            }
        }
        [HttpGet("Status")]
        public ActionResult GetProdutoStatus([FromHeader] int EstabelecimentoId)
        {
            return Ok(_context.ProdutoStatus.AsNoTracking()
                .Where(e => e.EstabelecimentoId == EstabelecimentoId)
                .Select(c => new ProdutoStatusDTO
                {
                    Id = c.Id,
                    Nome = c.Nome ?? "",
                }).ToList());
        }
    }
}
