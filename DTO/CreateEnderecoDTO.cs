namespace comaagora.DTO
{
    public class EnderecoCreateDTO
    {
        public int? CEP { get; set; }
        public string? UF { get; set; }
        public string? Cidade { get; set; }
        public string? Rua { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Complemento { get; set; }
    }
}
