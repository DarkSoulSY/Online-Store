using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int ItemId { get; set; }
        public Item Item { get; set; }
        
    }
}
