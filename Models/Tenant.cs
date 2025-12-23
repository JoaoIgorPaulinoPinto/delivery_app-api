using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace comaagora.Models
{
    public class Tenant : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Plano { get; set; } = "free"; 
        // Exemplo: "free", "pro", "enterprise"

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "ativo"; 
        // Exemplo: "ativo", "suspenso", "cancelado"

        public ICollection<Estabelecimento> Estabelecimentos { get; set; } = new List<Estabelecimento>();
    }
}
