
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using System.Linq.Expressions;

namespace Services.Services.CartServices
{
    public class CartService : ICartService
    {
        private readonly IRepositoryWrapper _wrapper;

        public CartService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;            
        }
        public async Task<ServiceResponse<int?>> CreateCart(Cart cart)
        {
            _wrapper.Cart.CreateCart(cart);
            await _wrapper.SaveAsync();
            var cartResult = await _wrapper.Cart.GetSingleCart(C => C.Id == cart.Id);
            if (cartResult is not null)
            {
                return new ServiceResponse<int?>(){
                    Data = cartResult.Id,
                    Message = "Retrieved cart successfully!",
                    Success = true
                };
            }
            else
                return new ServiceResponse<int?>()
                {
                    Data = null,
                    Message = "Could not retrieve cart successfully!",
                    Success = false
                };
        }

        public Task<ServiceResponse<bool?>> DeleteCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Cart>?>> GetAllCarts()
        {
            var carts = await _wrapper.Cart.GetAllCarts();

            if (carts is not null)
            {
                return new ServiceResponse<List<Cart>?>()
                {
                    Data = carts,
                    Message = "Retrieved all carts successfully!",
                    Success = true
                };
            }
            else
                return new ServiceResponse<List<Cart>?>()
                {
                    Data = null,
                    Message = "Could not find any carts!",
                    Success = false
                };
        }

        public async Task<ServiceResponse<Cart?>> GetCartByCondition(Expression<Func<Cart, bool>> expressions)
        {
            var cartResult = await _wrapper.Cart.GetSingleCart(expressions);
            if (cartResult is not null)
            {
                return new ServiceResponse<Cart?>()
                {
                    Data = cartResult,
                    Message = "Retrieved cart successfully!",
                    Success = true
                };
            }
            else
                return new ServiceResponse<Cart?>()
                {
                    Data = null,
                    Message = "Could not retrieve cart successfully!",
                    Success = false
                };
        }

        public Task<ServiceResponse<int>> UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
