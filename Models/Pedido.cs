using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int EstabelecimentoId { get; set; }

    public int PedidoStatusId { get; set; }

    public string Observacao { get; set; } = null!;

    public int UsuarioId { get; set; }

    public int MetodoPagamentoId { get; set; }

    public int EnderecoId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Endereco Endereco { get; set; } = null!;

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;

    public virtual MetodoPagamento MetodoPagamento { get; set; } = null!;

    public virtual PedidoStatus PedidoStatus { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<ProdutoPedido> ProdutoPedidos { get; set; } = new List<ProdutoPedido>();
}
