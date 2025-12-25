using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateProdutoDTO
    {
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public decimal Preco { get; set; }
        public int StatusId { get; set; }
        public string ImgUrl { get; set; } = "";
        public int CategoriaId { get; set; }
    }

    public class GetProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string ImgUrl { get; set; } = "";
        public ProdutoStatusDTO? Status { get; set; }
        public decimal Preco { get; set; }
        public ProdutoCategoriaDTO Categoria { get; set; } = new();
    }
    public class ProdutoStatusDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
    }
    public class ProdutoCategoriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
    }

}
