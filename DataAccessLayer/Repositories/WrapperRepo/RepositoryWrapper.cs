using DataAccessLayer.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.WrapperRepo
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _context;
        private IUserRepository? _user;

        public RepositoryWrapper(ApplicationContext context, IUserRepository user)
        {
            _context = context;        
        }

        public IUserRepository User
        {
            get
            { 
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
