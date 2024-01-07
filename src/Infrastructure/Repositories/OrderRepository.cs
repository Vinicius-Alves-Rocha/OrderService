using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<List<Order>> GetAsync()
        {
            using (OrderDbContext db = new())
            {
                return  await db.Order.ToListAsync();
            }
        }

        public async Task<Order> GetByIdAsync(Guid orderId)
        {
            using (OrderDbContext db = new())
            {
                return await db.Order.FirstOrDefaultAsync(o => o.OrderId == orderId);
            }
        }

        public async Task<int> InsertAsync(Order order)
        {
            using (OrderDbContext db = new())
            {
                await db.Order.AddAsync(order);
                return await db.SaveChangesAsync();
            }
        }
    }
}
