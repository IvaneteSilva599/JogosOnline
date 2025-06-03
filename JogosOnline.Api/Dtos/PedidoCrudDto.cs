namespace JogosOnline.Api.Dtos
{
    public class PedidoCrudDto
    {
        public int? Id { get; set; }
        public DateTime DataDoPedido { get; set; }
        public string Status { get; set; } = "Pendente";
        public List<ProdutoCrudDto> Produtos { get; set; } = new();
    }
}
