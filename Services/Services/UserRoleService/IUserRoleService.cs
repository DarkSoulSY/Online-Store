

using DataAccessLayer.Models;
using Services.common.UserRoleEntity;
using System.Linq.Expressions;

namespace Services.Services.UserPermissionService
{
    public interface IUserRoleService
    {
        Task<ServiceResponse<List<UserRoleEntity>>> GetAllUserRole();
        Task<ServiceResponse<List<UserRoleEntity>>> GetUserRoles();
        Task<ServiceResponse<UserRoleEntity>> GetUserRoleByCondition(Expression<Func<UserRoleEntity, bool>> expression);

        Task<ServiceResponse<UserRoleEntity?>> GrantRole(UserRoleDto userRoleDto);
        Task<ServiceResponse<bool>> DenyRole(int id);
        Task<ServiceResponse<bool>> UpdateRole(UserRoleDto userRoleDto);


    }
}
