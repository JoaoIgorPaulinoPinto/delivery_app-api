using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services.Endereco
{
    public class EnderecoService : IEnderecoService
    {
        public Models.Endereco CriarEndereco(CreateEnderecoDTO dto)
        {
            return new Models.Endereco
            {
                Rua = dto.Rua.Trim(),
                Numero = dto.Numero.Trim(),
                Bairro = dto.Bairro.Trim(),
                CidadeId = dto.Cidade,
                UfId = dto.Uf,
                Cep = dto.Cep.Trim(),
                Complemento = string.IsNullOrWhiteSpace(dto.Complemento) ? null : dto.Complemento.Trim(),
                TipoId = 1
            };
        }
    }
}
