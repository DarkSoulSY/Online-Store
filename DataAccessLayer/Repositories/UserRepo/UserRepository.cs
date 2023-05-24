using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using Services.common.UserDto;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.UserRepo
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    { 
        public UserRepository(ApplicationContext applicationContext): base(applicationContext)
        {

        }

        public async Task<List<User>> GetAllUsers()
        {
            return await FindAll().OrderBy(u => u.Id).ToListAsync();
        }
        public async Task<User?> GetSingleUser(Expression<Func<User, bool>> expression)
        {
            return await FindByCondition(expression).FirstOrDefaultAsync();
        }

        public void CreateUser(User user)
        {
            Create(user);            
        }        

        public void UpdateUser(User user)
        {
            Update(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }
        
    }
}
