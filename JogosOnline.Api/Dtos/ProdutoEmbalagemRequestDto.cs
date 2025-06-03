using System.Text.Json.Serialization;

namespace JogosOnline.Api.Dtos
{
    public class ProdutoEmbalagemRequestDto
    {
        [JsonPropertyName("produto_id")]
        public string ProdutoId { get; set; } = string.Empty;

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = string.Empty;

        [JsonPropertyName("dimensoes")]
        public DimensoesDto Dimensoes { get; set; } = new DimensoesDto();
    }
}
