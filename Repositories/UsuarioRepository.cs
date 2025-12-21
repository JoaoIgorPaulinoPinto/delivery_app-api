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
        // UsuarioRepository
        public async Task<Usuario?> GetByClientKey(string clientKey, int estId)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.clientKey == clientKey && u.EstabelecimentoId == estId);
        }

    }
}
