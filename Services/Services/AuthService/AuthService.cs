using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.UserRepo;
using DataAccessLayer.Repositories.WrapperRepo;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.common.UserDto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Services.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IRepositoryWrapper wrapper, IMapper mapper, IConfiguration configuration)
        {
            _wrapper = wrapper;
            _mapper = mapper;
            _configuration = configuration;
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
                        Data = CreateToken(loggingUser),
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

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;

            if (appSettingsToken is null)
                throw new Exception("AppSettings Token is null!");

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(appSettingsToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            
            return tokenHandler.WriteToken(token);
        }
        public async Task<List<UserInfoDto>> GetAllUsers()
        {
            var usersDto = new List<UserInfoDto>();
            var users = await _wrapper.User.GetAll();
            usersDto = users.Select(u => new UserInfoDto() { Id = u.Id , Address = u.Address , Email = u.Email , PhoneNumber = u.PhoneNumber , Username = u.Username }).ToList();
            return usersDto;
        }

        public async Task<ServiceResponse<User?>> UpdateUser(User user, string password)
        {
            User? oldUser = await _wrapper.User.GetUserByCondition(U => U.Id == user.Id);

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            if (oldUser is not null)
            {
                _wrapper.User.UpdateUser(user);
                await _wrapper.SaveAsync();
                

                return new ServiceResponse<User?>()
                {
                    Data = user,
                    Message = "Updated successfully!",
                    Success = true
                };
            }
            else
            {
                return new ServiceResponse<User?>()
                {
                    Data = null,
                    Message = "Could not update user, user not found!",
                    Success = false
                };
            }    

        }

        public async Task<ServiceResponse<User?>> DeleteUser(int id)
        {
            User? user = await _wrapper.User.GetUserByCondition(U => U.Id == id);
            

            if (user is not null)
            {
                _wrapper.User.DeleteUser(user);
                await _wrapper.SaveAsync();

                User? checkUserExistance = await _wrapper.User.GetUserByCondition(U => U.Id == id);
                if (checkUserExistance is null)
                {
                    return new ServiceResponse<User?>(){
                        Data = null,
                        Message = $"User {user.Username} Deleted!",
                        Success = true
                    };
                }
                else {
                    return new ServiceResponse<User?>()
                    {
                        Data = null,
                        Message = $"Could not delete {user.Username}!",
                        Success = false
                    };
                }
            }
            return new ServiceResponse<User?>()
            {
                Data = null,
                Message = $"Could not find {user.Username}!",
                Success = false
            };

        }

        public async Task<ServiceResponse<User?>> GetUser(int id)
        {
            User? user = await _wrapper.User.GetUserByCondition(U => U.Id == id);


            if (user is not null)
            {                                            
                return new ServiceResponse<User?>()
                {
                    Data = user,
                    Message = $"User {user.Username} retrieved!",
                    Success = true
                };                                                
            }
            return new ServiceResponse<User?>()
            {
                Data = null,
                Message = $"Could not find user!",
                Success = false
            };

        }
    }
}
