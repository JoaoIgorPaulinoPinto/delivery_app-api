using comaagora.Models;

namespace comaagora.DTO
{
    public class GetPedidoDTO
    {
        public int EstabelecimentoId {  get; set; }
        public List<ProdutoPedido>? produtos { get; set; }
        public Usuario? usuario { get; set; }
    }
}
