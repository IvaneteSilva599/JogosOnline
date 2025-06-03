using System.Text.Json.Serialization;

namespace JogosOnline.Api.Dtos
{
    public class PedidoEmbalagemRequestDto
    {
        [JsonPropertyName("pedido_id")]
        public string PedidoId { get; set; } = string.Empty;

        [JsonPropertyName("produtos")]
        public List<ProdutoEmbalagemRequestDto> Produtos { get; set; } = new();
    }
}
