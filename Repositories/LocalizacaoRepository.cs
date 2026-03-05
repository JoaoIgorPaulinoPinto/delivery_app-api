using comaagora.Data;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Repositories
{
    public class LocalizacaoRepository
    {
        private readonly AppDbContext _context;

        public LocalizacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estado>> GetEstadosAsync()
        {
            return await _context.Set<Estado>()
                .AsNoTracking()
                .OrderBy(e => e.Nome)
                .ToListAsync();
        }

        public async Task<Estado?> GetEstadoByIdAsync(int estadoId)
        {
            return await _context.Set<Estado>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == estadoId);
        }

        public async Task<List<Municipio>> GetMunicipiosByUfAsync(string uf)
        {
            return await _context.Set<Municipio>()
                .AsNoTracking()
                .Where(m => m.Uf == uf)
                .OrderBy(m => m.Nome)
                .ToListAsync();
        }
    }
}
