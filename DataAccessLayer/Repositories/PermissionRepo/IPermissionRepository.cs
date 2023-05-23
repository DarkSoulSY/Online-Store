using DataAccessLayer.Models;
using System.Linq.Expressions;
namespace DataAccessLayer.Repositories.PermissionRepo
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAllPermissions();
        Task<Permission?> GetSinglePermission(Expression<Func<Permission, bool>> expression);
        void CreatePermission(Permission Permission);
        void UpdatePermission(Permission Permission);
        void DeletePermission(Permission Permission);
    }
}
