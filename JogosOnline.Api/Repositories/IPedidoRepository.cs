using JogosOnline.Api.Models;

namespace JogosOnline.Api.Repositories
{
    public interface IPedidoRepository
    {
        Task<IList<Pedido>> GetAllAsync();
        Task AddAsync(Pedido pedido);
        Task<Pedido?> GetByIdAsync(int id);
        Task UpdateAsync(Pedido pedido);
        Task DeleteAsync(int id);
    }
}
