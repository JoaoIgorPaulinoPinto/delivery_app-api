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
                .Where(e => e.slug == slug)
                .Select(e => new GetEstabelecimentoDTO
                {
                    Id = e.Id,
                    slug = e.slug,
                    NomeFantasia = e.NomeFantasia,
                    Telefone = e.Telefone,
                    Email = e.Email,
                    Whatsapp = e.Whatsapp,
                    Endereco = e.Endereco,
                    Abertura = e.Abertura,
                    Fechamento = e.Fechamento,
                    TaxaEntrega = e.TaxaEntrega,
                    PedidoMinimo = e.PedidoMinimo,
                    Status = e.EstabelecimentoStatus
                })
                .FirstOrDefaultAsync();

            return estabelecimento;
        }

    }
}
