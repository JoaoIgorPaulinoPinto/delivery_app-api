using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models
{
    public class ProdutoCategoria : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int EstabelecimentoId { get; set; }

        [ForeignKey(nameof(EstabelecimentoId))]
        public Estabelecimento Estabelecimento { get; set; } = null!;

        [ForeignKey(nameof(StatusId))]
        public Status Status { get; set; } = null!;

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    }
}
