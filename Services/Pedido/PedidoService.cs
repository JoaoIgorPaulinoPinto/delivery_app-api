using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;

namespace comaagora.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoRepository _pedidoRepo;
        private readonly UsuarioRepository _usuarioRepo;

        public PedidoService(UsuarioRepository usuarioRepository, PedidoRepository pedidoRepository)
        {
            _pedidoRepo = pedidoRepository;
            _usuarioRepo = usuarioRepository;
        }

        public async Task<GetPedidoDTO> CreatePedido(string? clientKey, int estabelecimentoId, CreatePedidoDTO dto)
        {
            // 1️⃣ Validações básicas
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.Produtos == null || !dto.Produtos.Any()) throw new ArgumentException("O pedido deve conter produtos.");

            clientKey = clientKey?.Trim().ToLower();

            // 2️⃣ Buscar Estabelecimento (com Taxa de Entrega)
            var estabelecimento = await _pedidoRepo.GetEstabelecimentoByIdAsync(estabelecimentoId)
                ?? throw new KeyNotFoundException("Estabelecimento não encontrado.");

            // 3️⃣ Criar Endereço primeiro
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
            await _pedidoRepo.AddEnderecoAsync(endereco); // aqui o Id é gerado

            // 4️⃣ Resolver usuário já com EnderecoId válido
            Usuario usuario = await ResolverUsuario(endereco, clientKey, estabelecimentoId, dto);


            // 5️⃣ Criar Pedido
            var pedido = new Models.Pedido
            {
                UsuarioId = usuario.Id,
                EstabelecimentoId = estabelecimentoId,
                MetodoPagamentoId = dto.MetodoPagamentoId,
                EnderecoId = endereco.Id,
                Observacao = dto.Observacao ?? "",
                Status = "Pendente",
            };
            await _pedidoRepo.AddPedidoAsync(pedido);

            // 6️⃣ Adicionar Produtos e Mapear Retorno
            var produtosPedido = await ProcessarProdutos(dto.Produtos, pedido, estabelecimentoId);
            await _pedidoRepo.AddProdutosPedidoAsync(produtosPedido);

            if (estabelecimento == null) throw new ArgumentNullException(nameof(dto));
            // 7️⃣ Retorno mapeado para o DTO completo
            return MapearParaDTO(pedido, estabelecimento, usuario, endereco, produtosPedido);
        }

        public async Task<List<GetPedidoDTO>> GetPedidosByClientKey(string clientKey, int estabelecimentoId)
        {
            if (string.IsNullOrWhiteSpace(clientKey)) throw new ArgumentException("clientKey inválida.");

            var pedidos = await _pedidoRepo.GetPedidosByClientKey(clientKey.Trim().ToLower(), estabelecimentoId);

            // Se a lista for nula, retorna lista vazia em vez de dar erro
            if (pedidos == null) return new List<GetPedidoDTO>();

            return pedidos
                .Select(p => MapearParaDTO(p, p.Estabelecimento, p.Usuario, p.Endereco, p.Produtos?.ToList() ?? new List<ProdutoPedido>()))
                .ToList();
        }
        private async Task<Usuario> ResolverUsuario(Endereco endereco, string? clientKey, int estId, CreatePedidoDTO dto)
        {
            Usuario? usuario = null;
            if (!string.IsNullOrEmpty(clientKey))
                usuario = await _usuarioRepo.GetByClientKey(clientKey, estId);

            if (usuario == null)
            {
                usuario = new Usuario
                {
                    Nome = dto.Usuario.Nome,
                    Telefone = dto.Usuario.Telefone,
                    EstabelecimentoId = estId,
                    clientKey = string.IsNullOrEmpty(clientKey) ? Guid.NewGuid().ToString("N") : clientKey,
                };
                await _pedidoRepo.AddUsuarioAsync(usuario);
            }
            return usuario;
        }

        private async Task<List<ProdutoPedido>> ProcessarProdutos(List<CreateProdutoPedidoDTO> itens, Models.Pedido pedido, int estId)
        {
            var lista = new List<ProdutoPedido>();
            foreach (var item in itens)
            {
                var produto = await _pedidoRepo.GetProdutoByIdAsync(item.ProdutoId)
                    ?? throw new KeyNotFoundException($"Produto {item.ProdutoId} não encontrado.");

                lista.Add(new ProdutoPedido
                {
                    PedidoId = pedido.Id,
                    ProdutoId = produto.Id,
                    Quantidade = item.Quantidade,
                    EstabelecimentoId = estId,
                    Produto = produto
                });
            }
            return lista;
        }
        private GetPedidoDTO MapearParaDTO(Models.Pedido p, Models.Estabelecimento? est, Usuario? u, Endereco? end, List<ProdutoPedido> prods)
        {
            // Validação de segurança: Se os objetos essenciais forem nulos, lançamos uma exceção clara ou tratamos
            if (est == null) throw new Exception($"Erro de integridade: Pedido {p.Id} sem estabelecimento carregado.");
            if (u == null) throw new Exception($"Erro de integridade: Pedido {p.Id} sem usuário carregado.");
            if (end == null) throw new Exception($"Erro de integridade: Pedido {p.Id} sem endereço carregado.");

            return new GetPedidoDTO
            {
                Id = p.Id,
                Observacao = p.Observacao ?? "",
                Status = p.Status ?? "Pendente",
                CreatedAt = p.CreatedAt,
                MetodoPagamentoId = p.MetodoPagamentoId,
                Estabelecimento = new GetEstabelecimentoDTO
                {
                    Id = est.Id,
                    slug = est.slug ?? "",
                    NomeFantasia = est.NomeFantasia ?? "Não informado",
                    Telefone = est.Telefone ?? "",
                    Email = est.Email ?? "",
                    Whatsapp = est.Whatsapp ?? "",
                    TaxaEntrega = est.TaxaEntrega,
                    PedidoMinimo = est.PedidoMinimo,
                    Abertura = est.Abertura,
                    Fechamento = est.Fechamento,
                },
                Endereco = new GetEnderecoDTO
                {
                    Rua = end.Rua ?? "",
                    Numero = end.Numero,
                    Bairro = end.Bairro ?? "",
                    Cidade = end.Cidade ?? "",
                    Uf = end.UF ?? "",
                    Cep = end.CEP != null ? end.CEP.ToString() : ""
                },
                usuario = new GetUsuarioDTO
                {
                    nome = u.Nome ?? "Cliente",
                    telefone = u.Telefone ?? "",
                    ClientKey = u.clientKey ?? ""
                },
                produtos = prods.Select(pp => new GetProdutoPedidoDTO
                {
                    ProdutoId = pp.ProdutoId,
                    Nome = pp.Produto?.Nome ?? "Produto Indisponível",
                    Preco = pp.Produto?.Preco ?? 0,
                    Quantidade = pp.Quantidade,
                    ImgUrl = pp.Produto?.ImgUrl ?? ""
                }).ToList()
            };
        }
    }
}