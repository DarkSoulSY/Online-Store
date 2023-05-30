
using DataAccessLayer.Models;

namespace Services.Services.ItemSizePriceServices
{
    public interface IItemSizePriceService
    {
        Task<ServiceResponse<List<ItemSizePrice>?>> GetAllItemSizePrice();
        
    }
}
