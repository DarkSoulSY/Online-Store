using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.ItemSizePriceOrderRepo
{
    public class ItemSizePriceOrderRepository : RepositoryBase<ItemSizePriceOrder>, IItemSizePriceOrderRepository
    {
        public ItemSizePriceOrderRepository(ApplicationContext applicationContext) : base (applicationContext)
        {
            
        }
        public void CreateItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder)
        {
            Create(itemSizePriceOrder);
        }

        public void DeleteItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder)
        {
            Delete(itemSizePriceOrder);
        }

        public async Task<List<ItemSizePriceOrder>> GetAllItemSizePriceOrders()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<ItemSizePriceOrder?> GetSingleItemSizePriceOrder(Expression<Func<ItemSizePriceOrder, bool>> expression)
        {
            return await FindByCondition(expression).SingleOrDefaultAsync();
        }

        public void UpdateItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder)
        {
            Update(itemSizePriceOrder);
        }
    }
}
