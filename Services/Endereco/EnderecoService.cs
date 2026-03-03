using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;

namespace comaagora.Services.Endereco
{
    public class EnderecoService : IEnderecoService
    {
        private readonly Repositories.EnderecoRepository _enderecoRepo;
        public EnderecoService(EnderecoRepository repo)
        {

            _enderecoRepo = repo;
        }

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

        public async Task<Models.Endereco?> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _enderecoRepo.GetByUsuarioIdAsync(usuarioId);
        }

        public async Task<Dictionary<int, Models.Endereco>> GetByUsuariosIdsAsync(IEnumerable<int> usuarioIds)
        {
            return await _enderecoRepo.GetByUsuariosIdsAsync(usuarioIds);
        }
    }
}
