namespace JogosOnline.Api.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<Produto>? Produtos { get; set; }
        public DateTime DataDoPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; } = "Pendente";
    }
}
