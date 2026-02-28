using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services.ProdutoPedido
{
    public interface IProdutoPedidoService
    {
        Task<List<Models.ProdutoPedido>> CriarListaAsync(List<CreateProdutoPedidoDTO> itens, int estabelecimentoId);
    }
}
