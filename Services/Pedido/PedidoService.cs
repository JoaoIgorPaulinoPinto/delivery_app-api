using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;
using comaagora.Services.Endereco;
using comaagora.Services.Estabelecimento;
using comaagora.Services.ProdutoPedido;
using comaagora.Services.Usuario;

namespace comaagora.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoRepository _pedidoRepo;
        private readonly IUsuarioService _usuarioService;
        private readonly IEstabelecimentoService _estService;
        private readonly IEnderecoService _enderecoService;
        private readonly IProdutoPedidoService _produtoPedidoService;

        public PedidoService(
            PedidoRepository pedidoRepo,
            IEstabelecimentoService estabelecimentoService,
            IUsuarioService usuarioService,
            IEnderecoService enderecoService,
            IProdutoPedidoService produtoPedidoService)
        {
            _estService = estabelecimentoService;
            _pedidoRepo = pedidoRepo;
            _usuarioService = usuarioService;
            _enderecoService = enderecoService;
            _produtoPedidoService = produtoPedidoService;
        }

        public async Task<GetPedidoDTO> CreatePedido(string? clientKey, string slug, CreatePedidoDTO dto)
        {
            if (dto.Produtos == null || dto.Produtos.Count == 0)
            {
                throw new ArgumentException("Pedido deve conter pelo menos um produto.");
            }

            var estabelecimento = await _estService.GetBySlug(slug)
                ?? throw new KeyNotFoundException("Estabelecimento nao encontrado.");

            var endereco = _enderecoService.CriarEndereco(dto.Endereco);
            var usuario = await _usuarioService.ResolverUsuario(clientKey, estabelecimento.Id, dto.Usuario);
            usuario.Endereco = endereco;

            var produtos = await _produtoPedidoService.CriarListaAsync(dto.Produtos, estabelecimento.Id);

            var pedido = new Models.Pedido
            {
                Usuario = usuario,
                Endereco = endereco,
                EstabelecimentoId = estabelecimento.Id,
                MetodoPagamentoId = dto.MetodoPagamentoId,
                Observacao = dto.Observacao?.Trim() ?? string.Empty,
                PedidoStatusId = 1,
                ProdutoPedidos = produtos
            };

            await _pedidoRepo.AddPedidoAsync(pedido);

            var pedidoCompleto = await _pedidoRepo.GetPedidoCompletoByIdAsync(pedido.Id)
                ?? throw new KeyNotFoundException("Nao foi possivel carregar o pedido criado.");

            return MapToGetPedidoDTO(pedidoCompleto);
        }

        public async Task<List<GetPedidoDTO>> GetPedidosByClientKey(string clientKey, string slug)
        {
            if (string.IsNullOrWhiteSpace(clientKey))
            {
                throw new ArgumentException("Client key invalida.");
            }

            if (string.IsNullOrWhiteSpace(slug))
            {
                throw new ArgumentException("Slug do estabelecimento e obrigatorio.");
            }

            var pedidos = await _pedidoRepo.GetPedidosByClientKeyAsync(
                clientKey.Trim().ToLowerInvariant(),
                slug.Trim().ToLowerInvariant());

            return pedidos.Select(MapToGetPedidoDTO).ToList();
        }

        public async Task<GetPedidoDTO> GetPedidoById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do pedido invalido.");
            }

            var pedido = await _pedidoRepo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Pedido nao encontrado.");

            return MapToGetPedidoDTO(pedido);
        }

        public async Task<List<GetPedidoDTO>> GetPedidos(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                throw new ArgumentException("Slug do estabelecimento e obrigatorio.");
            }

            var pedidos = await _pedidoRepo.GetPedidosByStablishmentId(slug.Trim().ToLowerInvariant());
            return pedidos.Select(MapToGetPedidoDTO).ToList();
        }

        public async Task<bool> UpdatePedido(UpdatePedidoDTO dto, int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do pedido invalido.");
            }

            return await _pedidoRepo.UpdatePedido(dto, id);
        }

        public async Task<List<PedidoStatusDTO>> GetPedidoStatus(int estabelecimentoId)
        {
            if (estabelecimentoId <= 0)
            {
                throw new ArgumentException("Estabelecimento invalido.");
            }

            return await _pedidoRepo.GetPedidoStatus(estabelecimentoId);
        }

        private static GetPedidoDTO MapToGetPedidoDTO(Models.Pedido pedido)
        {
            return new GetPedidoDTO
            {
                Id = pedido.Id,
                Endereco = pedido.Endereco == null ? new GetEnderecoDTO() : new GetEnderecoDTO
                {
                    Bairro = pedido.Endereco.Bairro,
                    Uf = pedido.Endereco.UfId,
                    Cep = pedido.Endereco.Cep,
                    Cidade = pedido.Endereco.CidadeId,
                    Rua = pedido.Endereco.Rua,
                    Numero = pedido.Endereco.Numero,
                    Complemento = pedido.Endereco.Complemento
                },
                Status = new PedidoStatusDTO
                {
                    Id = pedido.PedidoStatus?.Id ?? 0,
                    Nome = pedido.PedidoStatus?.Nome ?? "Pendente"
                },
                MetodoPagamentoId = pedido.MetodoPagamentoId,
                Observacao = pedido.Observacao ?? string.Empty,
                Estabelecimento = pedido.Estabelecimento == null ? new GetEstabelecimentoDTO() : new GetEstabelecimentoDTO
                {
                    Id = pedido.Estabelecimento.Id,
                    Slug = pedido.Estabelecimento.Slug ?? string.Empty,
                    NomeFantasia = pedido.Estabelecimento.NomeFantasia ?? string.Empty,
                    Endereco = new GetEnderecoEstabelecimentoDTO
                    {
                        Bairro = pedido.Estabelecimento.Endereco?.Bairro ?? string.Empty,
                        Cidade = pedido.Estabelecimento.Endereco?.Cidade.Nome ?? "",
                        Uf = pedido.Estabelecimento.Endereco?.Uf.Uf?? "",
                        Rua = pedido.Estabelecimento.Endereco?.Rua ?? string.Empty,
                        Numero = pedido.Estabelecimento.Endereco?.Numero ?? string.Empty,
                        Cep = pedido.Estabelecimento.Endereco?.Cep ?? string.Empty,
                        Complemento = pedido.Estabelecimento.Endereco?.Complemento
                    },
                    Status = pedido.Estabelecimento.EstabelecimentoStatus?.Nome ?? "Inativo"
                },
                Usuario = new GetUsuarioDTO
                {
                    ClientKey = pedido.Usuario?.ClientKey ?? string.Empty,
                    Nome = pedido.Usuario?.Nome ?? "Usuario",
                    Telefone = pedido.Usuario?.Telefone ?? string.Empty
                },
                Produtos = pedido.ProdutoPedidos?.Select(p => new GetProdutoPedidoDTO
                {
                    ProdutoId = p.ProdutoId,
                    Nome = p.Produto?.Nome ?? "Produto",
                    Preco = p.PrecoUnitario,
                    Quantidade = p.Quantidade,
                    Subtotal = p.Subtotal
                }).ToList() ?? new List<GetProdutoPedidoDTO>()
            };
        }
    }
}
