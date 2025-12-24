using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models
{
    public class ProdutoPedido : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EstabelecimentoId { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        [Range(1, 999, ErrorMessage = "Quantidade deve ser pelo menos 1.")]
        public int Quantidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoUnitario { get; set; }
        // Captura o preço do produto no momento do pedido

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }
        // Quantidade * PrecoUnitario

        [ForeignKey(nameof(ProdutoId))]
        public Produto Produto { get; set; } = null!;

        [ForeignKey(nameof(PedidoId))]
        public Pedido Pedido { get; set; } = null!;
    }
}
