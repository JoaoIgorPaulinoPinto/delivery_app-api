using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetCategorias([FromHeader] int EstabelecimentoId)
        {
            return Ok(_context.ProdutoCategorias.AsNoTracking()
                .Where(e => e.EstabelecimentoId == EstabelecimentoId)
                .Select(c => new ProdutoCategoriaDTO
                {
                    Id = c.Id,
                    Nome = c.nome ?? "",
                }).ToList());
        }
    }
}
