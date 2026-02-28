using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class Tenant
{
    public int Id { get; set; }

    public int ContratanteId { get; set; }

    public string Plano { get; set; } = null!;

    public string Status { get; set; } = null!;

    public byte[]? ContratoAnexo { get; set; }

    public string? TipoArquivo { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Estabelecimento> Estabelecimentos { get; set; } = new List<Estabelecimento>();
}
