using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models
{
    public class Status : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; } = null!;
        // Exemplo: "Ativo", "Inativo", "Indisponível"

        [Required]
        [MaxLength(20)]
        public string Codigo { get; set; } = null!;
        // Exemplo: "ativo", "inativo", "indisponivel"

        [Required]
        public int EstabelecimentoId { get; set; }

        [ForeignKey(nameof(EstabelecimentoId))]
        public Estabelecimento Estabelecimento { get; set; } = null!;

        public ICollection<ProdutoCategoria> Categorias { get; set; } = new List<ProdutoCategoria>();
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
