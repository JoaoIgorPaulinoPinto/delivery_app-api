using comaagora.Data;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Repositories
{
    public class UsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByClientKey(string clientKey, int estId)
        {
            return await _context.Usuarios
                .Include(u => u.Endereco)
                .FirstOrDefaultAsync(u => u.ClientKey == clientKey && u.EstabelecimentoId == estId);
        }
    }
}
