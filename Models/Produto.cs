using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string ImgUrl { get; set; } = null!;

    public decimal Preco { get; set; }

    public int UnidadeMedidaId { get; set; }

    public int EstabelecimentoId { get; set; }

    public int CategoriaId { get; set; }

    public int ProdutoStatusId { get; set; }

    [Column("Ativo?")]
    public int? Ativo{ get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ProdutoCategoria Categoria { get; set; } = null!;

    public virtual Estabelecimento Estabelecimento { get; set; } = null!;

    public virtual ICollection<ProdutoPedido> ProdutoPedidos { get; set; } = new List<ProdutoPedido>();

    public virtual ProdutoStatus ProdutoStatus { get; set; } = null!;

    public virtual UnidadeMedidum UnidadeMedida { get; set; } = null!;
}
