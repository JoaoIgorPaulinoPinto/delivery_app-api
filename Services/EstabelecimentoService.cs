using comaagora.Data;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Services
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly AppDbContext _context;
        public EstabelecimentoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int?> GetIdBySlug(string slug)
        {
            return await _context.Estabelecimentos
             .Where(e => e.slug == slug)
             .Select(e => (int?)e.Id)
             .FirstOrDefaultAsync();
        }


    }
}
