using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models
{
    public class MetodoPagamento : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; } = null!;
        // Exemplo: "Cartão", "Pix", "Dinheiro"

        [Required]
        public bool Ativo { get; set; } = true;

        [Required]
        public int EstabelecimentoId { get; set; }

        [ForeignKey(nameof(EstabelecimentoId))]
        public Estabelecimento Estabelecimento { get; set; } = null!;

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
