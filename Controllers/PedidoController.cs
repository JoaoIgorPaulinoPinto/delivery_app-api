using comaagora.DTO;
using comaagora.Services.Pedido;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromHeader(Name = "clientKey")] string? clientKey,
            [FromQuery] string slug,
            [FromBody] CreatePedidoDTO dto)
        {
            try
            {
                var pedido = await _pedidoService.CreatePedido(clientKey, slug, dto);
                Response.Headers["clientKey"] = pedido.ClientKey;
                return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (DbUpdateException)
            {
                return BadRequest(new { error = "Falha ao persistir pedido. Verifique os dados informados." });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet("cliente")]
        public async Task<IActionResult> GetByClientKey(
            [FromHeader(Name = "clientKey")] string clientKey,
            [FromHeader(Name = "slug")] string slug)
        {
            try
            {
                return Ok(await _pedidoService.GetPedidosByClientKey(clientKey, slug));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _pedidoService.GetPedidoById(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpGet("estabelecimento")]
        public async Task<IActionResult> GetPedidos([FromHeader(Name = "slug")] string slug)
        {
            try
            {
                return Ok(await _pedidoService.GetPedidos(slug));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePedido(int id, [FromBody] UpdatePedidoDTO dto)
        {
            try
            {
                var sucesso = await _pedidoService.UpdatePedido(dto, id);
                return sucesso ? Ok(new { message = "Pedido atualizado com sucesso." }) : NotFound(new { message = "Pedido nao encontrado." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetPedidoStatus([FromHeader(Name = "estabelecimentoId")] int estabelecimentoId)
        {
            try
            {
                return Ok(await _pedidoService.GetPedidoStatus(estabelecimentoId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
