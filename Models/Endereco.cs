using comaagora.Models.Base;

namespace comaagora.Models
{
    public class Endereco: BaseEntity
    {
        public int Id {  get; set; }
        public int? CEP { get; set;}
        public string? UF {get; set;}
        public string? Cidade {get; set;}
        public string? Rua {get; set;}
        public int? Numero {get; set;}
        public string? Bairro {get; set;}
        public string? Complemento {get; set;}
    }
}
