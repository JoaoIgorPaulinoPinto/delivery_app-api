using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public int EstabelecimentoId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;

    public virtual ICollection<EstabelecimentoCategorium> EstabelecimentoCategoria { get; set; } = new List<EstabelecimentoCategorium>();

    public virtual ICollection<PedidoStatus> PedidoStatuses { get; set; } = new List<PedidoStatus>();

    public virtual ICollection<ProdutoCategoria> ProdutoCategoria { get; set; } = new List<ProdutoCategoria>();

    public virtual ICollection<ProdutoStatus> ProdutoStatuses { get; set; } = new List<ProdutoStatus>();
}
