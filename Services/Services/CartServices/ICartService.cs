
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace Services.Services.CartServices
{
    public interface ICartService 
    {
        Task<ServiceResponse<int?>> CreateCart(Cart cart);
        Task<ServiceResponse<bool?>> DeleteCart(Cart cart);
        Task<ServiceResponse<Cart?>> GetCartByCondition(Expression<Func<Cart, bool>> expressions);
        Task<ServiceResponse<List<Cart>?>> GetAllCarts();
        Task<ServiceResponse<int>> UpdateCart(Cart cart);
    }
}
