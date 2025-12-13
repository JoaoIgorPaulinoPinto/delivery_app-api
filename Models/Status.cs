using comaagora.Models.Base;

namespace comaagora.Models
{
    public class Status : BaseEntity
    {
        public int Id { get; set; }
        public string? nome  { get; set; } = "status"; 
        public ICollection<ProdutoCategoria> Categorias  { get; set; } = new List<ProdutoCategoria>();
        public ICollection<Produto> Produtos  { get; set; } = new List<Produto>();
    }
}
