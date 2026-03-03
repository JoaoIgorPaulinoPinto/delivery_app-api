using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services.Endereco
{
    public interface IEnderecoService
    {
        Models.Endereco CriarEndereco(CreateEnderecoDTO dto);
        Task<Models.Endereco?> GetByUsuarioIdAsync(int usuarioId);
        Task<Dictionary<int, Models.Endereco>> GetByUsuariosIdsAsync(IEnumerable<int> usuarioIds);
    }
}
