
using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace Services.Services.ItemSizePriceOrderServices
{
    public interface IItemSizePriceOrderService
    {
        Task<ServiceResponse<int?>> CreateItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder);
        Task<ServiceResponse<bool?>> DeleteItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder);
        Task<ServiceResponse<ItemSizePriceOrder?>> GetItemSizePriceOrderByCondition(Expression<Func<Cart, bool>> expressions);
        Task<ServiceResponse<List<ItemSizePriceOrder>?>> GetAllItemSizePriceOrders();
        Task<ServiceResponse<int>> UpdateItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder);
    }
}
