using comaagora.Models;

namespace comaagora.DTO
{
    public class GetProdutoPedidoDTO
    {
        // CORREÇÃO: Adicionando as propriedades que o Service tenta acessar
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string? ImgUrl { get; set; }
    }
}
