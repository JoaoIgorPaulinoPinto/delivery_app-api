using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;
using comaagora.Services.Endereco;
using comaagora.Services.Pedido;

public class PedidoService : IPedidoService
{
    private readonly PedidoRepository _pedidoRepo;
    private readonly IUsuarioService _usuarioService;
    private readonly IEnderecoService _enderecoService;
    private readonly IProdutoPedidoService _produtoPedidoService;

    public PedidoService(
        PedidoRepository pedidoRepo,
        IUsuarioService usuarioService,
        IEnderecoService enderecoService,
        IProdutoPedidoService produtoPedidoService)
    {
        _pedidoRepo = pedidoRepo;
        _usuarioService = usuarioService;
        _enderecoService = enderecoService;
        _produtoPedidoService = produtoPedidoService;
    }

    public async Task<GetPedidoDTO> CreatePedido(
        string? clientKey,
        int estabelecimentoId,
        CreatePedidoDTO dto)
    {
        if (dto == null)
            throw new ArgumentException("Pedido inválido.");

        if (dto.Produtos == null || !dto.Produtos.Any())
            throw new ArgumentException("Pedido deve conter produtos.");

        var estabelecimento =
            await _pedidoRepo.GetEstabelecimentoByIdAsync(estabelecimentoId)
            ?? throw new KeyNotFoundException("Estabelecimento não encontrado.");

        var endereco = _enderecoService.CriarEndereco(dto.Endereco, estabelecimentoId);

        var usuario = await _usuarioService
            .ResolverUsuario(clientKey, estabelecimentoId, dto.Usuario);

        usuario.Endereco = endereco;

        var produtos = await _produtoPedidoService
            .CriarListaAsync(dto.Produtos, estabelecimentoId);

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
        if (pedido == null)
            throw new ArgumentNullException(nameof(pedido));

        return new GetPedidoDTO
        {
            Id = pedido.Id,

            Endereco = new GetEnderecoDTO
            {
                Bairro = pedido.Endereco.Bairro,
                Uf = pedido.Endereco.Uf,
                Cep = pedido.Endereco.Cep,
                Cidade = pedido.Endereco.Cidade,
                Rua = pedido.Endereco.Rua,
                Numero = pedido.Endereco.Numero,
                Complemento = pedido.Endereco.Complemento
            },

            Status = pedido.PedidoStatus?.Nome ?? "Desconhecido",
            MetodoPagamentoId = pedido.MetodoPagamentoId,

            Estabelecimento = new GetEstabelecimentoDTO
            {
                Id = pedido.Estabelecimento.Id,
                Slug = pedido.Estabelecimento.Slug,
                NomeFantasia = pedido.Estabelecimento.NomeFantasia,
                Telefone = pedido.Estabelecimento.Telefone,
                Email = pedido.Estabelecimento.Email,
                Whatsapp = pedido.Estabelecimento.Whatsapp,

                Endereco = new GetEnderecoDTO
                {
                    Bairro = pedido.Estabelecimento.Endereco.Bairro,
                    Uf = pedido.Estabelecimento.Endereco.Uf,
                    Cep = pedido.Estabelecimento.Endereco.Cep,
                    Cidade = pedido.Estabelecimento.Endereco.Cidade,
                    Rua = pedido.Estabelecimento.Endereco.Rua,
                    Numero = pedido.Estabelecimento.Endereco.Numero,
                    Complemento = pedido.Estabelecimento.Endereco.Complemento
                },

                TaxaEntrega = pedido.Estabelecimento.TaxaEntrega,
                PedidoMinimo = pedido.Estabelecimento.PedidoMinimo,
                Status = pedido.Estabelecimento.EstabelecimentoStatus?.Nome ?? "Desconhecido"
            },

            Usuario = new GetUsuarioDTO
            {
                ClientKey = pedido.Usuario.ClientKey,
                Nome = pedido.Usuario.Nome,
                Telefone = pedido.Usuario.Telefone
            },

            Produtos = pedido.Produtos?
                .Select(p => new GetProdutoPedidoDTO
                {
                    ProdutoId = p.ProdutoId,
                    Nome = p.Produto?.Nome ?? "Produto",
                    Preco = p.PrecoUnitario,
                    Quantidade = p.Quantidade,
                    Subtotal = p.Subtotal
                })
                .ToList() ?? new List<GetProdutoPedidoDTO>()
        };
    }
    public async Task<List<GetPedidoDTO>> GetPedidosByClientKey(
       string clientKey,
       int estabelecimentoId)
    {
        if (string.IsNullOrWhiteSpace(clientKey))
            throw new ArgumentException("ClientKey inválido.");

        clientKey = clientKey.Trim().ToLower();

        var pedidos = await _pedidoRepo
            .GetPedidosByClientKeyAsync(clientKey, estabelecimentoId);

        return pedidos
            .Select(MapToGetPedidoDTO)
            .ToList();
    }

}
