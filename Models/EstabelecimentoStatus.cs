using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class EstabelecimentoStatus
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Estabelecimento> Estabelecimentos { get; set; } = new List<Estabelecimento>();
}
