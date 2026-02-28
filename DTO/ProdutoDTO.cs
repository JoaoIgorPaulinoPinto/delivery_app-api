using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateProdutoDTO
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), "0.01", "9999999")]
        public decimal Preco { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int StatusId { get; set; }

        [Required]
        [StringLength(500)]
        public string ImgUrl { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoriaId { get; set; }
    }

    public class GetProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public ProdutoStatusDTO? Status { get; set; }
        public decimal Preco { get; set; }
        public ProdutoCategoriaDTO Categoria { get; set; } = new();
    }

    public class ProdutoStatusDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }

    public class ProdutoCategoriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
