using comaagora.Models;
using System.Numerics;

namespace comaagora.DTO
{
    public class GetProdutoPedidoDTO
    {
        // CORREÇÃO: Adicionando as propriedades que o Service tenta acessar
        public int ProdutoId { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public required decimal Preco { get; set; } = decimal.Zero;
        public required int Quantidade { get; set; } = 0;
        public string? ImgUrl { get; set; } = string.Empty;
    }
}
