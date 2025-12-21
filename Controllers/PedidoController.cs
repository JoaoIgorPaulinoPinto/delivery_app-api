using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using comaagora.Services;
using comaagora.Services.Pedido;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;
    public PedidoController (IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }
    [HttpPost]
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

    [HttpGet]
    public async Task<IActionResult> GetByClientKey([FromHeader] string clientKey, [FromHeader] int estabelecimentoId)
    {
        try
        {
            return Ok(await _pedidoService.GetPedidosByClientKey(clientKey, estabelecimentoId));
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
