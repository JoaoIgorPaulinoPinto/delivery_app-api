using comaagora.Data;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Repositories
{
    public class EstabelecimentoRepository
    {
        private readonly AppDbContext _context;

        public EstabelecimentoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Estabelecimento?> GetBySlug(string slug)
        {
            if (string.IsNullOrEmpty(slug)) return null;

            return await _context.Estabelecimentos
                .AsNoTracking()
                .Include(e => e.EstabelecimentoStatus)
                .Include(e => e.HorarioFuncionamentos)
                .Where(e => e.Slug == slug)
                .FirstOrDefaultAsync();
        }
    }
}
