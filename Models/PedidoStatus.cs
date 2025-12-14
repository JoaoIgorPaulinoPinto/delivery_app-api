namespace comaagora.Models
{
    public class PedidoStatus
    {
        public int Id { get; set; }
        public required string situacao { get; set; }
        public ICollection<Pedido> Peiddos { get; set; } = new List<Pedido>();
    }
}
