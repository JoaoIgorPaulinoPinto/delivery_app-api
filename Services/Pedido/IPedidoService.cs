using comaagora.DTO;

namespace comaagora.Services.Pedido
{
    public interface IPedidoService
    {
        public Task<string> CreatePedido(int esabelecimentoId, CreatePedidoDTO dto);
        public Task<GetPedidoDTO> GetPedidoById(int estabelecimentoId,int id);
    }
}
