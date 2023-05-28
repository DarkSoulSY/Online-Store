using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.ItemSizePriceOrderRepo
{
    public interface IItemSizePriceOrderRepository : IRepositoryBase<ItemSizePriceOrder>
    {
        Task<List<ItemSizePriceOrder>> GetAllItemSizePriceOrders();
        Task<ItemSizePriceOrder?> GetSingleItemSizePriceOrder(Expression<Func<ItemSizePriceOrder, bool>> expression);
        void CreateItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder);
        void UpdateItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder);
        void DeleteItemSizePriceOrder(ItemSizePriceOrder itemSizePriceOrder);
    }
}
