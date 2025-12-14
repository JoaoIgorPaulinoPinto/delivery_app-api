namespace comaagora.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Telefone { get; set; }
        public required int EnderecoId { get; set; }
        public required int EstabelecimentoId { get; set; }
        public required string clientKey { get; set; }
        public  Estabelecimento? Estabelecimento { get; set; }
        public  Endereco? Endereco { get; set; }
    }
}
