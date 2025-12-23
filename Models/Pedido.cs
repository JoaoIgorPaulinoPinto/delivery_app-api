using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models
{
    public class Pedido : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EstabelecimentoId { get; set; }

        [Required]
        public int EnderecoId { get; set; }

        [Required]
        public int PedidoStatusId { get; set; }

        [MaxLength(500)]
        public string Observacao { get; set; } = string.Empty;

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int MetodoPagamentoId { get; set; }

        [ForeignKey(nameof(EstabelecimentoId))]
        public Estabelecimento Estabelecimento { get; set; } = null!;

        [ForeignKey(nameof(EnderecoId))]
        public Endereco Endereco { get; set; } = null!;

        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; } = null!;

        [ForeignKey(nameof(PedidoStatusId))]
        public PedidoStatus PedidoStatus { get; set; } = null!;

        [ForeignKey(nameof(MetodoPagamentoId))]
        public MetodoPagamento MetodoPagamento { get; set; } = null!;

        public ICollection<ProdutoPedido> Produtos { get; set; } = new List<ProdutoPedido>();
    }
}
