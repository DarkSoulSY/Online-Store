using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.PermissionRepo;
using DataAccessLayer.Repositories.WrapperRepo;
using Services.common.Permission;



namespace Services.Services.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _wrapper;
        public PermissionService(IPermissionRepository repo, IMapper mapper, IRepositoryWrapper wrapper)
        {
            _mapper = mapper;
            _wrapper = wrapper;
        }
        public async Task<ServiceResponse<int>> CreatePermission(PermissionDto permissionDto)
        {
            var mappedPermission = _mapper.Map<Permission>(permissionDto);
            Permission? permission = await _wrapper.Permission.GetSinglePermission(r => r.Name == permissionDto.Name);

            if (permission is null)
            {
                _wrapper.Permission.CreatePermission(mappedPermission);
                await _wrapper.SaveAsync();

                Permission? newPermission = await _wrapper.Permission.GetSinglePermission(r => r.Name == permissionDto.Name);
                return new ServiceResponse<int>()
                {
                    Data = newPermission!.Id,
                    Message = $"Permission {newPermission!.Name} has been created!",
                    Success = true,
                };
            }

            else
                return new ServiceResponse<int>()
                {
                    Data = permission.Id,
                    Message = $"Permission {permissionDto.Name} already exists!",
                    Success = false,
                };
        }

        public async Task<ServiceResponse<bool?>> DeletePermission(PermissionDto permissionDto)
        {
            var mappedPermission = _mapper.Map<Permission>(permissionDto);
            Permission? permission = await _wrapper.Permission.GetSinglePermission(r => r.Name == mappedPermission.Name);

            if (permission is not null)
            {
                mappedPermission.Id = permission.Id;
                _wrapper.Permission.DeletePermission(mappedPermission);

                await _wrapper.SaveAsync();

                Permission? newPermission = await _wrapper.Permission.GetSinglePermission(r => r.Name == mappedPermission.Name);
                if (newPermission is null)
                    return new ServiceResponse<bool?>()
                    {
                        Data = null,
                        Message = $"Permission {mappedPermission!.Name} has been deleted!",
                        Success = true,
                    };
                else
                    return new ServiceResponse<bool?>()
                    {
                        Data = null,
                        Message = $"Could not delete Permission {mappedPermission.Name}!",
                        Success = false,
                    };
            }

            else
                return new ServiceResponse<bool?>()
                {
                    Data = null,
                    Message = $"Permission {mappedPermission.Name} does not exists!",
                    Success = false,
                };
        }

        public async Task<ServiceResponse<List<Permission>?>> GetAllPermissions()
        {
            var permissions = await _wrapper.Permission.GetAllPermissions();
            if (permissions is not null)
                return new ServiceResponse<List<Permission>?>()
                {
                    Data = permissions,
                    Message = "Retrieved all Permissions sucessfully!",
                    Success = true
                };
            else
                return new ServiceResponse<List<Permission>?>()
                {
                    Data = null,
                    Message = "No Permissions found!",
                    Success = false
                };
        }

        public async Task<ServiceResponse<Permission>> GetPermissionByName(string name)
        {
            Permission? permissions = await _wrapper.Permission.GetSinglePermission(r => r.Name == name);

            if (permissions is not null)
            {

                return new ServiceResponse<Permission>()
                {
                    Data = permissions,
                    Message = $"Permission \"{name}\" has been retrieved!",
                    Success = true,
                };
            }

            else
                return new ServiceResponse<Permission>()
                {
                    Data = null,
                    Message = $"Could not retrieve Permission \"{name}\"!",
                    Success = false,
                };
        }

        public Task<ServiceResponse<int>> UpdatePermission(PermissionDto PermissionDto)
        {
            throw new NotImplementedException();
        }
    }
}
