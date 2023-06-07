
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace Services.Services.OrderServices
{
    public interface IOrderService
    {
        Task<ServiceResponse<Order?>> CreateOrder(Order order);
        Task<ServiceResponse<bool?>> DeleteOrder(Order order);
        Task<ServiceResponse<Order?>> GetOrderByCondition(Expression<Func<Order, bool>> expressions);
        Task<ServiceResponse<List<Order>?>> GetAllOrders();
        Task<ServiceResponse<int>> UpdateOrder(Order order);
    }
}
