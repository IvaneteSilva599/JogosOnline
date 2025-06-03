using JogosOnline.Api.Dtos;
using JogosOnline.Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace JogosOnline.Api.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<PedidoCrudDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAllAsync();
            var pedidosDto = pedidos.Select(p => p.ToPedidoCrudDto()).ToList();
            return Ok(pedidosDto);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidoCrudDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido.ToPedidoCrudDto());
        }



        [HttpPost]
        [ProducesResponseType(typeof(PedidoCrudDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] PedidoCrudDto pedidoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedido = pedidoDto.ToPedido();
            await _pedidoService.AddAsync(pedido);

            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido.ToPedidoCrudDto());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] PedidoCrudDto pedidoDto)
        {
            if (id != pedidoDto.Id)
            {
                return BadRequest("ID do pedido na URL não corresponde ao ID no corpo da requisição.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPedido = await _pedidoService.GetByIdAsync(id);
            if (existingPedido == null)
            {
                return NotFound();
            }

            existingPedido.Produtos = pedidoDto.Produtos?.Select(p => p.ToProduto()).ToList();

            await _pedidoService.UpdateAsync(existingPedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            await _pedidoService.DeleteAsync(id);

            return NoContent();
        }
    }
}