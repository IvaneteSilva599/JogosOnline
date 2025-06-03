using JogosOnline.Api.Dtos;
using JogosOnline.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace JogosOnline.Api.Controllers
{
    [Route("api/embalagem/organizar")]
    [ApiController]
    public class EmbalagemController : ControllerBase
    {
        private readonly IEmbalagemService _embalagemService;

        public EmbalagemController(IEmbalagemService embalagemService)
        {
            _embalagemService = embalagemService;
        }

        [HttpPost("organizar")]
        [ProducesResponseType(typeof(PedidosEmbaladosResponseDto), 200)]
        [ProducesResponseType(400)]
        public IActionResult OrganizarPedidosParaEmbalagem([FromBody] PedidosEmbalagemRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var resultado = _embalagemService.EmbalarPedidos(request.Pedidos);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro interno ao processar a embalagem.", error = ex.Message });
            }
        }
    }
}
