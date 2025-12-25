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
        public async Task<bool> UpdatePedido(UpdatePedidoDTO dto, int id)
        {
            // 1. Busca o pedido real com todos os relacionamentos
            var pedidoNoBanco = await _context.Pedidos
                .Include(p => p.Usuario)
                .Include(p => p.Endereco)
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedidoNoBanco == null) return false;

            // 2. Atualiza os dados simples
            pedidoNoBanco.Usuario.Nome = dto.Nome;
            if (dto.PedidoStatus != null)
            {
                // Atribua apenas se o ID for diferente, para evitar marcações desnecessárias de "Modified"
                if (pedidoNoBanco.PedidoStatusId != dto.PedidoStatus.id)
                {
                    pedidoNoBanco.PedidoStatusId = dto.PedidoStatus.id;
                }
            }
            pedidoNoBanco.Endereco.Rua = dto.Endereco.Rua;
            pedidoNoBanco.Endereco.Numero = dto.Endereco.Numero;
            pedidoNoBanco.Endereco.Cidade = dto.Endereco.Cidade;
            pedidoNoBanco.Endereco.Bairro = dto.Endereco.Bairro;
            pedidoNoBanco.Endereco.Uf = dto.Endereco.Uf;

            // 3. Sincroniza os Produtos (Atualiza quantidades)
            if (dto.Produtos != null)
            {
                foreach (var prodDto in dto.Produtos)
                {
                    var itemBanco = pedidoNoBanco.Produtos.FirstOrDefault(p => p.Id == prodDto.ProdutoId);
                    if (itemBanco != null)
                    {
                        itemBanco.Quantidade = prodDto.Quantidade;
                    }
                }
            }

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Produtos)
                 .ThenInclude(pp => pp.Produto)
                .Include(p => p.Usuario)
                .Include(p => p.PedidoStatus)
                .Include(p => p.Estabelecimento)
                .FirstOrDefaultAsync(p => p.Id == id );
        }

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
