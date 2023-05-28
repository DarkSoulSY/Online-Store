using DataAccessLayer.Repositories.BaseRepo;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.OrderRepo
{
    public interface IOrderRepository : IRepositoryBase<OrderRepository>
    {
        Task<List<OrderRepository>> GetAllOrders();
        Task<OrderRepository?> GetSingleOrder(Expression<Func<OrderRepository, bool>> expression);
        void CreateOrder(OrderRepository order);
        void UpdateOrder(OrderRepository order);
        void DeleteOrder(OrderRepository order);
    }
}
