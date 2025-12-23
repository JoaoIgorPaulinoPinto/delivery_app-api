using comaagora.Models;
using comaagora.Repositories;
using comaagora.DTO;
using comaagora.Services.Pedido;
public class PedidoService : IPedidoService
{
    private readonly PedidoRepository _pedidoRepo;
    private readonly UsuarioService _usuarioService;
    private readonly EnderecoService _enderecoService;
    private readonly ProdutoPedidoService _produtoPedidoService;

    public PedidoService(
        PedidoRepository pedidoRepo,
        UsuarioService usuarioService,
        EnderecoService enderecoService,
        ProdutoPedidoService produtoPedidoService)
    {
        _pedidoRepo = pedidoRepo;
        _usuarioService = usuarioService;
        _enderecoService = enderecoService;
        _produtoPedidoService = produtoPedidoService;
    }

    public async Task<GetPedidoDTO> CreatePedido(string? clientKey, int estabelecimentoId, CreatePedidoDTO dto)
    {
        if (dto == null || dto.Produtos == null || !dto.Produtos.Any())
            throw new ArgumentException("Pedido inválido.");

        var estabelecimento = await _pedidoRepo.GetEstabelecimentoByIdAsync(estabelecimentoId)
            ?? throw new KeyNotFoundException("Estabelecimento não encontrado.");

        var endereco = _enderecoService.CriarEndereco(dto.Endereco, estabelecimentoId);
        var usuario = await _usuarioService.ResolverUsuario(clientKey, estabelecimentoId, dto.Usuario);
        usuario.Endereco = endereco;
        var produtos = await _produtoPedidoService.CriarListaAsync(dto.Produtos, estabelecimentoId);

        var pedido = new Pedido
        {
            Usuario = usuario,
            Endereco = endereco,
            Estabelecimento = estabelecimento,
            MetodoPagamentoId = dto.MetodoPagamentoId,
            Observacao = dto.Observacao ?? "",
            PedidoStatusId = 1,
            Produtos = produtos
        };

        await _pedidoRepo.AddPedidoAsync(pedido);

        return MapToGetPedidoDTO(pedido);
    }

    private GetPedidoDTO MapToGetPedidoDTO(Pedido pedido)
    {
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
            Status = "Pendente",
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
                Status = pedido.Estabelecimento.EstabelecimentoStatus.Nome
            },
            Usuario = new GetUsuarioDTO
            {
                ClientKey = pedido.Usuario.ClientKey,
                Nome = pedido.Usuario.Nome,
                Telefone = pedido.Usuario.Telefone
            },
            Produtos = pedido.Produtos.Select(p => new GetProdutoPedidoDTO
            {
                ProdutoId = p.ProdutoId,
                Nome = p.Produto!.Nome,
                Preco = p.PrecoUnitario,
                Quantidade = p.Quantidade,
                Subtotal = p.Subtotal
            }).ToList()
        };
    }
    public async Task<List<GetPedidoDTO>> GetPedidosByClientKey(string clientKey, int estabelecimentoId)
    {
        if (string.IsNullOrWhiteSpace(clientKey))
            throw new ArgumentException("ClientKey inválido.", nameof(clientKey));

        clientKey = clientKey.Trim().ToLower();

        var pedidos = await _pedidoRepo.GetPedidosByClientKey(clientKey, estabelecimentoId);

        return pedidos.Select(p => new GetPedidoDTO
        {
            Id = p.Id,
            Endereco = new GetEnderecoDTO
            {
                Bairro = p.Endereco!.Bairro,
                Rua = p.Endereco.Rua,
                Cidade = p.Endereco.Cidade,
                Uf = p.Endereco.Uf,
                Cep = p.Endereco.Cep,
                Numero = p.Endereco.Numero,
                Complemento = p.Endereco.Complemento
            },
            Status = p.PedidoStatus.Nome,
            MetodoPagamentoId = p.MetodoPagamentoId,
            Estabelecimento = new GetEstabelecimentoDTO
            {
                Id = p.Estabelecimento!.Id,
                Slug = p.Estabelecimento.Slug,
                NomeFantasia = p.Estabelecimento.NomeFantasia,
                Telefone = p.Estabelecimento.Telefone,
                Email = p.Estabelecimento.Email,
                Whatsapp = p.Estabelecimento.Whatsapp,
                Endereco = new GetEnderecoDTO
                {
                    Bairro = p.Estabelecimento.Endereco.Bairro,
                    Rua = p.Estabelecimento.Endereco.Rua,
                    Cidade = p.Estabelecimento.Endereco.Cidade,
                    Uf = p.Estabelecimento.Endereco.Uf,
                    Cep = p.Estabelecimento.Endereco.Cep,
                    Numero = p.Estabelecimento.Endereco.Numero,
                    Complemento = p.Estabelecimento.Endereco.Complemento
                },
                TaxaEntrega = p.Estabelecimento.TaxaEntrega,
                PedidoMinimo = p.Estabelecimento.PedidoMinimo,
                Status = p.Estabelecimento.EstabelecimentoStatus.Nome
            },
            Usuario = new GetUsuarioDTO
            {
                Nome = p.Usuario!.Nome,
                Telefone = p.Usuario.Telefone,
                ClientKey = p.Usuario.ClientKey
            },
            Produtos = p.Produtos.Select(prod => new GetProdutoPedidoDTO
            {
                ProdutoId = prod.ProdutoId,
                Nome = prod.Produto!.Nome,
                Preco = prod.PrecoUnitario,
                Quantidade = prod.Quantidade,
                Subtotal = prod.Subtotal
            }).ToList()
        }).ToList();
    }

}
