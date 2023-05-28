using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.ItemRepo
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        Task<List<Item>> GetAllItems();
        Task<Item?> GetSingleItem(Expression<Func<Item, bool>> expression);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);
    }
}
