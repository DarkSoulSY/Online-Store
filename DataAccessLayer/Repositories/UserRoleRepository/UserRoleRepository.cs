using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.RolePermissionRepo
{
    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public void DenyRole(UserRole userRoleEntity)
        {                      
            Delete(userRoleEntity);                        
        }

        public async Task<List<UserRole>> GetAllUserRoles()
        {
            return await FindAll().Include(u => u.User).Include(u => u.Role).ToListAsync();
        }

        public async Task<UserRole> GetUserRoleByCondition(Expression<Func<UserRole, bool>> expression)
        {
            return await FindByCondition(expression).Include(UR=> UR.Role).Include(UR => UR.User).SingleOrDefaultAsync();
        }

        public async Task<List<UserRole>> GetUserRoles()
        {
            return await FindAll().ToListAsync();
        }

        public void GrantRole(UserRole userRoleEntity)
        {
            Create(userRoleEntity);
        }

        public void UpdateRole(UserRole userRoleEntity)
        {
           Update(userRoleEntity); 
        }
    }
}
