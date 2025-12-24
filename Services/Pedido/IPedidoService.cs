using comaagora.DTO;

namespace comaagora.Services.Pedido
{
    public interface IPedidoService
    {
        public Task<GetPedidoDTO> CreatePedido(string? clientKey, int esabelecimentoId, CreatePedidoDTO dto);
        public Task<List<GetPedidoDTO>> GetPedidosByClientKey(string clientKey, int estabelecimentoId);
        public Task<List<GetPedidoDTO>> GetPedidos(int estabelecimentoId);
        public Task<bool> UpdateOrderStatus(int pedidoId, int statusId);
    }
}
