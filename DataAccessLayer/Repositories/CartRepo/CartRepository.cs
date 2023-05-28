using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.CartRepo
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(ApplicationContext applicationContext): base(applicationContext)
        {
            
        }
        public void CreateCart(Cart cart)
        {
            Create(cart);
        }

        public void DeleteCart(Cart cart)
        {
            Delete(cart);
        }

        public async Task<List<Cart>> GetAllCarts()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Cart?> GetSingleCart(Expression<Func<Cart, bool>> expression)
        {
            return await FindByCondition(expression).SingleOrDefaultAsync();
        }

        public void UpdateCart(Cart cart)
        {
            Update(cart);
        }
    }
}
