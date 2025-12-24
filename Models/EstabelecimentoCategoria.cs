using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models
{
    public class EstabelecimentoCategoria : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public Status Status { get; set; } = null!;

        [Required]
        public int EstabelecimentoId { get; set; }

        [ForeignKey(nameof(EstabelecimentoId))]
        public EnderecoEstabelecimento Estabelecimento { get; set; } = null!;
    }
}
