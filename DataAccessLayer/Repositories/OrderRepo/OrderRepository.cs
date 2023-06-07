using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.OrderRepo
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext) { }
        
        public void CreateOrder(Order order)
        {
            Create(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Order?> GetSingleOrder(Expression<Func<Order, bool>> expression)
        {
            return await FindByCondition(expression).Include(O => O.Status).SingleOrDefaultAsync();
        }

        public void UpdateOrder(Order order)
        {
            Update(order);
        }
    }
}
