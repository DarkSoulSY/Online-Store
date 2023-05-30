

using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.RoleRepo;
using DataAccessLayer.Repositories.WrapperRepo;
using Services.common.Role;

namespace Services.Services.RoleService
{
    public class RoleService : IRoleService
    {      
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _wrapper;

        public RoleService(IRoleRepository repo, IMapper mapper, IRepositoryWrapper wrapper)
        {
            
            _mapper = mapper;
            _wrapper = wrapper;
        }
        public async Task<ServiceResponse<int>> CreateRole(RoleDto roleDto)
        {
            var mappedRole = _mapper.Map<Role>(roleDto);
            Role? role = await _wrapper.Role.GetSingleRole(r => r.Name == roleDto.Name);
            
            if (role is null)
            {
                _wrapper.Role.CreateRole(mappedRole);
                await _wrapper.SaveAsync();
                
                Role? newRole = await _wrapper.Role.GetSingleRole(r => r.Name == roleDto.Name);
                return new ServiceResponse<int>()
                {
                    Data = newRole!.Id,
                    Message = $"Role {newRole!.Name} has been created!",
                    Success = true,
                };
            }

            else
                return new ServiceResponse<int>()
            {
                Data = role.Id,
                Message = $"Role {roleDto.Name} already exists!",
                Success = false,
            };

        }

        public async Task<ServiceResponse<bool?>> DeleteRole(RoleDto roleDto)
        {
            var mappedRole = _mapper.Map<Role>(roleDto);
            Role? role = await _wrapper.Role.GetSingleRole(r => r.Name == mappedRole.Name);

            if (role is not null)
            {
                mappedRole.Id = role.Id;
                _wrapper.Role.DeleteRole(mappedRole);

                await _wrapper.SaveAsync();

                Role? newRole = await _wrapper.Role.GetSingleRole(r => r.Name == mappedRole.Name);
                if (newRole is null)
                    return new ServiceResponse<bool?>()
                    {
                        Data = null,
                        Message = $"Role {mappedRole!.Name} has been deleted!",
                        Success = true,
                    };
                else
                    return new ServiceResponse<bool?>()
                    {
                        Data = null,
                        Message = $"Could not delete Role {mappedRole.Name}!",
                        Success = false,
                    };
            }

            else
                return new ServiceResponse<bool?>()
                {
                    Data = null,
                    Message = $"Role {mappedRole.Name} does not exists!",
                    Success = false,
                };
        }

        public async Task<ServiceResponse<Role>> GetRoleByName(string name)
        { 
            Role? role = await _wrapper.Role.GetSingleRole(r => r.Name == name);

            if (role is not null)
            {
                
                return new ServiceResponse<Role>()
                {
                    Data = role,
                    Message = $"Role \"{name}\" has been retrieved!",
                    Success = true,
                };
            }

            else
                return new ServiceResponse<Role>()
                {
                    Data = null,
                    Message = $"Could not retrieve Role \"{name}\"!",
                    Success = false,
                };
        }

        public async Task<ServiceResponse<List<Role>?>> GetAllRoles()
        {
            var roles = await _wrapper.Role.GetAllRoles();
            if (roles is not null)
                return new ServiceResponse<List<Role>?>()
                { 
                    Data = roles,
                    Message = "Retrieved all roles sucessfully!",
                    Success = true
                };
            else
                return new ServiceResponse<List<Role>?>()
                {
                    Data = null,
                    Message = "No roles found!",
                    Success = false
                };
        }

        public Task<ServiceResponse<int>> UpdateRole(RoleDto roleDto)
        {
            throw new NotImplementedException();
        }
    }
}
