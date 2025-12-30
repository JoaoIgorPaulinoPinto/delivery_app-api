using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateProdutoDTO
    {
       [Required]
        public string Nome { get; set; } = "";
       [Required]
        public string Descricao { get; set; } = "";
       [Required]
        public decimal Preco { get; set; }
       [Required]
        public int StatusId { get; set; }
       [Required]
        public string ImgUrl { get; set; } = "";
       [Required]
        public int CategoriaId { get; set; }
    }

    public class GetProdutoDTO
    {
       [Required] 
        public int Id { get; set; }
       [Required] 
        public string Nome { get; set; } = "";
       [Required] 
        public string Descricao { get; set; } = "";
       [Required] 
        public string ImgUrl { get; set; } = "";
       [Required] 
        public ProdutoStatusDTO? Status { get; set; }
       [Required] 
       public decimal Preco { get; set; }
       [Required]
       public ProdutoCategoriaDTO Categoria { get; set; } = new();
    }
    public class ProdutoStatusDTO
    {
        [Required] public int Id { get; set; }
        [Required] public string Nome { get; set; } = "";
    }
    public class ProdutoCategoriaDTO
    {
        [Required] public int Id { get; set; }
        [Required] public string Nome { get; set; } = "";
    }

}
