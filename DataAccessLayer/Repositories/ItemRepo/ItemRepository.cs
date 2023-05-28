using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.ItemRepo
{
    internal class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(ApplicationContext applicationContext) : base (applicationContext)
        {
            
        }

        public void CreateItem(Item item)
        {
            Create(item);
        }

        public void DeleteItem(Item item)
        {
            Delete(item);
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Item?> GetSingleItem(Expression<Func<Item, bool>> expression)
        {
            return await FindByCondition(expression).SingleOrDefaultAsync();
        }

        public void UpdateItem(Item item)
        {
            Update(item);
        }
    }
}
