using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.UserRepo
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<List<User>> GetAllUsers();            
        Task<User?> GetSingleUser(Expression<Func<User, bool>> expression);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
    
}
