using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class UnidadeMedidum
{
    public int Id { get; set; }

    public string UnidadeMedida { get; set; } = null!;

    public int Ativo { get; set; }

    public int EstabelecimentoId { get; set; }

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
