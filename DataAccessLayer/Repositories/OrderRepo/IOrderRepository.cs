using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.OrderRepo
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<List<Order>> GetAllOrders();
        Task<Order?> GetSingleOrder(Expression<Func<Order, bool>> expression);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
