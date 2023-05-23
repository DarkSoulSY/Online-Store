using DataAccessLayer.Models;
using Services.common.RoleDto;


namespace Services.Services.RoleService
{
    public interface IRoleService
    {
        Task<ServiceResponse<int>>CreateRole(RoleDto roleDto);
        Task<ServiceResponse<bool?>>DeleteRole(RoleDto roleDto);
        Task<ServiceResponse<Role>>GetRoleByName(string name);
        Task<ServiceResponse<List<Role>?>>GetAllRoles();
        Task<ServiceResponse<int>>UpdateRole(RoleDto roleDto);
    }
}
