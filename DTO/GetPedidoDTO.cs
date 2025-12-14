using comaagora.Models;

namespace comaagora.DTO
{
    public class GetPedidoDTO
    {
        public required string? Estabelecimento {  get; set; }
        public required List<GetProdutoPedidoDTO>? produtos { get; set; }
        public required GetUsuarioDTO? usuario { get; set; }
    }
}
