namespace JogosOnline.Api.Dtos
{
    public class ProdutoCrudDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
    }
}
