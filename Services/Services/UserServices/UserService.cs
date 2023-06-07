using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _wrapper;

        public UserService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }        

        public async Task<ServiceResponse<bool?>> DeleteUser(User user)
        {            
            _wrapper.User.DeleteUser(user);
            await _wrapper.SaveAsync();

            return new ServiceResponse<bool?> {
                Data = null,
                Message = "Deleted user sucessfully!",
                Success = true
            };
        }

        //public Task<ServiceResponse<List<User>?>> GetAllUsers()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ServiceResponse<User?>> GetUserByCondition(Expression<Func<User, bool>> expressions)
        {
            var response = await _wrapper.User.GetSingleUser(expressions);

            if (response is not null)
            {
                return new ServiceResponse<User?>
                {
                    Data = response,
                    Message = "Retrieved user successfully!",
                    Success = true
                };
            }
            else
                return new ServiceResponse<User?>
                {
                    Data = null,
                    Message = "could not retrieve user successfully!",
                    Success = false
                };


        }

        public Task<ServiceResponse<User?>> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
