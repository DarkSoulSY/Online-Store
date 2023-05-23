using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.PermissionRepo
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(ApplicationContext context) : base(context) { }
        public void CreatePermission(Permission Permission)
        {
            Create(Permission);
        }

        public void DeletePermission(Permission Permission)
        {
            Delete(Permission);
        }

        public async Task<List<Permission>> GetAllPermissions()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Permission?> GetSinglePermission(Expression<Func<Permission, bool>> expression)
        {
            return await FindByCondition(expression).FirstOrDefaultAsync();
        }

        public void UpdatePermission(Permission Permission)
        {
            throw new NotImplementedException();
        }
    }
}
