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
        public int StatusId { get; set; }
        [Required]
        public Status Status { get; set; } = new();
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
