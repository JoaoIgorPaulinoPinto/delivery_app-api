using comaagora.DTO;

namespace comaagora.Services.Pedido
{
    public interface IPedidoService
    {
        Task<GetPedidoDTO> CreatePedido(string? clientKey, string slug, CreatePedidoDTO dto);
        Task<List<GetPedidoDTO>> GetPedidosByClientKey(string clientKey, string slug);
        Task<GetPedidoDTO> GetPedidoById(int id);
        Task<List<GetPedidoDTO>> GetPedidos(string slug);
        Task<bool> UpdatePedido(UpdatePedidoDTO dto, int id);
        Task<List<PedidoStatusDTO>> GetPedidoStatus(int estabelecimentoId);
    }
}
