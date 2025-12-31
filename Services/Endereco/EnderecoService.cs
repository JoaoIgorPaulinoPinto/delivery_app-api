using comaagora.DTO;
using comaagora.Models;
using comaagora.Services.Endereco;

public class EnderecoService: IEnderecoService
{
    public Endereco CriarEndereco(CreateEnderecoDTO dto, string slug)
    {
        return new Endereco
        {
            Rua = dto.Rua,
            Numero = dto.Numero,
            Bairro = dto.Bairro,
            Cidade = dto.Cidade,
            Uf = dto.Uf,
            Cep = dto.Cep,
            Complemento = dto.Complemento,
        };
    }
}
