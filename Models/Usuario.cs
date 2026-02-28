using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string ClientKey { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public int EnderecoId { get; set; }

    public int EstabelecimentoId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Endereco Endereco { get; set; } = null!;

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
