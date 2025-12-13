using comaagora.Models.Base;

namespace comaagora.Models
{
    public class EstabelecimentoStatus : BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public ICollection<Estabelecimento> Estabelecimentos { get; set; } = new List<Estabelecimento>();
    }

}
