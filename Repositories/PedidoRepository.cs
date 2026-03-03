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

        public async Task AddEnderecoAsync(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePedido(UpdatePedidoDTO dto, int id)
        {
            var pedidoNoBanco = await _context.Pedidos
                .Include(p => p.ProdutoPedidos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedidoNoBanco == null)
            {
                return false;
            }

            var endereco = await _context.Enderecos.FirstOrDefaultAsync(e => e.Usuario == pedidoNoBanco.Id);
            if (endereco == null)
            {
                return false;
            }

            pedidoNoBanco.NomeCliente = dto.Nome.Trim();
            pedidoNoBanco.TelefoneCliente = dto.Telefone.Trim();
            pedidoNoBanco.PedidoStatusId = dto.PedidoStatus.Id;
            pedidoNoBanco.MetodoPagamentoId = dto.MetodoPagamentoId;
            pedidoNoBanco.Observacao = dto.Observacao?.Trim() ?? string.Empty;

            endereco.Rua = dto.Endereco.Rua.Trim();
            endereco.Numero = dto.Endereco.Numero.Trim();
            endereco.CidadeId = dto.Endereco.Cidade;
            endereco.Bairro = dto.Endereco.Bairro.Trim();
            endereco.UfId = dto.Endereco.Uf;
            endereco.Cep = dto.Endereco.Cep.Trim();
            endereco.TipoId = 1;
            endereco.Complemento = string.IsNullOrWhiteSpace(dto.Endereco.Complemento)
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

        public async Task<Produto?> GetProdutoDoEstabelecimentoByIdAsync(int id, int estabelecimentoId)
        {
            return await _context.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id && p.EstabelecimentoId == estabelecimentoId);
        }

        public async Task<bool> MetodoPagamentoValidoAsync(int metodoPagamentoId, int estabelecimentoId)
        {
            return await _context.MetodoPagamento
                .AsNoTracking()
                .AnyAsync(mp =>
                    mp.Id == metodoPagamentoId &&
                    mp.EstabelecimentoId == estabelecimentoId &&
                    mp.Ativo);
        }

        public async Task<int?> GetStatusInicialPedidoIdAsync(int estabelecimentoId)
        {
            var statusPendenteId = await _context.PedidoStatus
                .AsNoTracking()
                .Where(ps => ps.EstabelecimentoId == estabelecimentoId && ps.Nome.ToLower() == "pendente")
                .Select(ps => (int?)ps.Id)
                .FirstOrDefaultAsync();

            if (statusPendenteId.HasValue)
            {
                return statusPendenteId.Value;
            }

            return await _context.PedidoStatus
                .AsNoTracking()
                .Where(ps => ps.EstabelecimentoId == estabelecimentoId)
                .OrderBy(ps => ps.Id)
                .Select(ps => (int?)ps.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Pedido?> GetPedidoCompletoByIdAsync(int pedidoId)
        {
            return await BuildPedidoQuery()
                .FirstOrDefaultAsync(p => p.Id == pedidoId);
        }

        public async Task<List<Pedido>> GetPedidosByClientKeyAsync(string clientKey, string slug)
        {
            return await BuildPedidoQuery()
                .Where(p => p.ClientKey == clientKey && p.Estabelecimento.Slug == slug)
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

        public async Task<bool> ClientKeyExistsAsync(string clientKey)
        {
            return await _context.Pedidos
                .AsNoTracking()
                .AnyAsync(p => p.ClientKey == clientKey);
        }

        private IQueryable<Pedido> BuildPedidoQuery()
        {
            return _context.Pedidos
                .AsNoTracking()
                .Include(p => p.PedidoStatus)
                .Include(p => p.Estabelecimento)
                .Include(p => p.Estabelecimento)
                    .ThenInclude(e => e.EstabelecimentoStatus)
                .Include(p => p.ProdutoPedidos)
                    .ThenInclude(pp => pp.Produto);
        }
    }
}
