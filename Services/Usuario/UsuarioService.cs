using comaagora.Models;
using comaagora.DTO;
using comaagora.Repositories;

public class UsuarioService : IUsuarioService
{
    private readonly UsuarioRepository _usuarioRepo;

    public UsuarioService(UsuarioRepository usuarioRepo)
    {
        _usuarioRepo = usuarioRepo;
    }

    public async Task<Usuario> ResolverUsuario(string? clientKey, int estId, CreateUsuarioDTO dto)
    {
        if (!string.IsNullOrWhiteSpace(clientKey))
        {
            var usuario = await _usuarioRepo.GetByClientKey(clientKey.Trim().ToLower(), estId);
            if (usuario != null)
                return usuario;
        }

        return new Usuario
        {
            Nome = dto.Nome,
            Telefone = dto.Telefone,
            EstabelecimentoId = estId,
            ClientKey = Guid.NewGuid().ToString("N")
        };
    }
}
