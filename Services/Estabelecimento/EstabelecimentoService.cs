using comaagora.DTO;
using comaagora.Repositories;

namespace comaagora.Services.Estabelecimento
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly EstabelecimentoRepository _repo;

        public EstabelecimentoService(EstabelecimentoRepository repo)
        {
            _repo = repo;
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

            return new GetEstabelecimentoDTO
            {
                Id = estabelecimento.Id,
                Slug = estabelecimento.Slug,
                NomeFantasia = estabelecimento.NomeFantasia,
                Telefone = estabelecimento.Telefone,
                Email = estabelecimento.Email,
                Whatsapp = estabelecimento.Whatsapp,
                Endereco = estabelecimento.Endereco == null
                    ? new GetEnderecoEstabelecimentoDTO()
                    : new GetEnderecoEstabelecimentoDTO()
                    {   
                        Rua = estabelecimento.Endereco.Rua,
                        Numero = estabelecimento.Endereco.Numero,
                        Bairro = estabelecimento.Endereco.Bairro,
                        Cidade = estabelecimento.Endereco.Cidade?.Nome ?? string.Empty,
                        Uf = estabelecimento.Endereco.Uf?.Uf ?? string.Empty,
                        Cep = estabelecimento.Endereco.Cep,
                        Complemento = estabelecimento.Endereco.Complemento
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
