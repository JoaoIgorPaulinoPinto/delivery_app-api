using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class TipoEndereco
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public int Ativo { get; set; }

    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
}
