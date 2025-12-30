using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Repositories
{
    public class CategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProdutoCategoria>> GetCategorias(int estabelecimentoId)
        {
            return await _context.ProdutoCategorias.AsNoTracking()
                              .Where(e => e.EstabelecimentoId == estabelecimentoId).ToListAsync();
        }
    }
}
