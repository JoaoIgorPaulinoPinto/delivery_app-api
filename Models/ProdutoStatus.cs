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
        [Required]
        public Status Status { get; set; } = new();
   
        public int EstabelecimentoId { get; set; }
        public Estabelecimento? Estabelecimento { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }

}
