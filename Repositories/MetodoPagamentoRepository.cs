using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
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
            var mthpgmnt = await _context.MetodoPagamento.AsNoTracking()
                    .Where(e => e.Estabelecimento.Slug == slug)
                    .Select(m => new MetodoPagamentoDTO {
                    Id=m.Id,
                    Nome = m.Nome,
                    Tipo = m.Tipo
                    }).ToListAsync();
            return mthpgmnt;
        }
    }
}
