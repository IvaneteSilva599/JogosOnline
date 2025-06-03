using System.Text.Json.Serialization;

namespace JogosOnline.Api.Dtos
{
    public class CaixaEmbaladaDto
    {
        [JsonPropertyName("caixa_id")]
        public string? CaixaId { get; set; }

        [JsonPropertyName("produtos")]
        public List<string>? Produtos { get; set; }

        [JsonPropertyName("observacao")]
        public string? Observacao { get; set; }
    }
}
