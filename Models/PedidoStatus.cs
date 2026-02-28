using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class PedidoStatus
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int StatusId { get; set; }

    public int EstabelecimentoId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual Status Status { get; set; } = null!;
}
