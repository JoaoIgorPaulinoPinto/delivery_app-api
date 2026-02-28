using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class Estado
{
    public int Id { get; set; }

    public int CodigoUf { get; set; }

    public string Nome { get; set; } = null!;

    public string Uf { get; set; } = null!;

    public int Regiao { get; set; }

    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
}
