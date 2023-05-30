
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;

namespace Services.Services.ItemSizePriceServices
{
    public class ItemSizePriceService : IItemSizePriceService
    {
        private readonly IRepositoryWrapper _wrapper;

        public ItemSizePriceService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
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

    }
}
