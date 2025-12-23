using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string ClientKey { get; set; } = null!;
        // Pode ser token ou identificador único

        [Required]
        [Phone]
        [MaxLength(20)]
        public string Telefone { get; set; } = null!;

        [Required]
        public int EnderecoId { get; set; }

        [Required]
        public int EstabelecimentoId { get; set; }

        [ForeignKey(nameof(EstabelecimentoId))]
        public Estabelecimento Estabelecimento { get; set; } = null!;

        [ForeignKey(nameof(EnderecoId))]
        public Endereco Endereco { get; set; } = null!;

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        // Auditoria opcional
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
