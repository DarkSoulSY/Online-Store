using DataAccessLayer.Models;
using Services.common.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int?>> Register(UserSignUpDto userSignUpDto);
        Task<ServiceResponse<string>> Login(UserSignInDto userSignInDto);
        Task<bool> UserExists(string username);
        Task<List<UserInfoDto>> GetAllUsers();
        Task<ServiceResponse<User?>> UpdateUser(User user, string password);
        Task<ServiceResponse<User?>> DeleteUser(int id);
        Task<ServiceResponse<User?>> GetUser(int id);
    }
}
