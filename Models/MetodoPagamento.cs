using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class MetodoPagamento
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public bool Ativo { get; set; }

    public int EstabelecimentoId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
