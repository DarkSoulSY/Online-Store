using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
