using System.Text.Json.Serialization;

namespace JogosOnline.Api.Dtos
{
    public class PedidosEmbaladosResponseDto
    {
        [JsonPropertyName("pedidos")]
        public List<PedidoEmbaladoResponseDto> Pedidos { get; set; } = new();
    }
}
