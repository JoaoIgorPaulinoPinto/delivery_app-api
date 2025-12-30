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

        public async Task<List<MetodoPagamentoDTO>> GetAll(int id)
        {
            var mthpgmnt = await _context.MetodoPagamento.AsNoTracking()
                    .Where(e => e.EstabelecimentoId == id)
                    .Select(m => new MetodoPagamentoDTO {
                    Id=m.Id,
                    Nome = m.Nome,
                    Tipo = m.Tipo
                    }).ToListAsync();
            return mthpgmnt;
        }
    }
}
