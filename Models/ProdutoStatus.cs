using System.ComponentModel.DataAnnotations;
using comaagora.Models.Base;

namespace comaagora.Models
{
    public class ProdutoStatus : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nome { get; set; } = null!;

        [Required]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; } = null!; // virtual ajuda no Lazy Loading

        public int EstabelecimentoId { get; set; }
        public virtual Estabelecimento? Estabelecimento { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
