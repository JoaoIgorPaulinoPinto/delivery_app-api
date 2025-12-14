using comaagora.Models.Base;

namespace comaagora.Models
{
    public class EstabelecimentoStatus : BaseEntity
    {
        public int Id { get; set; }
        public required string Nome { get; set; } = null!;

        public ICollection<Estabelecimento> Estabelecimentos { get; set; } = new List<Estabelecimento>();
    }

}
