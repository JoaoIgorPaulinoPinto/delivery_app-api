using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateEnderecoDTO
    {
        public string Rua { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string Cidade { get; set; } = "";
        public string Uf { get; set; } = "";
        public string Cep { get; set; } = "";
        public string? Complemento { get; set; }
    }

    public class GetEnderecoDTO
    {
        public string Rua { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string Cidade { get; set; } = "";
        public string Uf { get; set; } = "";
        public string Cep { get; set; } = "";
        public string? Complemento { get; set; }
    }

}
