using comaagora.Data;
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
            var estabelecimento = await _repo.GetBySlug(slug);

            if (estabelecimento == null)
            {
                throw new Exception("Erro ao encontrar estabelecimento");
            }
            GetEstabelecimentoDTO estabelecimentoMapeado = new GetEstabelecimentoDTO
            {
                Id = estabelecimento.Id,
                Slug = estabelecimento.Slug,
                NomeFantasia = estabelecimento.NomeFantasia,
                Telefone = estabelecimento.Telefone,
                Email = estabelecimento.Email,
                Whatsapp = estabelecimento.Whatsapp,
                Endereco = new GetEnderecoDTO
                {
                    Rua = estabelecimento.Endereco.Rua,
                    Numero = estabelecimento.Endereco.Numero,
                    Bairro = estabelecimento.Endereco.Bairro,
                    Cidade = estabelecimento.Endereco.Cidade,
                    Uf = estabelecimento.Endereco.Uf,
                    Cep = estabelecimento.Endereco.Cep,
                    Complemento = estabelecimento.Endereco.Complemento,
                },
                TaxaEntrega = estabelecimento.TaxaEntrega,
                PedidoMinimo = estabelecimento.PedidoMinimo,
                Status = estabelecimento.EstabelecimentoStatus.Nome,
                HorariosFuncionamento = estabelecimento.HorariosFuncionamento.Select(h => new GetHorarioFuncionamentoDTO
                {
                    DiaSemana = h.DiaSemana,
                    Abertura = h.Abertura,
                    Fechamento = h.Fechamento
                }).ToList(),
            };
            return estabelecimentoMapeado;
        } 
    }
}
