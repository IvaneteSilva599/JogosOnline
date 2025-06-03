using JogosOnline.Api.Models;
using JogosOnline.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JogosOnline.Api.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoDbContext _context;

        public PedidoRepository(PedidoDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos.Include(p => p.Produtos).ToListAsync();
        }

        public async Task AddAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _context.Pedidos.Include(p => p.Produtos).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;

            foreach (var produto in pedido.Produtos ?? new List<Produto>())
            {
                if (produto.Id > 0)
                {
                    _context.Entry(produto).State = EntityState.Modified;
                }
                else
                {
                    _context.Entry(produto).State = EntityState.Added;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await GetByIdAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}