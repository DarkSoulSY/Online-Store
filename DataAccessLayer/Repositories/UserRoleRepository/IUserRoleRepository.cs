

using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.RolePermissionRepo
{
    public interface IUserRoleRepository
    {
        Task<List<UserRoleEntity>> GetUserRoles();
        Task<List<UserRoleEntity>> GetAllUserRoles();
        Task<UserRoleEntity> GetUserRoleByCondition(Expression<Func<UserRoleEntity, bool>> expression);

        void GrantRole(UserRoleEntity userRoleEntity);
        void DenyRole(UserRoleEntity userRoleEntity);
        void UpdateRole(UserRoleEntity userRoleEntity);

       
    }
}
