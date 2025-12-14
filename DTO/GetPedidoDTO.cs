using comaagora.Models;

namespace comaagora.DTO
{
    public class GetPedidoDTO
    {
        public string? Estabelecimento {  get; set; }
        public List<GetProdutoPedidoDTO>? produtos { get; set; }
        public GetUsuarioDTO? usuario { get; set; }
    }
}
