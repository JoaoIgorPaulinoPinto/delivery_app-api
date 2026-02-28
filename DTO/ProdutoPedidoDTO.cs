using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateProdutoPedidoDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProdutoId { get; set; }

        [Required]
        [Range(1, 999)]
        public int Quantidade { get; set; }
    }

    public class GetProdutoPedidoDTO
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
    }
}
