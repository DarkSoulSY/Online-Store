using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class RolePermission
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public Permission Permission { get; set; }
        public int PermissionId { get; set; }

    }
}
