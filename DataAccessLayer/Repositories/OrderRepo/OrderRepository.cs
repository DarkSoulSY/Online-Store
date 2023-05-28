using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.OrderRepo
{
    public class OrderRepository : RepositoryBase<OrderRepository>, IOrderRepository
    {
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext) { }
        
        public void CreateOrder(OrderRepository order)
        {
            Create(order);
        }

        public void DeleteOrder(OrderRepository order)
        {
            Delete(order);
        }

        public async Task<List<OrderRepository>> GetAllOrders()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<OrderRepository?> GetSingleOrder(Expression<Func<OrderRepository, bool>> expression)
        {
            return await FindByCondition(expression).SingleOrDefaultAsync();
        }

        public void UpdateOrder(OrderRepository order)
        {
            Update(order);
        }
    }
}
