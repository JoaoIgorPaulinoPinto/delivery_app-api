using comaagora.Models;

namespace comaagora.DTO
{
        public class PedidoCreateDTO
        {
            public List<ProdutoPedidoCreateDTO> Produtos { get; set; } = new List<ProdutoPedidoCreateDTO>();
            public EnderecoCreateDTO Endereco { get; set; } = new EnderecoCreateDTO();
            public string Observacao { get; set; } = "";
            public UsuarioCreateDTO  Usuario { get; set; } = new ();
            public int EstabelecimentoId { get; set; } = -1;
        }
}
