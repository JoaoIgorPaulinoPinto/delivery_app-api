using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services.Endereco
{
    public interface IEnderecoService
    {
        Models.Endereco CriarEndereco(CreateEnderecoDTO dto);
    }
}
