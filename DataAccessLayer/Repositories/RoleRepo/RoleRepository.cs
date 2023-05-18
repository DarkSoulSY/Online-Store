using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RoleRepo
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context) : base(context) { }

        public void CreateRole(Role role)
        {
            Create(role);
        }

        public void DeleteRole(Role role)
        {            
            Delete(role);
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Role> GetSingleRole(Expression<Func<Role, bool>> expression)
        {
            return await FindByCondition(expression).FirstAsync();           
        }   

        public void UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
