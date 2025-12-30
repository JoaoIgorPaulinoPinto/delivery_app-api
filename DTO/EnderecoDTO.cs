
using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateEnderecoDTO
    {
        [Required]
        public string Rua { get; set; } = "";
        [Required]
        public string Numero { get; set; } = "";
        [Required]
        public string Bairro { get; set; } = "";
        [Required]
        public string Cidade { get; set; } = "";
        [Required]
        public string Uf { get; set; } = "";
        [Required]
        public string Cep { get; set; } = "";
        public string? Complemento { get; set; }
    }

    public class GetEnderecoDTO
    {
        [Required]
        public string Rua { get; set; } = "";
        [Required]
        public string Numero { get; set; } = "";
        [Required]
        public string Bairro { get; set; } = "";
        [Required]
        public string Cidade { get; set; } = "";
        [Required]
        public string Uf { get; set; } = "";
        [Required] 
        public string Cep { get; set; } = "";
        public string? Complemento { get; set; }
    }

}
