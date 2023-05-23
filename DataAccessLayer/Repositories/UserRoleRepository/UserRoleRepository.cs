using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RolePermissionRepo
{
    public class UserRoleRepository : RepositoryBase<UserRoleEntity>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public void DenyRole(UserRoleEntity userRoleEntity)
        {                      
            Delete(userRoleEntity);                        
        }

        public async Task<List<UserRoleEntity>> GetAllUserRoles()
        {
            return await FindAll().Include(u => u.User).Include(u => u.Role).ToListAsync();
        }

        public async Task<UserRoleEntity> GetUserRoleByCondition(Expression<Func<UserRoleEntity, bool>> expression)
        {
            return await FindByCondition(expression).Include(UR=> UR.Role).Include(UR => UR.User).FirstOrDefaultAsync();
        }

        public async Task<List<UserRoleEntity>> GetUserRoles()
        {
            return await FindAll().ToListAsync();
        }

        public void GrantRole(UserRoleEntity userRoleEntity)
        {
            Create(userRoleEntity);
        }

        public void UpdateRole(UserRoleEntity userRoleEntity)
        {
           Update(userRoleEntity); 
        }
    }
}
