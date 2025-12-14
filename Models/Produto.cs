using comaagora.Models.Base;

namespace comaagora.Models
{
    public class Produto : BaseEntity
    {
        public int Id { get; set; }
        public required string Nome { get; set; } = null!;
        public required string Descricao { get; set; } = null!;
        public required string ImgUrl { get; set; } = null!;
        public required decimal Preco { get; set; }
        public required int EstabelecimentoId { get; set; }
        public required int CategoriaId { get; set; }
        public required int StatusId { get; set; }
        public  ProdutoCategoria? Categoria { get; set; } = null!;
        public  Status? Status { get; set; } = null!;
        public  Estabelecimento? Estabelecimento { get; set; } = null!;

    }
}
