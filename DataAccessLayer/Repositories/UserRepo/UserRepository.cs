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

        public async Task<List<User>> GetAll()
        {
            return await FindAll().OrderBy(u => u.Id).ToListAsync();
        }

        public async Task<User?> GetUserByUserName(string userName)
        {
            return await FindByCondition(u => u.Username == userName).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByPhone(string phoneNumber)
        {
            return await FindByCondition(u => u.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }

        public void CreateUser(User user)
        {
            Create(user);            
        }
    }
}
