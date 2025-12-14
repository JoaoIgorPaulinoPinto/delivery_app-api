using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;
namespace comaagora.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreatePedido(int estabelecimentoId, CreatePedidoDTO dto)
        {

            var endereco = new Endereco
            {
                Rua = dto.Endereco.Rua,
                Numero = dto.Endereco.Numero,
                Bairro = dto.Endereco.Bairro,
                Cidade = dto.Endereco.Cidade
            };

            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
            var Usuario = new Usuario
            {
                Nome = dto.Usuario.Nome,
                Telefone = dto.Usuario.Telefone,
                EnderecoId = endereco.Id,
                EstabelecimentoId = estabelecimentoId,
                clientKey = "client key"
            };
            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();


            
            var pedido = new Models.Pedido
            {
                UsuarioId = Usuario.Id,
                EstabelecimentoId = estabelecimentoId,
                EnderecoId = endereco.Id,
                Observacao = dto.Observacao,
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync(); 

            
            foreach (var item in dto.Produtos)
            {
                var pedidoProduto = new ProdutoPedido
                {
                    PedidoId = pedido.Id,
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    EstabelecimentoId = estabelecimentoId,
                };

                _context.ProdutoPedidos.Add(pedidoProduto);
            }

            await _context.SaveChangesAsync();

            return pedido.Id.ToString();
        }
        public async Task<GetPedidoDTO> GetPedidoById(int id, int estabelecimentoId)
        {
            var data = await _context.Pedidos.AsNoTracking().Where(p => p.EstabelecimentoId == estabelecimentoId && p.Id == id).Select(p => new GetPedidoDTO
            {
                Estabelecimento = p.Estabelecimento.NomeFantasia,
                produtos = p.Produtos.Select(prod => new GetProdutoPedidoDTO
                {
                    Produto = prod.Produto.Nome,
                    Preco = prod.Produto.Preco,
                    Quantidade = prod.Quantidade
                }).ToList(),
                usuario = new GetUsuarioDTO { nome = p.Usuario.Nome, telefone = p.Usuario.Telefone}
            }).FirstOrDefaultAsync();
            return data ?? new GetPedidoDTO();
        }
    }
}
