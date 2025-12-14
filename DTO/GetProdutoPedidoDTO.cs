using comaagora.Models;

namespace comaagora.DTO
{
    public class GetProdutoPedidoDTO
    {
        public string? Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
