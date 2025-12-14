namespace comaagora.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public int? EnderecoId { get; set; }
        public int? EstabelecimentoId { get; set; }
        public string? clientKey { get; set; }

        public Estabelecimento? Estabelecimento { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
