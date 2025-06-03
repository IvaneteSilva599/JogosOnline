using JogosOnline.Api.Models;

public interface IPedidoService
{
    Task<IList<Pedido>> GetAllAsync();
    Task AddAsync(Pedido pedido);
    Task<Pedido?> GetByIdAsync(int id);
    Task UpdateAsync(Pedido pedido);
    Task DeleteAsync(int id);
}