using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;

namespace comaagora.Services.ProdutoPedido
{
    public class ProdutoPedidoService : IProdutoPedidoService
    {
        private readonly PedidoRepository _pedidoRepo;

        public ProdutoPedidoService(PedidoRepository pedidoRepo)
        {
            _pedidoRepo = pedidoRepo;
        }

        public async Task<List<Models.ProdutoPedido>> CriarListaAsync(List<CreateProdutoPedidoDTO> itens, int estabelecimentoId)
        {
            var lista = new List<Models.ProdutoPedido>();

            foreach (var item in itens)
            {
                var produto = await _pedidoRepo.GetProdutoDoEstabelecimentoByIdAsync(item.ProdutoId, estabelecimentoId)
                    ?? throw new KeyNotFoundException($"Produto {item.ProdutoId} nao encontrado para este estabelecimento.");

                lista.Add(new Models.ProdutoPedido
                {
                    ProdutoId = produto.Id,
                    Quantidade = item.Quantidade,
                    EstabelecimentoId = estabelecimentoId,
                    PrecoUnitario = produto.Preco,
                    Subtotal = produto.Preco * item.Quantidade
                });
            }

            return lista;
        }
    }
}
