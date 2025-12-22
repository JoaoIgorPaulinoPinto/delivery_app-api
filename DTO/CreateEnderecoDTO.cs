namespace comaagora.DTO
{
    public class EnderecoCreateDTO
    {
        public required int CEP { get; set; } 
        public required string UF { get; set; }
        public required string Cidade { get; set; }
        public required string Rua { get; set; }
        public required int Numero { get; set; }
        public required string Bairro { get; set; }
        public required string Complemento { get; set; }
    }
}
