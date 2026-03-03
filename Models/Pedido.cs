using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int EstabelecimentoId { get; set; }

    public int PedidoStatusId { get; set; }

    public string Observacao { get; set; } = null!;

    [Column("SessionToken")]
    public string ClientKey { get; set; } = null!;

    public string NomeCliente { get; set; } = null!;

    public string TelefoneCliente{ get; set; } = null!;

    public int MetodoPagamentoId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;

    public virtual MetodoPagamento MetodoPagamento { get; set; } = null!;

    public virtual PedidoStatus PedidoStatus { get; set; } = null!;

    public virtual ICollection<ProdutoPedido> ProdutoPedidos { get; set; } = new List<ProdutoPedido>();
}
