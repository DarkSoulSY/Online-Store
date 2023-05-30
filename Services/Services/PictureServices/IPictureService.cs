
using DataAccessLayer.Models;
using Services.common.Role;

namespace Services.Services.PictureServices
{
    public interface IPictureService
    {
        Task<ServiceResponse<List<Picture>?>> GetAllPictures();
        //Task<ServiceResponse<int>> CreateRole(RoleDto roleDto);
        //Task<ServiceResponse<bool?>> DeleteRole(RoleDto roleDto);
        //Task<ServiceResponse<Role>> GetRoleByName(string name);
        //Task<ServiceResponse<List<Role>?>> GetAllRoles();
        //Task<ServiceResponse<int>> UpdateRole(RoleDto roleDto);
    }
}
