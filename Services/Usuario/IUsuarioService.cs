using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<Models.Usuario> ResolverUsuario(string? clientKey, int estId, CreateUsuarioDTO dto);
    }
}
