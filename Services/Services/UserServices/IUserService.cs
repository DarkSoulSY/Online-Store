using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.UserServices
{
    public interface IUserService
    {       
        Task<ServiceResponse<bool?>> DeleteUser(User user);
        Task<ServiceResponse<User?>> GetUserByCondition(Expression<Func<User, bool>> expressions);
        //Task<ServiceResponse<List<User>?>> GetAllUsers();
        Task<ServiceResponse<User?>> UpdateUser(User user);
    }

}
