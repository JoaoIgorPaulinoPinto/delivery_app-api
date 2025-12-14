using comaagora.Data;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Repositories
{
    public class ProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        // Busca todos os produtos de um estabelecimento
        public async Task<List<Produto>> GetAllByEstabelecimentoAsync(int estabelecimentoId)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Status)
                .Include(p => p.Estabelecimento)
                .AsNoTracking()
                .Where(p => p.EstabelecimentoId == estabelecimentoId)
                .ToListAsync();
        }

        // Busca produto por ID e estabelecimento
        public async Task<Produto?> GetByIdAsync(int id, int estabelecimentoId)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Status)
                .Include(p => p.Estabelecimento)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id && p.EstabelecimentoId == estabelecimentoId);
        }
    }
}
