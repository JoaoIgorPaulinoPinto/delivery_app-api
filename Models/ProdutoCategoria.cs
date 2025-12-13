using comaagora.Models.Base;

namespace comaagora.Models
{
    public class ProdutoCategoria : BaseEntity
    {

        public int Id{ get; set; }
        public string? nome { get; set; }
        public Status? status { get; set; }
        public int StatusId { get; set; }

        public int EstabelecimentoId { get; set; }
        public Estabelecimento? estabelecimento { get; set; }
        public ICollection<Estabelecimento> Estabelecimentos { get; set; }  = new List<Estabelecimento>();





    }
}
