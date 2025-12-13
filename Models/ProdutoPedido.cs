using comaagora.Models.Base;

namespace comaagora.Models
{
    public class ProdutoPedido : BaseEntity
    {
        public int Id {get;set;}
        public int EstabelecimentoId { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int quantidade { get; set; }

        public Produto? Produto { get; set; }
        public Pedido? Pedido { get; set; }
        public Estabelecimento? Estabelecimento { get; set; }
    }
}
