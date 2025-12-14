using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly AppDbContext _context;

    public PedidoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PedidoCreateDTO dto)
    {
        if (dto == null || dto.Produtos == null || !dto.Produtos.Any())
            return BadRequest("Pedido inválido");

        // 1️⃣ Criar endereço
        var endereco = new Endereco
        {
            Rua = dto.Endereco.Rua,
            Numero = dto.Endereco.Numero,
            Bairro = dto.Endereco.Bairro,
            Cidade = dto.Endereco.Cidade
        };

        _context.Enderecos.Add(endereco);
        await _context.SaveChangesAsync(); // gera Endereco.Id
        var Usuario = new Usuario
        {
            Nome = dto.Usuario.Nome,
            Telefone = dto.Usuario.Telefone,
            EnderecoId = endereco.Id,
            EstabelecimentoId = dto.EstabelecimentoId,
            clientKey = "client key"
        };
        _context.Usuarios.Add(Usuario);
        await _context.SaveChangesAsync();


        // 2️⃣ Criar pedido
        var pedido = new Pedido
        {
            UsuarioId = Usuario.Id,
            EstabelecimentoId = dto.EstabelecimentoId,
            EnderecoId = endereco.Id,
            Observacao = dto.Observacao,
        };

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync(); // gera Pedido.Id

        // 3️⃣ Criar itens do pedido
        foreach (var item in dto.Produtos)
        {
            var pedidoProduto = new ProdutoPedido
            {
                PedidoId = pedido.Id,
                ProdutoId = item.ProdutoId,
                Quantidade = item.Quantidade,
                EstabelecimentoId = dto.EstabelecimentoId,
            };

            _context.ProdutoPedidos.Add(pedidoProduto);
        }

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Pedido criado com sucesso",
            pedidoId = pedido.Id
        });
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromHeader] int estabelecimentoId)
    {
        return Ok( await _context.Pedidos
                  .AsNoTracking()
                  .Where(p => p.EstabelecimentoId == estabelecimentoId)
                  .Select(p => new GetPedidoDTO
                  {
                      EstabelecimentoId = p.EstabelecimentoId,
                      produtos = p.Produtos.ToList(),
                      usuario = p.Usuario
                  })
                  .ToListAsync());
    }
}
