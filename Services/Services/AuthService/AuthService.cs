using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.UserRepo;
using DataAccessLayer.Repositories.WrapperRepo;
using Services.common.UserDto;
using System.Text;


namespace Services.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly IMapper _mapper;

        public AuthService(IRepositoryWrapper wrapper, IMapper mapper)
        {
            _wrapper = wrapper;
            _mapper = mapper;   

        }
        public Task<ServiceResponse<string>> Login(UserSignInDto userSignInDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int?>> Register(UserSignUpDto userSignUpDto)
        {
            var newUser = _mapper.Map<User>(userSignUpDto);
            bool switcher = await UserExists(newUser.Username);
            if (!switcher)
            {
                //Hasing User's Password
                CreatePasswordHash(userSignUpDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                newUser.PasswordHash = passwordHash;
                newUser.PasswordSalt = passwordSalt;
                _wrapper.User.CreateUser(newUser);
                await _wrapper.SaveAsync();               
                return new ServiceResponse<int?>
                {
                    Data = newUser.Id,
                    Message = $"Registered {userSignUpDto.Username} Successfully!",
                    Success = true

                };

            }
            else
                return new ServiceResponse<int?>
                {
                    Data = null,
                    Message = $"{userSignUpDto.Username} Already Exists!",
                    Success = false

                };
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _wrapper.User.GetUserByUserName(username) == null) { return false; }

            else { return true; }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}
