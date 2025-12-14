using comaagora.Models;

namespace comaagora.DTO
{
    public class GetProdutoPedidoDTO
    {
        public required string Produto { get; set; }
        public required int Quantidade { get; set; }
        public required decimal Preco { get; set; }
    }
}
