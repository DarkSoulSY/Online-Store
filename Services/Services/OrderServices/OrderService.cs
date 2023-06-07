
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using System.Linq.Expressions;

namespace Services.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper _wrapper;

        public OrderService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public async Task<ServiceResponse<Order?>> CreateOrder(Order order)
        {
            var orderExists = await _wrapper.Order.GetSingleOrder(O => O.Status.Submitted == false && O.Cart == order.Cart);
            
            if(orderExists == null)
            {
                _wrapper.Order.CreateOrder(order);
                await _wrapper.SaveAsync();

            }

            var orderExistsSecondCheck = await _wrapper.Order.GetSingleOrder(O => O.CartId == order.CartId);

            if (orderExistsSecondCheck is not null)
            {
                return new ServiceResponse<Order?>
                {
                    Data = orderExistsSecondCheck,
                    Message = "Created user successfully!",
                    Success = true
                };
            }
            else
            {
                return new ServiceResponse<Order?>
                {
                    Data = null,
                    Message = "could not create user!",
                    Success = false
                };
            }


        }

        public Task<ServiceResponse<bool?>> DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Order>?>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Order?>> GetOrderByCondition(Expression<Func<Order, bool>> expressions)
        {
            var response = await _wrapper.Order.GetSingleOrder(expressions);

            if (response is not null) 
            {
                return new ServiceResponse<Order?>
                {
                    Data = response,
                    Message = "Retrieved order successfully",
                    Success = true
                };
            }
            else
                return new ServiceResponse<Order?>
                {
                    Data = response,
                    Message = "Retrieved order successfully",
                    Success = true
                };

        }

        public Task<ServiceResponse<int>> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
