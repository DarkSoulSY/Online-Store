
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Services.Services.ItemServices
{
    public class ItemService : IItemService
    {
        private readonly IRepositoryWrapper _wrapper;

        public ItemService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
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
    }
}
