using comaagora.Models;
using comaagora.DTO;

public interface IProdutoPedidoService
{
    Task<List<ProdutoPedido>> CriarListaAsync(List<CreateProdutoPedidoDTO> itens, int estabelecimentoId);
}
