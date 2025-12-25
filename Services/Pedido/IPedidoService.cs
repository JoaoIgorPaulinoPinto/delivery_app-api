using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services.Pedido
{
    public interface IPedidoService
    {
        public Task<GetPedidoDTO> CreatePedido(string? clientKey, int esabelecimentoId, CreatePedidoDTO dto);
        public Task<List<GetPedidoDTO>> GetPedidosByClientKey(string clientKey, int estabelecimentoId);
        public Task<GetPedidoDTO> GetPedidoById(int id);
        public Task<List<GetPedidoDTO>> GetPedidos(int estabelecimentoId);
        public Task<bool> UpdatePedido(UpdatePedidoDTO dto, int id);
    }
}
