using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using Services.common.UserRoleEntity;
using Services.Services.UserPermissionService;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.Services.UserRoleService
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly IMapper _mapper;

        public UserRoleService(IRepositoryWrapper wrapper, IMapper mapper)
        {
            _wrapper = wrapper;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> DenyRole(int id)
        {
            
            var UR = await _wrapper.UserRole.GetUserRoleByCondition(ur => ur.Id == id);



            if (UR is not null)
            {
                _wrapper.UserRole.DenyRole(UR);
                await _wrapper.SaveAsync();
            }

            return new ServiceResponse<bool>()
            {
                Data = true,
                Message = "Success!",
                Success = true
            };


        }

        public Task<ServiceResponse<Role>> DenyRole(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<UserRole>>> GetAllUserRole()
        {
            var list = await  _wrapper.UserRole.GetAllUserRoles();
            
            return new ServiceResponse<List<UserRole>>(){
                Data = list,
                Message = "Success",
                Success = true

            };

            
        }

        public async Task<ServiceResponse<UserRole>> GetUserRoleByCondition(Expression<Func<UserRole, bool>> expression)
        {
            return
                new ServiceResponse<UserRole>() {
                    Data = await _wrapper.UserRole.GetUserRoleByCondition(expression),
                    Message = "",
                Success = true
                };
        }

        public Task<ServiceResponse<List<UserRole>>> GetUserRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<UserRole?>> GrantRole(UserRoleDto userRoleDto)
        {
            var user = await _wrapper.User.GetSingleUser(u => u.Username.Equals(userRoleDto.Username));
            var role = await _wrapper.Role.GetSingleRole(R => R.Name == userRoleDto.Role);
            if (user is not null && role is not null)
            {
                //userRoleEntity.UserId = user.Id;
                //userRoleEntity.RoleId = role.Id;
                var userRoleEntity = new UserRole()
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                };
                //User = user
                //Role = role
                _wrapper.UserRole.GrantRole(userRoleEntity);
                await _wrapper.SaveAsync();
            }
            var newUserRoleEntity = await _wrapper.UserRole.GetUserRoleByCondition(UR => UR.Role == role && UR.User == user);

            if (newUserRoleEntity is not null)
                return new ServiceResponse<UserRole?>()
                {
                    Data = newUserRoleEntity,
                    Message = $"Role {userRoleDto!.Role} added to {userRoleDto.Username}! ",
                    Success = true,
                };
            else
                return new ServiceResponse<UserRole?>()
                {
                    Data = null,
                    Message = $"Could not add {userRoleDto!.Role} to {userRoleDto.Username}!",
                    Success = true,
                };

        }

        public async Task<ServiceResponse<bool>> UpdateRole(UserRoleDto userRoleDto)
        {
            UserRole ur = await _wrapper.UserRole.GetUserRoleByCondition(UR => UR.Id == userRoleDto.Id);

            if (ur is not null) 
            { 
                var role = await _wrapper.Role.GetSingleRole(r => r.Name == userRoleDto.Role);
                var user = await _wrapper.User.GetSingleUser(u => u.Username == userRoleDto.Username);
                if (user is not null && role is not null) {
                    ur.RoleId = role.Id;
                    ur.UserId = user.Id;
                    ur.User = null;
                    ur.Role = null;
                    _wrapper.UserRole.UpdateRole(ur);
                    await _wrapper.SaveAsync();
                }
                
            }
            

            
            return new ServiceResponse<bool>()
            {
                Data = true,
                Message = $"Success!",
                Success = true,
            };
        }
    }
}
