using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAsync();
        Task<Order> GetByIdAsync(Guid orderId);
        Task<int> InsertAsync(Order order);
    }
}
