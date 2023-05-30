using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ItemSizePrice
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int Price { get; set; }
    }
}
