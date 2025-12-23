using System.ComponentModel.DataAnnotations;
using comaagora.Models.Base;

namespace comaagora.Models
{
    public class PedidoStatus : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nome { get; set; } = null!;
        // Exemplo: "Pendente", "Preparando", "Entregue", "Cancelado"

        [Required]
        [MaxLength(20)]
        public string Codigo { get; set; } = null!;
        // Exemplo: "pendente", "preparando", "entregue", "cancelado"

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
