using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;

namespace comaagora.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoRepository _pedidoRepo;
        private readonly UsuarioRepository _usuarioRepo;

        public PedidoService(
            UsuarioRepository usuarioRepository,
            PedidoRepository pedidoRepository)
        {
            _pedidoRepo = pedidoRepository;
            _usuarioRepo = usuarioRepository;
        }

        public async Task<GetPedidoDTO> CreatePedido(
            string? clientKey,
            int estabelecimentoId,
            CreatePedidoDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.Produtos == null || !dto.Produtos.Any())
                throw new ArgumentException("O pedido deve conter produtos.");

            clientKey = clientKey?.Trim().ToLower();

            var estabelecimento = await _pedidoRepo
                .GetEstabelecimentoByIdAsync(estabelecimentoId)
                ?? throw new KeyNotFoundException("Estabelecimento não encontrado.");

            // 🔹 Endereço (NÃO salvar ainda)
            var endereco = new Endereco
            {
                Rua = dto.Endereco.Rua,
                Numero = dto.Endereco.Numero,
                Bairro = dto.Endereco.Bairro,
                Cidade = dto.Endereco.Cidade,
                UF = dto.Endereco.UF,
                CEP = dto.Endereco.CEP,
                Complemento = dto.Endereco.Complemento,
            };

            // 🔹 Usuário
            var usuario = await ResolverUsuario(clientKey, estabelecimentoId, dto);

            usuario.Endereco = endereco; // 🔥 RELAÇÃO CORRETA

            // 🔹 Pedido (Aggregate Root)
            var pedido = new Models.Pedido
            {
                Usuario = usuario,
                Endereco = endereco,
                Estabelecimento = estabelecimento,
                MetodoPagamentoId = dto.MetodoPagamentoId,
                Observacao = dto.Observacao ?? "",
                Status = "Pendente",
                Produtos = new List<ProdutoPedido>()
            };

            // 🔹 Produtos
            foreach (var item in dto.Produtos)
            {
                var produto = await _pedidoRepo.GetProdutoByIdAsync(item.ProdutoId)
                    ?? throw new KeyNotFoundException($"Produto {item.ProdutoId} não encontrado.");

                pedido.Produtos.Add(new ProdutoPedido
                {
                    Produto = produto,
                    Quantidade = item.Quantidade,
                    EstabelecimentoId = estabelecimentoId
                });
            }

            // 🔥 SALVA TUDO EM UMA TRANSAÇÃO
            await _pedidoRepo.AddPedidoAsync(pedido);

            return ( new GetPedidoDTO
                    {
                        Endereco = new GetEnderecoDTO
                        {
                            Bairro = endereco.Bairro,
                            Uf = endereco.UF,
                            Cep = endereco.CEP,
                            Cidade = endereco.Cidade,
                            Rua = endereco.Rua,
                        },
                        Estabelecimento = new GetEstabelecimentoDTO
                        {
                            Id = estabelecimento.Id,
                            slug = estabelecimento.slug,
                            NomeFantasia = estabelecimento.NomeFantasia,
                            Telefone = estabelecimento.Telefone,
                            Email = estabelecimento.Email,
                            Whatsapp = estabelecimento.Whatsapp,
                            Endereco = estabelecimento.Endereco,
                            Abertura = estabelecimento.Abertura,
                            Fechamento = estabelecimento.Fechamento,
                            TaxaEntrega = estabelecimento.TaxaEntrega,
                            PedidoMinimo = estabelecimento.PedidoMinimo,
                            Status = (EstabelecimentoStatus)estabelecimento.Status
                        },
                        usuario = new GetUsuarioDTO { nome = usuario.Nome, telefone = usuario.Telefone },

                        // Aqui mapeamos cada produto do pedido para DTO
                        produtos = pedido.Produtos.Select(p => new GetProdutoPedidoDTO
                        {
                            ProdutoId = p.ProdutoId,
                            Nome = p.Produto!.Nome,
                            Preco = p.Produto.Preco,
                            Quantidade = p.Quantidade
                        }).ToList()
                    }
            );
        }


        private async Task<Usuario> ResolverUsuario(
            string? clientKey,
            int estId,
            CreatePedidoDTO dto)
        {
            Usuario? usuario = null;

            if (!string.IsNullOrEmpty(clientKey))
            {
                usuario = await _usuarioRepo.GetByClientKey(clientKey, estId);
            }

            if (usuario != null)
                return usuario;

            return new Usuario
            {
                Nome = dto.Usuario.Nome,
                Telefone = dto.Usuario.Telefone,
                EstabelecimentoId = estId,
                clientKey = string.IsNullOrEmpty(clientKey)
                    ? Guid.NewGuid().ToString("N")
                    : clientKey
            };
        }

    public async Task<List<GetPedidoDTO>> GetPedidosByClientKey(string clientKey, int estabelecimentoId)
        {
            if (string.IsNullOrWhiteSpace(clientKey))
                throw new ArgumentException("ClientKey inválido.", nameof(clientKey));

            clientKey = clientKey.Trim().ToLower();

            // 🔹 Busca todos os pedidos do cliente
            var pedidos = await _pedidoRepo.GetPedidosByClientKey(clientKey, estabelecimentoId);

            // 🔹 Mapeia cada pedido para DTO
            var pedidosDTO = pedidos.Select(p => new GetPedidoDTO
            {
                Endereco = new GetEnderecoDTO
                {
                    Bairro = p.Endereco!.Bairro,
                    Rua = p.Endereco.Rua,
                    Cidade = p.Endereco.Cidade,
                    Uf = p.Endereco.UF,
                    Cep = p.Endereco.CEP
                },
                Estabelecimento = new GetEstabelecimentoDTO
                {
                    Id = p.Estabelecimento!.Id,
                    slug = p.Estabelecimento.slug,
                    NomeFantasia = p.Estabelecimento.NomeFantasia,
                    Telefone = p.Estabelecimento.Telefone,
                    Email = p.Estabelecimento.Email,
                    Whatsapp = p.Estabelecimento.Whatsapp,
                    Endereco = p.Estabelecimento.Endereco,
                    Abertura = p.Estabelecimento.Abertura,
                    Fechamento = p.Estabelecimento.Fechamento,
                    TaxaEntrega = p.Estabelecimento.TaxaEntrega,
                    PedidoMinimo = p.Estabelecimento.PedidoMinimo,
                    Status = (EstabelecimentoStatus)p.Estabelecimento.Status
                },
                usuario = new GetUsuarioDTO
                {
                    nome = p.Usuario!.Nome,
                    telefone = p.Usuario.Telefone
                },
                produtos = p.Produtos.Select(prod => new GetProdutoPedidoDTO
                {
                    ProdutoId = prod.ProdutoId,
                    Nome = prod.Produto!.Nome,
                    Preco = prod.Produto.Preco,
                    Quantidade = prod.Quantidade
                }).ToList()
            }).ToList();

            return pedidosDTO;
        }
    } 
}
