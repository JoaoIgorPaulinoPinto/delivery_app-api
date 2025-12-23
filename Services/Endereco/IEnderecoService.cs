using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services
{
    public interface IEnderecoService
    {
        public Endereco CriarEndereco(CreateEnderecoDTO dto, int estabelecimentoId);
    }
}
