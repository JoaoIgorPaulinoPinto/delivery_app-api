using comaagora.Data;
using comaagora.DTO;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Repositories
{
    public class MetodoPagamentoRepository
    {
        private readonly AppDbContext _context;

        public MetodoPagamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MetodoPagamentoDTO>> GetAll(string slug)
        {
            return await _context.MetodoPagamento
                .AsNoTracking()
                .Where(m => m.Estabelecimento.Slug == slug)
                .OrderBy(m => m.Nome)
                .Select(m => new MetodoPagamentoDTO
                {
                    Id = m.Id,
                    Nome = m.Nome,
                    Tipo = m.Tipo
                })
                .ToListAsync();
        }
    }
}
