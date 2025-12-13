using comaagora.Models;

namespace comaagora.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = "";
        public string? Descricao { get; set; } = "";
        public decimal? Preco { get; set; } = 0;
        public string? Categoria { get; set; } = "";
        public string? Status { get; set; } = "";
        public string? estabelecimento { get; set; } = "";
    }
}