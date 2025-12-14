using comaagora.Models;

namespace comaagora.DTO
{
        public class CreatePedidoDTO
        {
            public List<CreateProdutoPedidoDTO> Produtos { get; set; } = new List<CreateProdutoPedidoDTO>();
            public EnderecoCreateDTO Endereco { get; set; } = new EnderecoCreateDTO();
            public string Observacao { get; set; } = "";
            public UsuarioCreateDTO  Usuario { get; set; } = new ();
        }
}
