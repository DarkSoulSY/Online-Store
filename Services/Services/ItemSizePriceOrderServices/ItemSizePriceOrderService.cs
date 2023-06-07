
using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using System.Linq.Expressions;

namespace Services.Services.ItemSizePriceOrderServices
{
    public class ItemSizePriceOrderService : IItemSizePriceOrderService
    {
        private readonly IRepositoryWrapper _wrapper;

        public ItemSizePriceOrderService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }
        public async Task<ServiceResponse<int?>> CreateItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder)
        {
            _wrapper.ItemSizePriceOrder.Create(itemSizePriceOrder);
            await _wrapper.SaveAsync();

            var response = await _wrapper.ItemSizePriceOrder.GetSingleItemSizePriceOrder(I => I.Id == itemSizePriceOrder.Id);

            if (response is not null)
            {
                return new ServiceResponse<int?>()
                {
                    Data = itemSizePriceOrder.Id,
                    Message = "Created order Successfully!",
                    Success = true
                };
            }
            else
                return new ServiceResponse<int?>()
                {
                    Data = null,
                    Message = "Could not create order Successfully!",
                    Success = false
                };
        }

        public Task<ServiceResponse<bool?>> DeleteItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ItemSizePriceOrder>?>> GetAllItemSizePriceOrders()
        {
            var response = await _wrapper.ItemSizePriceOrder.GetAllItemSizePriceOrders();

            if (response is not null)
            {
                return new ServiceResponse<List<ItemSizePriceOrder>?>()
                {
                    Data = response,
                    Message = "Retrieved all order items successfully!",
                    Success = true
                };
            }
            else
                return new ServiceResponse<List<ItemSizePriceOrder>?>()
                {
                    Data = response,
                    Message = "could not retrieved any order items!",
                    Success = false
                };
        }

        public Task<ServiceResponse<ItemSizePriceOrder?>> GetItemSizePriceOrderByCondition(Expression<Func<Cart, bool>> expressions)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> UpdateItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder)
        {
            throw new NotImplementedException();
        }
    }
}
