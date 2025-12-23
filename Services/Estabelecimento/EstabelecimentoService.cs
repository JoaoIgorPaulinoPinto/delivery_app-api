using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Services.Estabelecimento
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly AppDbContext _context;
        public EstabelecimentoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetEstabelecimentoDTO?> GetBySlug(string slug)
        {
            var estabelecimento = await _context.Estabelecimentos
                .Where(e => e.Slug == slug)
                .Select(e => new GetEstabelecimentoDTO
                {
                    Id = e.Id,
                    Slug = e.Slug,
                    NomeFantasia = e.NomeFantasia,
                    Telefone = e.Telefone,
                    Email = e.Email,
                    Whatsapp = e.Whatsapp,
                    Endereco = new GetEnderecoDTO
                    {
                        Rua = e.Endereco.Rua,
                        Numero = e.Endereco.Numero,
                        Bairro = e.Endereco.Bairro,
                        Cidade = e.Endereco.Cidade,
                        Uf = e.Endereco.Uf,
                        Cep = e.Endereco.Cep,
                        Complemento = e.Endereco.Complemento
                    },
                    TaxaEntrega = e.TaxaEntrega,
                    PedidoMinimo = e.PedidoMinimo,
                    Status = e.EstabelecimentoStatus.Nome,
                    HorariosFuncionamento = e.HorariosFuncionamento
                        .Select(h => new GetHorarioFuncionamentoDTO
                        {
                            DiaSemana = h.DiaSemana,
                            Abertura = h.Abertura,
                            Fechamento = h.Fechamento
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return estabelecimento;
        }
    }
}
