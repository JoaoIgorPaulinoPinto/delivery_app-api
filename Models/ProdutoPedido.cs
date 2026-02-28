using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class ProdutoPedido
{
    public int Id { get; set; }

    public int EstabelecimentoId { get; set; }

    public int PedidoId { get; set; }

    public int ProdutoId { get; set; }

    public int Quantidade { get; set; }

    public decimal PrecoUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;

    public virtual Pedido Pedido { get; set; } = null!;

    public virtual Produto Produto { get; set; } = null!;
}
