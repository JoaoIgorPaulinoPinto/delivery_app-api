using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;

namespace comaagora.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _usuarioRepo;

        public UsuarioService(UsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<Models.Usuario> ResolverUsuario(string? clientKey, int estId, CreateUsuarioDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(clientKey))
            {
                var normalizedClientKey = clientKey.Trim().ToLowerInvariant();
                var usuario = await _usuarioRepo.GetByClientKey(normalizedClientKey, estId);
                if (usuario != null)
                {
                    return usuario;
                }
            }

            return new Models.Usuario
            {
                Nome = dto.Nome.Trim(),
                Telefone = dto.Telefone.Trim(),
                EstabelecimentoId = estId,
                ClientKey = Guid.NewGuid().ToString("N")
            };
        }
    }
}
