namespace comaagora.DTO
{
    public class GetEnderecoDTO
    {
        public int Id { get; set; }
        public string? Rua { get; set; } = string.Empty;
        public int Numero { get; set; } =0 ;
        public string? Bairro { get; set; } = string.Empty;
        public string? Cidade { get; set; } = string.Empty;
        public string? Uf { get; set; } = string.Empty;
        public int? Cep { get; set; } = 0;
    }
}
