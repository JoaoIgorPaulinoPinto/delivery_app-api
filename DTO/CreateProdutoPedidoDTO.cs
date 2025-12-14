using comaagora.Models;

namespace comaagora.DTO
{
    public class CreateProdutoPedidoDTO
    {
        public required int ProdutoId { get; set; }
        public required int Quantidade { get; set; }
    }
}
