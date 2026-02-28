using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Repositories
{
    public class PedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePedido(UpdatePedidoDTO dto, int id)
        {
            var pedidoNoBanco = await _context.Pedidos
                .Include(p => p.Usuario)
                .Include(p => p.Endereco)
                .Include(p => p.ProdutoPedidos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedidoNoBanco == null)
            {
                return false;
            }

            pedidoNoBanco.Usuario.Nome = dto.Nome.Trim();
            pedidoNoBanco.Usuario.Telefone = dto.Telefone.Trim();
            pedidoNoBanco.PedidoStatusId = dto.PedidoStatus.Id;
            pedidoNoBanco.MetodoPagamentoId = dto.MetodoPagamentoId;
            pedidoNoBanco.Observacao = dto.Observacao?.Trim() ?? string.Empty;

            pedidoNoBanco.Endereco.Rua = dto.Endereco.Rua.Trim();
            pedidoNoBanco.Endereco.Numero = dto.Endereco.Numero.Trim();
            pedidoNoBanco.Endereco.CidadeId = dto.Endereco.Cidade;
            pedidoNoBanco.Endereco.Bairro = dto.Endereco.Bairro.Trim();
            pedidoNoBanco.Endereco.UfId = dto.Endereco.Uf;
            pedidoNoBanco.Endereco.Cep = dto.Endereco.Cep.Trim();
            pedidoNoBanco.Endereco.Complemento = string.IsNullOrWhiteSpace(dto.Endereco.Complemento)
                ? null
                : dto.Endereco.Complemento.Trim();

            if (dto.Produtos != null)
            {
                foreach (var prodDto in dto.Produtos)
                {
                    var itemBanco = pedidoNoBanco.ProdutoPedidos.FirstOrDefault(p => p.ProdutoId == prodDto.ProdutoId);
                    if (itemBanco != null)
                    {
                        itemBanco.Quantidade = prodDto.Quantidade;
                        itemBanco.Subtotal = itemBanco.PrecoUnitario * itemBanco.Quantidade;
                    }
                }
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await BuildPedidoQuery()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Produto?> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pedido?> GetPedidoCompletoByIdAsync(int pedidoId)
        {
            return await BuildPedidoQuery()
                .FirstOrDefaultAsync(p => p.Id == pedidoId);
        }

        public async Task<List<Pedido>> GetPedidosByClientKeyAsync(string clientKey, string slug)
        {
            return await BuildPedidoQuery()
                .Where(p => p.Usuario.ClientKey == clientKey && p.Estabelecimento.Slug == slug)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<List<Pedido>> GetPedidosByStablishmentId(string slug)
        {
            return await BuildPedidoQuery()
                .Where(p => p.Estabelecimento.Slug == slug)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<List<PedidoStatusDTO>> GetPedidoStatus(int estabelecimentoId)
        {
            return await _context.PedidoStatus
                .AsNoTracking()
                .Where(ps => ps.EstabelecimentoId == estabelecimentoId)
                .OrderBy(ps => ps.Nome)
                .Select(ps => new PedidoStatusDTO
                {
                    Id = ps.Id,
                    Nome = ps.Nome
                })
                .ToListAsync();
        }

        private IQueryable<Pedido> BuildPedidoQuery()
        {
            return _context.Pedidos
                .AsNoTracking()
                .Include(p => p.PedidoStatus)
                .Include(p => p.Endereco)
                .Include(p => p.Usuario)
                .Include(p => p.Estabelecimento)
                    .ThenInclude(e => e.Endereco)
                .Include(p => p.Estabelecimento)
                    .ThenInclude(e => e.EstabelecimentoStatus)
                .Include(p => p.ProdutoPedidos)
                    .ThenInclude(pp => pp.Produto);
        }
    }
}
