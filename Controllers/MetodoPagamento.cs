using comaagora.Data;
using comaagora.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetodoPagamento : ControllerBase
    {
        private readonly AppDbContext _context;
        public MetodoPagamento(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetMetodosPagamento([FromHeader] int EstabelecimentoId)
        {
            return Ok(_context.MetodoPagamento.AsNoTracking()
                .Where(e => e.EstabelecimentoId == EstabelecimentoId)
                .Select(c => new ProdutoCategoriaDTO
                {
                    Id = c.Id,
                    Nome = c.Nome ?? "",
                }).ToList());
        }
    }
}
