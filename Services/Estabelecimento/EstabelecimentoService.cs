using comaagora.DTO;
using comaagora.Repositories;
using comaagora.Services.Endereco;

namespace comaagora.Services.Estabelecimento
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly EstabelecimentoRepository _repo;
        private readonly IEnderecoService _enderecoService;

        public EstabelecimentoService(EstabelecimentoRepository repo, IEnderecoService enderecoService)
        {
            _repo = repo;
            _enderecoService = enderecoService;
        }

        public async Task<GetEstabelecimentoDTO?> GetBySlug(string slug)
        {
            var normalizedSlug = slug?.Trim().ToLowerInvariant();
            if (string.IsNullOrWhiteSpace(normalizedSlug))
            {
                throw new ArgumentException("Slug do estabelecimento e obrigatorio.");
            }

            var estabelecimento = await _repo.GetBySlug(normalizedSlug);
            if (estabelecimento == null)
            {
                return null;
            }

            var endereco = await _enderecoService.GetByUsuarioIdAsync(estabelecimento.Id);

            return new GetEstabelecimentoDTO
            {
                Id = estabelecimento.Id,
                Slug = estabelecimento.Slug,
                NomeFantasia = estabelecimento.NomeFantasia,
                Telefone = estabelecimento.Telefone,
                Email = estabelecimento.Email,
                Whatsapp = estabelecimento.Whatsapp,
                Endereco = endereco == null
                    ? new GetEnderecoEstabelecimentoDTO()
                    : new GetEnderecoEstabelecimentoDTO()
                    {
                        Rua = endereco.Rua,
                        Numero = endereco.Numero,
                        Bairro = endereco.Bairro,
                        Cidade = endereco.Cidade?.Nome ?? string.Empty,
                        Uf = endereco.Uf?.Uf ?? string.Empty,
                        Cep = endereco.Cep,
                        Complemento = endereco.Complemento
                    },
                TaxaEntrega = estabelecimento.TaxaEntrega,
                PedidoMinimo = estabelecimento.PedidoMinimo,
                Status = estabelecimento.EstabelecimentoStatus?.Nome ?? string.Empty,
                HorariosFuncionamento = estabelecimento.HorarioFuncionamentos?
                    .Select(h => new GetHorarioFuncionamentoDTO
                    {
                        DiaSemana = h.DiaSemana,
                        Abertura = h.Abertura,
                        Fechamento = h.Fechamento
                    })
                    .ToList()
                    ?? new List<GetHorarioFuncionamentoDTO>()
            };
        }
    }
}
