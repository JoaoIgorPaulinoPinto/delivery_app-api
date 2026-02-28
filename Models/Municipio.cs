using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class Municipio
{
    public int Id { get; set; }

    public int Codigo { get; set; }

    public string Nome { get; set; } = null!;

    public string Uf { get; set; } = null!;

    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
}
