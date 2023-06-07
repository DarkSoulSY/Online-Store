using DataAccessLayer.Models;
using Services.common.UserRoleEntity;
using System.Linq.Expressions;

namespace Services.Services.UserPermissionService
{
    public interface IUserRoleService
    {
        Task<ServiceResponse<List<UserRole>>> GetAllUserRole();
        Task<ServiceResponse<List<UserRole>>> GetUserRoles();
        Task<ServiceResponse<UserRole>> GetUserRoleByCondition(Expression<Func<UserRole, bool>> expression);

        Task<ServiceResponse<UserRole?>> GrantRole(UserRoleDto userRoleDto);
        Task<ServiceResponse<bool>> DenyRole(int id);
        Task<ServiceResponse<bool>> UpdateRole(UserRoleDto userRoleDto);


    }
}
