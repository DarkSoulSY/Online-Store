using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ItemSizePriceOrder
    {
        public int Id { get; set; }
        public ItemSizePrice ItemSizePrice { get; set; }
        public int ItemSizePriceId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
