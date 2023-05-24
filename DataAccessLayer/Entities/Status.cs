using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Status
    {
        public int Id { get; set; }
        public bool Submitted { get; set; } = false;
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
