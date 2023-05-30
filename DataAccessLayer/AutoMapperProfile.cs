using AutoMapper;
using DataAccessLayer.Models;
using Services.common.Permission;
using Services.common.Role;
using Services.common.User;
using Services.common.UserRoleEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserSignInDto, User>();
            CreateMap<UserSignUpDto, User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)); 
            CreateMap<User, UserSignInDto>();
            CreateMap<User, UserSignUpDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<PermissionDto, Permission>();
            CreateMap<Permission, PermissionDto>();
            CreateMap<UserInfoDto, User>();
            CreateMap<User, UserInfoDto>();
            CreateMap<UserRoleDto, UserRole>();
            CreateMap<UserRole, UserRoleDto>();
        }
    }
}
