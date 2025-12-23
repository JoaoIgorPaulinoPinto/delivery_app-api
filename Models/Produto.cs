using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models
{
    public class Produto : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        [Url(ErrorMessage = "ImgUrl deve ser uma URL válida.")]
        public string ImgUrl { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 999999.99, ErrorMessage = "Preço deve ser maior que 0.")]
        public decimal Preco { get; set; }

        [Required]
        public int EstabelecimentoId { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public ProdutoCategoria Categoria { get; set; } = null!;

        [ForeignKey(nameof(StatusId))]
        public Status Status { get; set; } = null!;

        [ForeignKey(nameof(EstabelecimentoId))]
        public Estabelecimento Estabelecimento { get; set; } = null!;
    }
}
