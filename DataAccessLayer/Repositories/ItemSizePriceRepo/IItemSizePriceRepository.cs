using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.ItemSizePriceRepo
{
    public interface IItemSizePriceRepository : IRepositoryBase<ItemSizePrice>
    {
        Task<List<ItemSizePrice>> GetAllItemSizePrices();
        Task<ItemSizePrice?> GetSingleItemSizePrice(Expression<Func<ItemSizePrice, bool>> expression);        
        void CreateItemSizePrice(ItemSizePrice itemSizePrice);
        void UpdateItemSizePrice(ItemSizePrice itemSizePrice);
        void DeleteItemSizePrice(ItemSizePrice itemSizePrice);
    }
}
