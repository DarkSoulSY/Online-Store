using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public List<Order> Orders { get; set; }


    }
}
