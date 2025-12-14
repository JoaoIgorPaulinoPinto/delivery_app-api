using comaagora.Data;
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

        // Adiciona um pedido
        public async Task AddPedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        // Adiciona lista de produtos do pedido
        public async Task AddProdutosPedidoAsync(List<ProdutoPedido> produtos)
        {
            _context.ProdutoPedidos.AddRange(produtos);
            await _context.SaveChangesAsync();
        }

        // Busca pedido por ID e estabelecimento
        public async Task<Pedido?> GetByIdAsync(int id, int estabelecimentoId)
        {
            return await _context.Pedidos
                .Include(p => p.Produtos)
                 .ThenInclude(pp => pp.Produto)
                .Include(p => p.Usuario)
                .Include(p => p.Estabelecimento)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id && p.EstabelecimentoId == estabelecimentoId);
        }

        // Busca produto por ID
        public async Task<Models.Produto?> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        // Busca estabelecimento por ID
        public async Task<Models.Estabelecimento?> GetEstabelecimentoByIdAsync(int id)
        {
            return await _context.Estabelecimentos.FindAsync(id);
        }

        // Adiciona endereço
        public async Task AddEnderecoAsync(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
        }

        // Adiciona usuário
        public async Task AddUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
