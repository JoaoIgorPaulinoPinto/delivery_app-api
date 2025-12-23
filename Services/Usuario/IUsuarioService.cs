using comaagora.DTO;
using comaagora.Models;

public interface IUsuarioService
{
    public Task<Usuario> ResolverUsuario(string? clientKey, int estId, CreateUsuarioDTO dto);
}
