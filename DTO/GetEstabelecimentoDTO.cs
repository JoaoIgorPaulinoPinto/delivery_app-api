using comaagora.Models;

namespace comaagora.DTO
{
    public class GetEstabelecimentoDTO
    {
        public int Id { get; set; }

        public required string slug { get; set; }

        // Identificação
        public required string NomeFantasia { get; set; } = null!;

        // Contato
        public required string Telefone { get; set; } = null!;
        public required string Email { get; set; }
        public required string Whatsapp { get; set; }

        // Endereço
        public Endereco Endereco { get; set; } = null!;

        // Funcionamento
        public TimeSpan Abertura { get; set; }
        public TimeSpan Fechamento { get; set; }

        // Financeiro
        public required decimal TaxaEntrega { get; set; }
        public required decimal PedidoMinimo { get; set; }

        // Status
        public EstabelecimentoStatus Status { get; set; } = null!;
    }
}
