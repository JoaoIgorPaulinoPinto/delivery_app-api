namespace comaagora.Models
{
    public class PedidoStatus
    {
        public int Id { get; set; }
        public string? situacao { get; set; } = "Em processamento";
        public ICollection<Pedido> Peiddos { get; set; } = new List<Pedido>();
    }
}
