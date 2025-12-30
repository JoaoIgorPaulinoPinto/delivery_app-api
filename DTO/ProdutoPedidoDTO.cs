using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateProdutoPedidoDTO
    {
        [Required] public int ProdutoId { get; set; }
        [Required] public int Quantidade { get; set; }
    }

    public class GetProdutoPedidoDTO
    {
        [Required] public int ProdutoId { get; set; }
        [Required] public string Nome { get; set; } = "";
        [Required] public decimal Preco { get; set; }
        [Required] public int Quantidade { get; set; }
        [Required] public decimal Subtotal { get; set; }
    }

}
