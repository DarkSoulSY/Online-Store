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
        public async Task<ServiceResponse<string>> Login(UserSignInDto userSignInDto)
        {
            var response = new ServiceResponse<string>();
            var loggingUser = await _wrapper.User.GetUserByCondition(u => u.Username == userSignInDto.Username);
            var exists = await UserExists(userSignInDto.Username);
            if (exists)
            {
                var verified = VerifyPasswordHash(userSignInDto.Password, loggingUser!.PasswordHash, loggingUser.PasswordSalt);
                if (verified)
                    return new ServiceResponse<string>()
                    {
                        Data = loggingUser.Id + " ",
                        Message = $"Welcome {loggingUser.Username}.",
                        Success = true
                    };
                else
                    return new ServiceResponse<string>()
                    {
                        Data = "",
                        Message = $"Incorrect username or password.",
                        Success = false
                    };
            }

            return new ServiceResponse<string>()
            {
                Data = "",
                Message = $"User not found.",
                Success = false
            };


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

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
