using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models
{
    public class HorarioFuncionamento : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EstabelecimentoId { get; set; }

        [Required]
        [MaxLength(10)]
        public string DiaSemana { get; set; } = null!;
        // Exemplo: "segunda", "terça", "domingo"

        [Required]
        public TimeSpan Abertura { get; set; }

        [Required]
        public TimeSpan Fechamento { get; set; }

        [ForeignKey(nameof(EstabelecimentoId))]
        public Estabelecimento Estabelecimento { get; set; } = null!;
    }
}
