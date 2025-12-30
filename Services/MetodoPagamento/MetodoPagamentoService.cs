using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Services
{
    public class MetodoPagamentoService:IMetodoPagamentoService
    {
        private readonly IMetodoPagamentoService _metodoPagamentoService;
        private readonly MetodoPagamentoRepository _metodoPagamentoRepo;
        public MetodoPagamentoService(IMetodoPagamentoService MthPhmntSrvc, MetodoPagamentoRepository metodoPagamentoRepo)
        {
            _metodoPagamentoService = MthPhmntSrvc;
            _metodoPagamentoRepo = metodoPagamentoRepo;
        }
        public async Task<List<MetodoPagamentoDTO>> GetAll(int id)
        {
            return await _metodoPagamentoRepo.GetAll(id);
        }
    }
}
