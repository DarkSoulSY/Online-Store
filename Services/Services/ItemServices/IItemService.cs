
using DataAccessLayer.Models;
using Services.common.Role;
using System.Linq.Expressions;

namespace Services.Services.ItemServices
{
    public interface IItemService
    {
        Task<ServiceResponse<List<Item>?>> GetAllItems();
        Task<ServiceResponse<int?>> CreateItem(Item roleDto);
        Task<ServiceResponse<bool?>> DeleteItem(Item roleDto);
        Task<ServiceResponse<Item>> GetItemByCondition(Expression<Func<Item, bool>> expression);        
        Task<ServiceResponse<int>> UpdateItem(Item roleDto);
    }
}
