
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace Services.Services.ItemSizePriceSizePriceServices
{
    public interface IItemSizePriceService
    {
        Task<ServiceResponse<List<ItemSizePrice>?>> GetAllItemSizePrice();
        Task<ServiceResponse<int?>> CreateItemSizePrice(ItemSizePrice itemSizePrice);
        Task<ServiceResponse<bool?>> DeleteItemSizePrice(ItemSizePrice itemSizePrice);
        Task<ServiceResponse<ItemSizePrice?>> GetItemSizePriceByCondition(Expression<Func<ItemSizePrice, bool>> expression);
        Task<ServiceResponse<int>> UpdateItemSizePrice(ItemSizePrice itemSizePrice);
    }
}
