using comaagora.Models;

namespace comaagora.DTO
{
    public class ProdutoDTO
    {
        public required int Id { get; set; }
        public required string Nome { get; set; } = "";
        public required string Descricao { get; set; } = "";
        public required string ImgUrl { get; set; } = "";
        public required decimal Preco { get; set; } = 0;
        public required string Categoria { get; set; } = "";
        public required string Status { get; set; } = "";
        public required string estabelecimento { get; set; } = "";
    }
}