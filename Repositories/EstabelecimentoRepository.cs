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
        public async Task<Estabelecimento> GetBySlug(string slug)
        {
            var est = await _context.Estabelecimentos
                .Include(c => c.HorariosFuncionamento)
                .Include(c => c.Endereco)
                .Include(c => c.EstabelecimentoStatus)
                .Where(e => e.Slug == slug)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (est != null)
            {
                return est;
            }
            else
            {
                throw new Exception(message: "Erro ao encontrar estabelecimento");
            }
        }
    }
}
