using comaagora.Models;
using comaagora.DTO;
using comaagora.Repositories;

public class ProdutoPedidoService:IProdutoPedidoService
{
    private readonly PedidoRepository _pedidoRepo;

    public ProdutoPedidoService(PedidoRepository pedidoRepo)
    {
        _pedidoRepo = pedidoRepo;
    }

    public async Task<List<ProdutoPedido>> CriarListaAsync(List<CreateProdutoPedidoDTO> itens, int estabelecimentoId)
    {
        var lista = new List<ProdutoPedido>();

        foreach (var item in itens)
        {
            var produto = await _pedidoRepo.GetProdutoByIdAsync(item.ProdutoId)
                ?? throw new KeyNotFoundException($"Produto {item.ProdutoId} não encontrado.");

            lista.Add(new ProdutoPedido
            {
                Produto = produto,
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
