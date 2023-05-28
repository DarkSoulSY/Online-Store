using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.RolePermissionRepo
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> GetUserRoles();
        Task<List<UserRole>> GetAllUserRoles();
        Task<UserRole> GetUserRoleByCondition(Expression<Func<UserRole, bool>> expression);

        void GrantRole(UserRole userRoleEntity);
        void DenyRole(UserRole userRoleEntity);
        void UpdateRole(UserRole userRoleEntity);

       
    }
}
