using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateProdutoPedidoDTO
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }

    public class GetProdutoPedidoDTO
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; } = "";
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
    }

}
