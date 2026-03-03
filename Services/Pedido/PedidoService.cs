using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;
using comaagora.Services.Endereco;
using comaagora.Services.Estabelecimento;
using comaagora.Services.ProdutoPedido;

namespace comaagora.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoRepository _pedidoRepo;
        private readonly IEstabelecimentoService _estService;
        private readonly IEnderecoService _enderecoService;
        private readonly IProdutoPedidoService _produtoPedidoService;

        public PedidoService(
            PedidoRepository pedidoRepo,
            IEstabelecimentoService estabelecimentoService,
            IEnderecoService enderecoService,
            IProdutoPedidoService produtoPedidoService)
        {
            _estService = estabelecimentoService;
            _pedidoRepo = pedidoRepo;
            _enderecoService = enderecoService;
            _produtoPedidoService = produtoPedidoService;
        }

        public async Task<GetPedidoDTO> CreatePedido(string? clientKey, string slug, CreatePedidoDTO dto)
        {
            if (dto.Produtos == null || dto.Produtos.Count == 0)
            {
                throw new ArgumentException("Pedido deve conter pelo menos um produto.");
            }

            var normalizedClientKey = await ResolveClientKeyAsync(clientKey);

            var estabelecimento = await _estService.GetBySlug(slug)
                ?? throw new KeyNotFoundException("Estabelecimento nao encontrado.");

            var endereco = _enderecoService.CriarEndereco(dto.Endereco);
            var produtos = await _produtoPedidoService.CriarListaAsync(dto.Produtos, estabelecimento.Id);

            var pedido = new Models.Pedido
            {
                EstabelecimentoId = estabelecimento.Id,
                MetodoPagamentoId = dto.MetodoPagamentoId,
                Observacao = dto.Observacao?.Trim() ?? string.Empty,
                PedidoStatusId = 1,
                ProdutoPedidos = produtos,
                NomeCliente = dto.Usuario.Nome.Trim(),
                TelefoneCliente = dto.Usuario.Telefone.Trim(),
                ClientKey = normalizedClientKey
            };

            await _pedidoRepo.AddPedidoAsync(pedido);
            endereco.Usuario = pedido.Id;
            await _pedidoRepo.AddEnderecoAsync(endereco);

            var pedidoCompleto = await _pedidoRepo.GetPedidoCompletoByIdAsync(pedido.Id)
                ?? throw new KeyNotFoundException("Nao foi possivel carregar o pedido criado.");
            var enderecoEstabelecimento = await _enderecoService.GetByUsuarioIdAsync(pedidoCompleto.EstabelecimentoId);

            return MapToGetPedidoDTO(pedidoCompleto, endereco, enderecoEstabelecimento);
        }

        public async Task<List<GetPedidoDTO>> GetPedidosByClientKey(string clientKey, string slug)
        {
            var pedidos = await _pedidoRepo.GetPedidosByClientKeyAsync(
                clientKey.Trim().ToLowerInvariant(),
                slug.Trim().ToLowerInvariant());

            var enderecosPedidoPorUsuario = await _enderecoService.GetByUsuariosIdsAsync(pedidos.Select(p => p.Id));
            var enderecosEstabelecimentoPorUsuario = await _enderecoService.GetByUsuariosIdsAsync(pedidos.Select(p => p.EstabelecimentoId));

            var dtos = pedidos.Select(p =>
            {
                if (!enderecosPedidoPorUsuario.TryGetValue(p.Id, out var enderecoPedido) || enderecoPedido == null)
                {
                    throw new KeyNotFoundException($"Endereco nao encontrado para o pedido {p.Id}.");
                }

                enderecosEstabelecimentoPorUsuario.TryGetValue(p.EstabelecimentoId, out var enderecoEstabelecimento);
                return MapToGetPedidoDTO(p, enderecoPedido, enderecoEstabelecimento);
            });

            return dtos.ToList();
        }

        public async Task<GetPedidoDTO> GetPedidoById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do pedido invalido.");
            }

            var pedido = await _pedidoRepo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Pedido nao encontrado.");

            var endereco = await _enderecoService.GetByUsuarioIdAsync(pedido.Id);
            if (endereco == null)
            {
                throw new ArgumentException("Endereco nao pode ser encontrado.");
            }

            var enderecoEstabelecimento = await _enderecoService.GetByUsuarioIdAsync(pedido.EstabelecimentoId);

            return MapToGetPedidoDTO(pedido, endereco, enderecoEstabelecimento);
        }

        public async Task<List<GetPedidoDTO>> GetPedidos(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                throw new ArgumentException("Slug do estabelecimento e obrigatorio.");
            }

            var pedidos = await _pedidoRepo.GetPedidosByStablishmentId(slug.Trim().ToLowerInvariant());
            var enderecosPedidoPorUsuario = await _enderecoService.GetByUsuariosIdsAsync(pedidos.Select(p => p.Id));
            var enderecosEstabelecimentoPorUsuario = await _enderecoService.GetByUsuariosIdsAsync(pedidos.Select(p => p.EstabelecimentoId));

            var dtos = pedidos.Select(p =>
            {
                if (!enderecosPedidoPorUsuario.TryGetValue(p.Id, out var enderecoPedido) || enderecoPedido == null)
                {
                    throw new Exception($"Endereco nao encontrado para o pedido {p.Id}");
                }

                enderecosEstabelecimentoPorUsuario.TryGetValue(p.EstabelecimentoId, out var enderecoEstabelecimento);
                return MapToGetPedidoDTO(p, enderecoPedido, enderecoEstabelecimento);
            });

            return dtos.ToList();
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

        private async Task<string> ResolveClientKeyAsync(string? clientKey)
        {
            var normalized = clientKey?.Trim().ToLowerInvariant();
            if (!string.IsNullOrWhiteSpace(normalized))
            {
                return normalized;
            }

            for (var i = 0; i < 5; i++)
            {
                var generated = $"ck_{Guid.NewGuid():N}";
                var exists = await _pedidoRepo.ClientKeyExistsAsync(generated);
                if (!exists)
                {
                    return generated;
                }
            }

            throw new InvalidOperationException("Nao foi possivel gerar uma clientKey unica.");
        }

        private static GetPedidoDTO MapToGetPedidoDTO(
            Models.Pedido pedido,
            Models.Endereco enderecoPedido,
            Models.Endereco? enderecoEstabelecimento)
        {
            return new GetPedidoDTO
            {
                Id = pedido.Id,
                Endereco = enderecoPedido == null ? new GetEnderecoDTO() : new GetEnderecoDTO
                {
                    Bairro = enderecoPedido.Bairro,
                    Uf = enderecoPedido.UfId,
                    Cep = enderecoPedido.Cep,
                    Cidade = enderecoPedido.CidadeId,
                    Rua = enderecoPedido.Rua,
                    Numero = enderecoPedido.Numero,
                    Complemento = enderecoPedido.Complemento
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
                        Bairro = enderecoEstabelecimento?.Bairro ?? string.Empty,
                        Cidade = enderecoEstabelecimento?.Cidade?.Nome ?? string.Empty,
                        Uf = enderecoEstabelecimento?.Uf?.Uf ?? string.Empty,
                        Rua = enderecoEstabelecimento?.Rua ?? string.Empty,
                        Numero = enderecoEstabelecimento?.Numero ?? string.Empty,
                        Cep = enderecoEstabelecimento?.Cep ?? string.Empty,
                        Complemento = enderecoEstabelecimento?.Complemento
                    },
                    Status = pedido.Estabelecimento.EstabelecimentoStatus?.Nome ?? "Inativo"
                },
                ClientKey = pedido.ClientKey ?? string.Empty,
                Nome = pedido.NomeCliente ?? "Usuario",
                Telefone = pedido.TelefoneCliente ?? string.Empty,
                Produtos = pedido.ProdutoPedidos.Select(p => new GetProdutoPedidoDTO
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
