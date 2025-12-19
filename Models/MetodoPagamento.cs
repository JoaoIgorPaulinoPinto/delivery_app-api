using comaagora.Models.Base;

namespace comaagora.Models
{
    public class MetodoPagamento : BaseEntity
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int EstabelecimentoId { get; set; }
        public Estabelecimento? Estabelecimento { get; set; }
        public required ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    }
}
