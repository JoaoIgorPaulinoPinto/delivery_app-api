using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
            return await _context.Estabelecimentos
                .Include(c => c.HorariosFuncionamento)
                .Include(c => c.EstabelecimentoStatus)
                .Where(e => e.Slug == slug)
                .AsNoTracking() 
                .FirstOrDefaultAsync(); 
        }
    }
}
