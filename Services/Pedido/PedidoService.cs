using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;
using comaagora.Services.Endereco;
using comaagora.Services.Estabelecimento;
using comaagora.Services.Pedido;

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

    public async Task<GetPedidoDTO> CreatePedido(
        string? clientKey,
        string slug,
        CreatePedidoDTO dto)
    {
        if (dto == null)
            throw new ArgumentException("Pedido inválido.");

        if (dto.Produtos == null || !dto.Produtos.Any())
            throw new ArgumentException("Pedido deve conter produtos.");

        var estabelecimento =
            await _estService.GetBySlug(slug)
            ?? throw new KeyNotFoundException("Estabelecimento não encontrado.");

        var endereco = _enderecoService.CriarEndereco(dto.Endereco, slug);

        var usuario = await _usuarioService
            .ResolverUsuario(clientKey, estabelecimento.Id, dto.Usuario);

        usuario.Endereco = endereco;

        var produtos = await _produtoPedidoService
            .CriarListaAsync(dto.Produtos, estabelecimento.Id);

        var pedido = new Pedido
        {
            Usuario = usuario,
            Endereco = endereco,
            EstabelecimentoId = estabelecimento.Id,
            MetodoPagamentoId = dto.MetodoPagamentoId,
            Observacao = dto.Observacao ?? string.Empty,
            PedidoStatusId = 1,
            Produtos = produtos
        };

        await _pedidoRepo.AddPedidoAsync(pedido);

        // 🔥 PARTE CRÍTICA: recarregar pedido completo
        var pedidoCompleto =
            await _pedidoRepo.GetPedidoCompletoByIdAsync(pedido.Id)
            ?? throw new Exception("Erro ao carregar pedido.");

        return MapToGetPedidoDTO(pedidoCompleto);
    }

    private static GetPedidoDTO MapToGetPedidoDTO(Pedido pedido)
    {
        // O throw garante que 'pedido' não é nulo para o restante do método
        if (pedido == null) throw new ArgumentNullException(nameof(pedido));

        return new GetPedidoDTO
        {
            Id = pedido.Id,

            // Usamos uma nova instância se o endereço for nulo para evitar o erro
            Endereco = pedido.Endereco == null ? new GetEnderecoDTO() : new GetEnderecoDTO
            {
                Bairro = pedido.Endereco.Bairro ?? "",
                Uf = pedido.Endereco.Uf ?? "",
                Cep = pedido.Endereco.Cep ?? "",
                Cidade = pedido.Endereco.Cidade ?? "",
                Rua = pedido.Endereco.Rua ?? "",
                Numero = pedido.Endereco.Numero ?? "",
                Complemento = pedido.Endereco.Complemento ?? ""
            },

            Status = new PedidoStatusDTO
            {
                id = pedido.PedidoStatus?.Id ?? 0,
                nome = pedido.PedidoStatus?.Nome ?? "Pendente"
            },

            MetodoPagamentoId = pedido.MetodoPagamentoId,
            Observacao = pedido.Observacao ?? "",

            Estabelecimento = pedido.Estabelecimento == null ? new GetEstabelecimentoDTO() : new GetEstabelecimentoDTO
            {
                Id = pedido.Estabelecimento.Id,
                Slug = pedido.Estabelecimento.Slug ?? "",
                NomeFantasia = pedido.Estabelecimento.NomeFantasia ?? "",

                // Verificação em cascata: pedido -> estabelecimento -> endereco
                Endereco = new GetEnderecoDTO
                {
                    Bairro = pedido.Estabelecimento.Endereco?.Bairro ?? "",
                    Cidade = pedido.Estabelecimento.Endereco?.Cidade ?? ""
                    // ... repita para os demais campos
                },

                Status = pedido.Estabelecimento.EstabelecimentoStatus?.Nome ?? "Inativo"
            },

            Usuario = new GetUsuarioDTO
            {
                ClientKey = pedido.Usuario?.ClientKey ?? "",
                Nome = pedido.Usuario?.Nome ?? "Usuário Desconhecido",
                Telefone = pedido.Usuario?.Telefone ?? ""
            },

            Produtos = pedido.Produtos?.Select(p => new GetProdutoPedidoDTO
            {
                ProdutoId = p.ProdutoId,
                Nome = p.Produto?.Nome ?? "Produto Indisponível",
                Preco = p.PrecoUnitario,
                Quantidade = p.Quantidade,
                Subtotal = p.Subtotal
            }).ToList() ?? new List<GetProdutoPedidoDTO>()
        };
    }
    public async Task<List<GetPedidoDTO>> GetPedidosByClientKey(
       string clientKey,
       string slug)
    {
        if (string.IsNullOrWhiteSpace(clientKey))
            throw new ArgumentException("ClientKey inválido.");

        clientKey = clientKey.Trim().ToLower();

        var pedidos = await _pedidoRepo
            .GetPedidosByClientKeyAsync(clientKey, slug);

        return pedidos
            .Select(MapToGetPedidoDTO)
            .ToList();
    }
    public async Task<GetPedidoDTO> GetPedidoById(int id)
    {
        if (id < 0)
            throw new ArgumentException("id inválido.");

        var pedido = await _pedidoRepo
            .GetByIdAsync(id);
        
        if(pedido != null)
        {
            return MapToGetPedidoDTO(pedido);
        }
        else
        {
            throw new ArgumentException("Pedido não encontrado");
        }
    }

    public async Task<List<GetPedidoDTO>> GetPedidos(string slug)
    {
        if (slug == "" || slug == null)
            throw new ArgumentException("Estabelecimento inválido.");

        var pedidos = await _pedidoRepo
            .GetPedidosByStablishmentId(slug);

        return pedidos
            .Select(MapToGetPedidoDTO)
            .ToList();
    }
    public async Task<bool> UpdatePedido(UpdatePedidoDTO dto, int id)
    {
        // 1. Busca o pedido completo no banco
        Pedido? ap = await _pedidoRepo.GetByIdAsync(id);

        if (ap == null) return false;

        ap.Usuario.Nome = dto.Nome;
        ap.Usuario.Telefone = dto.Telefone;
        ap.Observacao = dto.Observacao!;
        ap.MetodoPagamentoId = dto.MetodoPagamentoId;

        ap.PedidoStatusId = dto.PedidoStatus.id;


        if (dto.Produtos != null)
        {
            foreach (var prodDto in dto.Produtos)
            {
                var itemExistente = ap.Produtos.FirstOrDefault(p => p.Id == prodDto.ProdutoId);
                if (itemExistente != null)
                {
                    itemExistente.Quantidade = prodDto.Quantidade;
                }
            }
        }

        // 5. Envia o objeto 'ap' (que agora está com os dados novos) para o repositório
        return await _pedidoRepo.UpdatePedido(dto, id);
    }
}
