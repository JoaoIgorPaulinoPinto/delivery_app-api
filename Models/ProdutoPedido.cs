using comaagora.Models.Base;

namespace comaagora.Models
{
    public class ProdutoPedido : BaseEntity
    {
        public int Id {get;set;}
        public required int EstabelecimentoId { get; set; }
        public required int PedidoId { get; set; }
        public required int ProdutoId { get; set; }
        public required int Quantidade { get; set; }
        public required Produto Produto { get; set; }
        public required Pedido Pedido { get; set; } 
        public  Estabelecimento? Estabelecimento { get; set; }
    }
}
