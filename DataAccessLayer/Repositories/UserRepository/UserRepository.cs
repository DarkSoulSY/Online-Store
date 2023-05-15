using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.UserRepository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    { 
        public UserRepository(ApplicationContext applicationContext): base(applicationContext)
        {

        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }
        
    }
}
