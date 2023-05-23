using DataAccessLayer.Models;
using DataAccessLayer.Repositories.PermissionRepo;
using DataAccessLayer.Repositories.RolePermissionRepo;
using DataAccessLayer.Repositories.RoleRepo;
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
        private IRoleRepository? _role;
        private IPermissionRepository? _permission;
        private IUserRoleRepository? _userRole;

        public RepositoryWrapper(ApplicationContext context, IUserRepository user)
        {
            _context = context;        
        }

        public IUserRoleRepository UserRole
        {
            get
            {
                if(_userRole == null)
                {
                    _userRole = new UserRoleRepository(_context);
                }
                return _userRole;
            }
        }

        public IPermissionRepository Permission
        {
            get
            {
                if (_permission == null)
                {
                    _permission = new PermissionRepository(_context);
                }
                return _permission;
            }
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

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_context);
                }
                return _role;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
