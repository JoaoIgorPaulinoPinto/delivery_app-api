using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services.Pedido
{
    public interface IPedidoService
    {
        public Task<GetPedidoDTO> CreatePedido(string? clientKey, string slug, CreatePedidoDTO dto);
        public Task<List<GetPedidoDTO>> GetPedidosByClientKey(string clientKey, string slug);
        public Task<GetPedidoDTO> GetPedidoById(int id);
        public Task<List<GetPedidoDTO>> GetPedidos(string slug);
        public Task<bool> UpdatePedido(UpdatePedidoDTO dto, int id);
    }
}
