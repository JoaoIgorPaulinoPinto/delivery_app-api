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
        [FromBody] CreatePedidoDTO dto)
    {
        if (dto == null || dto.Produtos == null || !dto.Produtos.Any())
            return BadRequest("Pedido inválido");

        return Ok(new
        {
            message = "Pedido criado com sucesso",
            pedido = await _pedidoService.CreatePedido(estabelecimentoId,dto)
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id , [FromQuery] int estabelecimentoId)
    {
        try
        {
            return Ok(await _pedidoService.GetPedidoById(estabelecimentoId, id));
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
