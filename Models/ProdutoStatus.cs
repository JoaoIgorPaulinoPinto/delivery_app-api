using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class ProdutoStatus
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int StatusId { get; set; }

    public int EstabelecimentoId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    public virtual Status Status { get; set; } = null!;
}
