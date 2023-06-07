
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace Services.Services.ItemServices
{
    public class ItemService : IItemService
    {
        private readonly IRepositoryWrapper _wrapper;

        public ItemService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public Task<ServiceResponse<int?>> CreateItem(Item roleDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool?>> DeleteItem(Item roleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Item>?>> GetAllItems()
        {
            var items = await _wrapper.Item.GetAllItems();

            if (items is not null)
            {
                return new ServiceResponse<List<Item>?>()
                {
                    Data = items,
                    Message = "Retrieved all items successfully!",
                    Success = true
                };
            }
            else
                return new ServiceResponse<List<Item>?>()
                {
                    Data = items,
                    Message = "Could not find any items!",
                    Success = false
                };

        }

        public async Task<ServiceResponse<Item?>> GetItemByCondition(Expression<Func<Item, bool>> expression)
        {
            var response = await _wrapper.Item.GetSingleItem(expression);

            if (response is not null)
            {
                return new ServiceResponse<Item?>
                {
                    Data = response,
                    Message = "Retrieved Item successfully",
                    Success = true
                };
            }
            else
                return new ServiceResponse<Item?>
                {
                    Data = null,
                    Message = "Could not retrieve Item!",
                    Success = false
                }; 
        }

        public Task<ServiceResponse<int>> UpdateItem(Item roleDto)
        {
            throw new NotImplementedException();
        }
    }
}
