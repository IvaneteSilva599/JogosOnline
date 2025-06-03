using System.Text.Json.Serialization;

namespace JogosOnline.Api.Dtos
{
    public class PedidosEmbalagemRequestDto
    {
        [JsonPropertyName("pedidos")]
        public List<PedidoEmbalagemRequestDto> Pedidos { get; set; } = new();
    }
}
