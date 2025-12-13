using comaagora.Models.Base;

namespace comaagora.Models
{
    public class Pedido : BaseEntity
    {
        public int Id { get; set; }
        public int EstabelecimentoId { get; set; }
        public int EnderecoId { get; set; }
        public string? Observacao { get; set; }
        public int UsuarioId { get; set; }


        public ICollection<ProdutoPedido> Produtos{ get; set; } = new List<ProdutoPedido>();
        public Estabelecimento? Estabelecimento { get; set; }
        public Endereco? Endereco { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
