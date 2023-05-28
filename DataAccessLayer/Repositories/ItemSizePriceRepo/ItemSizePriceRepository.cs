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
    internal class ItemSizePriceRepository : RepositoryBase<ItemSizePrice>, IItemSizePriceRepository
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
            return await FindAll().ToListAsync();
        }

        public async Task<ItemSizePrice?> GetSingleItemSizePrice(Expression<Func<ItemSizePrice, bool>> expression)
        {
            return await FindByCondition(expression).SingleOrDefaultAsync();
        }

        public void UpdateItemSizePrice(ItemSizePrice itemSizePrice)
        {
            Update(itemSizePrice);
        }
    }
}
