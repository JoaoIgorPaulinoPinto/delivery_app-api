using comaagora.Models.Base;

namespace comaagora.Models
{
    public class ProdutoCategoria : BaseEntity
    {

        public int Id{ get; set; }
        public required string? nome { get; set; }
        public required Status? status { get; set; }
        public required int StatusId { get; set; }
        public required int EstabelecimentoId { get; set; }
        public required Estabelecimento? estabelecimento { get; set; }
        public required ICollection<Estabelecimento> Estabelecimentos { get; set; }  = new List<Estabelecimento>();

    }
}
