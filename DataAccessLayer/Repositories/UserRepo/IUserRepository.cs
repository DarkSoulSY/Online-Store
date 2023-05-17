using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Services.common.UserDto;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.UserRepo
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<List<User>> GetAll();
        Task<User?> GetUserByUserName(string userName);
        Task<User?> GetUserByPhone(string phoneNumber);
        void CreateUser(User user);
        Task<User?> GetUserByCondition(Expression<Func<User, bool>> expression);
    }
    
}
