using comaagora.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace comaagora.Services.MetodoPagamento
{
    public interface IMetodoPagamentoService
    {
        Task<List<MetodoPagamentoDTO>> GetAll(string slug);
    }
}
