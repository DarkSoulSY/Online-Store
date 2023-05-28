using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.CartRepo
{
    public interface ICartRepository : IRepositoryBase<Cart>
    {
        Task<List<Cart>> GetAllCarts();
        Task<Cart?> GetSingleCart(Expression<Func<Cart, bool>> expression);
        void CreateCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
    }
}
