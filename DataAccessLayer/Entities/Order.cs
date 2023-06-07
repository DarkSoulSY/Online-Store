using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }        
        public Status Status { get; set; } = new Status();
        public List<ItemSizePriceOrder> itemSizePriceOrders { get; set; }

    }
}
