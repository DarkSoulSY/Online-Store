using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RoleRepo
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        Task<List<Role>>GetAllRoles();
        Task<Role> GetSingleRole(Expression<Func<Role, bool>> expression);
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
            
    }
}
