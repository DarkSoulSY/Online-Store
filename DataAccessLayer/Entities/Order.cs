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
        public float Total { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public List<ItemSizePrice> itemSizePrices { get; set; }

    }
}
