namespace comaagora.DTO
{
    public class GetEnderecoDTO
    {
        public int Id { get; set; }
        public string? Rua { get; set; }
        public int Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Cep { get; set; }
    }
}
