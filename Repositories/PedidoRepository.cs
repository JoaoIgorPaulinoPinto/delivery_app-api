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
        // Atualiza o Status do Pedido
        public async Task<bool> UpdateOrderStatus(int orderId, int statusId)
        {
            // 1. Fetch the order
            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(p => p.Id == orderId);

            if (pedido == null)
                return false;

            // 2. Update the Foreign Key directly
            // Replace 'PedidoStatusId' with the actual FK name in your Pedido class
            pedido.PedidoStatusId = statusId;

            // 3. Save changes
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();

            return true;
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
        public async Task<Models.PedidoStatus?> GetPedidoStatusByIdAsync(int id)
        {
            return await _context.PedidoStatus.FindAsync(id);
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
        public async Task<Pedido?> GetPedidoCompletoByIdAsync(int pedidoId)
        {
            return await _context.Pedidos
                .AsNoTracking()
                .Include(p => p.PedidoStatus)

                .Include(p => p.Endereco)

                .Include(p => p.Usuario)

                .Include(p => p.Estabelecimento)
                    .ThenInclude(e => e.Endereco)

                .Include(p => p.Estabelecimento)
                    .ThenInclude(e => e.EstabelecimentoStatus)

                .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)

                .FirstOrDefaultAsync(p => p.Id == pedidoId);
        }
        // Adiciona usuário
        public async Task AddUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Pedido>> GetPedidosByClientKeyAsync(
            string clientKey,
            int estabelecimentoId)
        {
            return await _context.Pedidos
                .AsNoTracking()

                .Include(p => p.PedidoStatus)

                .Include(p => p.Endereco)

                .Include(p => p.Usuario)

                .Include(p => p.Estabelecimento)
                    .ThenInclude(e => e.Endereco)

                .Include(p => p.Estabelecimento)
                    .ThenInclude(e => e.EstabelecimentoStatus)

                .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)

                .Where(p =>
                    p.Usuario.ClientKey == clientKey &&
                    p.EstabelecimentoId == estabelecimentoId)

                .OrderByDescending(p => p.Id)

                .ToListAsync();
        }
        public async Task<List<Pedido>> GetPedidosByStablishmentId(
                  int estabelecimentoId)
        {
            return await _context.Pedidos
                .AsNoTracking()

                .Include(p => p.PedidoStatus)

                .Include(p => p.Endereco)

                .Include(p => p.Usuario)

                .Include(p => p.Estabelecimento)
                    .ThenInclude(e => e.Endereco)

                .Include(p => p.Estabelecimento)
                    .ThenInclude(e => e.EstabelecimentoStatus)

                .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)

                .Where(p =>
                    p.EstabelecimentoId == estabelecimentoId)

                .OrderByDescending(p => p.Id)

                .ToListAsync();
        }

    }
}
