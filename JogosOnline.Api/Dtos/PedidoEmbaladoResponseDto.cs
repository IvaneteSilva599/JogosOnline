using System.Text.Json.Serialization;

namespace JogosOnline.Api.Dtos
{
    public class PedidoEmbaladoResponseDto
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }

        [JsonPropertyName("caixas")]
        public List<CaixaEmbaladaDto> Caixas { get; set; } = new();
    }
}
