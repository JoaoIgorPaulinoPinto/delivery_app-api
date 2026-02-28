using comaagora.Data;
using comaagora.DTO;
using comaagora.Services.Produto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Get([FromQuery] string slug) 
        {
            if (string.IsNullOrEmpty(slug))
                return BadRequest(new { error = "The slug field is required." });

            try
            {
                var produtos = await _produtoService.GetAll(slug);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _produtoService.GetById(id));
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

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] CreateProdutoDTO produto)
        {
            try
            {
                await _produtoService.Update(produto, id);
                return Ok(new { message = "Produto atualizado com sucesso." });
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

        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoDTO produto, [FromQuery] int estabelecimentoId)
        {
            try
            {
                await _produtoService.CreateProduto(produto, estabelecimentoId);
                return Ok(new { message = "Produto criado com sucesso." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("status")]
        public ActionResult GetProdutoStatus([FromHeader(Name = "estabelecimentoId")] int estabelecimentoId)
        {
            if (estabelecimentoId <= 0)
            {
                return BadRequest(new { error = "Estabelecimento invalido." });
            }

            return Ok(_context.ProdutoStatus.AsNoTracking()
                .Where(e => e.EstabelecimentoId == estabelecimentoId)
                .Select(c => new ProdutoStatusDTO
                {
                    Id = c.Id,
                    Nome = c.Nome
                }).ToList());
        }
    }
}
