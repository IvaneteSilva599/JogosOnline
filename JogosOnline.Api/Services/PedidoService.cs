using JogosOnline.Api.Models;
using JogosOnline.Api.Repositories;
namespace JogosOnline.Api.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public Task<IList<Pedido>> GetAllAsync()
        {
            return _pedidoRepository.GetAllAsync();
        }

        public Task AddAsync(Pedido pedido)
        {
            return _pedidoRepository.AddAsync(pedido);
        }

        public Task<Pedido?> GetByIdAsync(int id)
        {
            return _pedidoRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Pedido pedido)
        {
            return _pedidoRepository.UpdateAsync(pedido);
        }

        public Task DeleteAsync(int id)
        {
            return _pedidoRepository.DeleteAsync(id);
        }
    }
}