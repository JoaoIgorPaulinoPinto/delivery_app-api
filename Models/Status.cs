using comaagora.Models.Base;

namespace comaagora.Models
{
    public class Status : BaseEntity
    {
        public int Id { get; set; }
        public required string? nome  { get; set; } = "status"; 
        public required ICollection<ProdutoCategoria> Categorias  { get; set; } = new List<ProdutoCategoria>();
        public required ICollection<Produto> Produtos  { get; set; } = new List<Produto>();
    }
}
