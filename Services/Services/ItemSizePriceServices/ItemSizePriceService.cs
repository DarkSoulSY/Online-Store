using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using Services.Services.ItemSizePriceSizePriceServices;
using System.Linq.Expressions;

namespace Services.Services.ItemSizePriceServices
{
    public class ItemSizePriceService : IItemSizePriceService
    {
        private readonly IRepositoryWrapper _wrapper;

        public ItemSizePriceService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public Task<ServiceResponse<int?>> CreateItemSizePrice(ItemSizePrice itemSizePrice)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool?>> DeleteItemSizePrice(ItemSizePrice itemSizePrice)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ItemSizePrice>?>> GetAllItemSizePrice()
        {
            var itemSizePrice = await _wrapper.ItemSizePrice.GetAllItemSizePrices();

            if (itemSizePrice is not null)
            {
                return new ServiceResponse<List<ItemSizePrice>?>()
                {
                    Data = itemSizePrice,
                    Message = "Retrieved all item size prices successfully!",
                    Success = true
                };
            }
            else
                return new ServiceResponse<List<ItemSizePrice>?>()
                {
                    Data = itemSizePrice,
                    Message = "Could not find any item size prices!",
                    Success = false
                };
        }

        public Task<ServiceResponse<List<ItemSizePrice>?>> GetAllItemSizePriceSizePrice()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<ItemSizePrice?>> GetItemSizePriceByCondition(Expression<Func<ItemSizePrice, bool>> expression)
        {
            var response = await _wrapper.ItemSizePrice.GetSingleItemSizePrice(expression);

            if (response is not null)
            {
                return new ServiceResponse<ItemSizePrice?>
                {
                    Data = response,
                    Message = "Retrieved ItemSizePrice successfully",
                    Success = true
                };
            }
            else
                return new ServiceResponse<ItemSizePrice?>
                {
                    Data = null,
                    Message = "Could not retrieve ItemSizePrice!",
                    Success = false
                };
        }

        public Task<ServiceResponse<int>> UpdateItemSizePrice(ItemSizePrice itemSizePrice)
        {
            throw new NotImplementedException();
        }
    }
}
