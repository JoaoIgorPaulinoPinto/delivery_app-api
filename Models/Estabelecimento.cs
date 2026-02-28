using System;
using System.Collections.Generic;

namespace comaagora.Models;

public partial class Estabelecimento
{
    public int Id { get; set; }

    public string Slug { get; set; } = null!;

    public string NomeFantasia { get; set; } = null!;

    public string RazaoSocial { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Whatsapp { get; set; } = null!;

    public int EstabelecimentoStatusId { get; set; }

    public int TenantId { get; set; }

    public decimal TaxaEntrega { get; set; }

    public decimal PedidoMinimo { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<EstabelecimentoCategorium> EstabelecimentoCategoria { get; set; } = new List<EstabelecimentoCategorium>();

    public virtual Endereco Endereco { get; set; } = null!;

    public virtual EstabelecimentoStatus EstabelecimentoStatus { get; set; } = null!;

    public virtual ICollection<HorarioFuncionamento> HorarioFuncionamentos { get; set; } = new List<HorarioFuncionamento>();

    public virtual ICollection<MetodoPagamento> MetodoPagamentos { get; set; } = new List<MetodoPagamento>();

    public virtual ICollection<PedidoStatus> PedidoStatuses { get; set; } = new List<PedidoStatus>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<ProdutoCategoria> ProdutoCategoria { get; set; } = new List<ProdutoCategoria>();

    public virtual ICollection<ProdutoPedido> ProdutoPedidos { get; set; } = new List<ProdutoPedido>();

    public virtual ICollection<ProdutoStatus> ProdutoStatuses { get; set; } = new List<ProdutoStatus>();

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<UnidadeMedidum> UnidadeMedida { get; set; } = new List<UnidadeMedidum>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
