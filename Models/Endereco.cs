using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models;

public partial class Endereco
{
    public int Id { get; set; }

    public int Usuario { get; set; }

    [Column("Tipo")]
    public int TipoId { get; set; }

    public string Cep { get; set; } = null!;

    [Column("Uf")]
    public int UfId { get; set; }
    [Column("Cidade")]
    public int CidadeId { get; set; }

    public string Rua { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string? Complemento { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Municipio Cidade { get; set; } = null!;

    public virtual TipoEndereco Tipo { get; set; } = null!;

    public virtual Estado Uf { get; set; } = null!;

    public virtual ICollection<Estabelecimento> Estabelecimentos { get; set; } = new List<Estabelecimento>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public virtual Pedido? Pedido { get; set; }
}
