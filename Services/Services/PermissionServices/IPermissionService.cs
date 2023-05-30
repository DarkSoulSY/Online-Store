using DataAccessLayer.Models;
using Services.common.Permission;


namespace Services.Services.PermissionService
{
    public interface IPermissionService
    {
        Task<ServiceResponse<int>> CreatePermission(PermissionDto permissionDto);
        Task<ServiceResponse<bool?>> DeletePermission(PermissionDto permissionDto);
        Task<ServiceResponse<Permission>> GetPermissionByName(string name);
        Task<ServiceResponse<List<Permission>?>> GetAllPermissions();
        Task<ServiceResponse<int>> UpdatePermission(PermissionDto permissionDto);
    }
}
