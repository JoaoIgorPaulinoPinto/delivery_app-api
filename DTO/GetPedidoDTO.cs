using comaagora.Models;

namespace comaagora.DTO
{
    public class GetPedidoDTO
    {
        public int Id { get; set; }
        public string? Observacao { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MetodoPagamentoId { get; set; }
        public required GetEstabelecimentoDTO Estabelecimento { get; set; }
        public required GetEnderecoDTO Endereco { get; set; }
        public required GetUsuarioDTO usuario { get; set; }
        public Usuario? Usuario { get; }
        public required List<GetProdutoPedidoDTO> produtos { get; set; }
        public Pedido? Pedido { get; }
        public Estabelecimento? Estabelecimento1 { get; }
        public Endereco? Endereco1 { get; }
        public List<ProdutoPedido>? ProdutoPedidos { get; }
    }
}