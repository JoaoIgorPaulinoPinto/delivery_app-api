using comaagora.Data;
using comaagora.DTO;
using comaagora.Services.Pedido;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;
    private readonly AppDbContext _context;
    public PedidoController (AppDbContext context,IPedidoService pedidoService)
    {
        _context = context;
        _pedidoService = pedidoService;
    }
    [HttpPost("Criar")]
    public async Task<IActionResult> Create(
        [FromHeader] int estabelecimentoId,
        [FromQuery] string? clientKey,
        [FromBody] CreatePedidoDTO dto)
    {
        if (dto == null || dto.Produtos == null || !dto.Produtos.Any())
            return BadRequest("Pedido inválido");
            return Ok(new
            {
                message = "Pedido criado com sucesso",
                pedido = await _pedidoService.CreatePedido(clientKey, estabelecimentoId, dto)
            });
    }

    [HttpGet("Cliente")]
    public async Task<IActionResult> GetByClientKey([FromHeader] string clientKey, [FromHeader] int estabelecimentoId)
    {
        try
        {
            return Ok(await _pedidoService.GetPedidosByClientKey(clientKey, estabelecimentoId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("Estabelecimento")]

    public async Task<IActionResult> GetPedidos([FromHeader] int estabelecimentoId)
    {
        try
        {
            return Ok(await _pedidoService.GetPedidos(estabelecimentoId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("Status")]
    public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdatePedidoStatus dto)
    {
        try
        {
            return Ok(await _pedidoService.UpdateOrderStatus(dto.pedidoId, dto.statusId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("Status")]
    public ActionResult GetPedidoStatus([FromHeader] int EstabelecimentoId)
    {
        return Ok(_context.PedidoStatus.AsNoTracking()
            .Where(e => e.EstabelecimentoId == EstabelecimentoId)
            .Select(c => new ProdutoCategoriaDTO
            {
                Id = c.Id,
                Nome = c.Nome ?? "",
            }).ToList());
    }
}
