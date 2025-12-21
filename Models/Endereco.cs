using comaagora.Models.Base;

namespace comaagora.Models
{
    public class Endereco: BaseEntity
    {
        public int Id { get; set; }
        public int Tipo { get; set; } 
        public required int CEP { get; set;}
        public required string UF {get; set;}
        public required string Cidade {get; set;}
        public required string Rua {get; set;}
        public required int Numero {get; set;}
        public required string Bairro {get; set;}
        public required string Complemento {get; set;}
        public int? EstabelecimentoId {get; set;}
        public Estabelecimento? Estabelecimento { get; set; } = null!;

    }
}
