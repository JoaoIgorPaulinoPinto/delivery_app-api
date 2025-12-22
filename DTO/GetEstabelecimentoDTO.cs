using comaagora.Models;

namespace comaagora.DTO
{
    public class GetEstabelecimentoDTO
    {
        public int Id { get; set; }

        public  string slug { get; set; } = string.Empty;

        // Identificação
        public  string NomeFantasia { get; set; } = string.Empty;

        // Contato
        public  string Telefone { get; set; } = string.Empty;
        public  string Email { get; set; } = string.Empty;
        public  string Whatsapp { get; set; } = string.Empty;

        // Endereço
        public Endereco? Endereco { get; set; }

        // Funcionamento
        public TimeSpan Abertura { get; set; }
        public TimeSpan Fechamento { get; set; }

        // Financeiro
        public  decimal TaxaEntrega { get; set; }
        public  decimal PedidoMinimo { get; set; }

        // Status
        public EstabelecimentoStatus Status { get; set; } = null!;
    }
}
