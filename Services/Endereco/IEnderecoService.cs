using comaagora.DTO;

namespace comaagora.Services.Endereco
{
    public interface IEnderecoService
    {
        public Models.Endereco CriarEndereco(CreateEnderecoDTO dto, int estabelecimentoId);
    }
}
