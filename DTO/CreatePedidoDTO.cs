using comaagora.Models;

namespace comaagora.DTO
{
    public class CreatePedidoDTO
    {
        public string? ClientKey { get; set; }
        public required List<CreateProdutoPedidoDTO> Produtos { get; set; } 
        public EnderecoCreateDTO? Endereco { get; set; } 
        public required string Observacao { get; set; } = "";
        public required int MetodoPagamentoId { get; set; } = 0;
        public required UsuarioCreateDTO Usuario { get; set; }
    }
}
