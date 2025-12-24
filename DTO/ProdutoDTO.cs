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
        public string Status { get; set; } = "";
        public decimal Preco { get; set; }
        public string Categoria { get; set; } = "";
    }


}
