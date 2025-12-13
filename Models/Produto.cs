using comaagora.Models.Base;

namespace comaagora.Models
{
    public class Produto : BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public decimal Preco { get; set; }

        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; } = null!;

        public int CategoriaId { get; set; }
        public ProdutoCategoria Categoria { get; set; } = null!;

        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;





    }
}
