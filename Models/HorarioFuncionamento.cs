using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class HorarioFuncionamento
{
    public int Id { get; set; }

    public int EstabelecimentoId { get; set; }

    public string DiaSemana { get; set; } = null!;

    public TimeOnly Abertura { get; set; }

    public TimeOnly Fechamento { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;
}
