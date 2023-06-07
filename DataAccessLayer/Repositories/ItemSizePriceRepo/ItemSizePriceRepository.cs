using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.ItemSizePriceRepo
{
    public class ItemSizePriceRepository : RepositoryBase<ItemSizePrice>, IItemSizePriceRepository
    {
        public ItemSizePriceRepository(ApplicationContext applicationContext) : base (applicationContext)
        {
            
        }

        public void CreateItemSizePrice(ItemSizePrice itemSizePrice)
        {
            Create(itemSizePrice);
        }

        public void DeleteItemSizePrice(ItemSizePrice itemSizePrice)
        {
            Delete(itemSizePrice);
        }

        public async Task<List<ItemSizePrice>> GetAllItemSizePrices()
        {
            return await FindAll().Include(E => E.Size).ToListAsync();
        }

        public async Task<ItemSizePrice?> GetSingleItemSizePrice(Expression<Func<ItemSizePrice, bool>> expression)
        {
            return await FindByCondition(expression).Include(E => E.Size).Include(E => E.Item).SingleOrDefaultAsync();
        }        

        public void UpdateItemSizePrice(ItemSizePrice itemSizePrice)
        {
            Update(itemSizePrice);
        }
    }
}
