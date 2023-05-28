using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.RoleRepo
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        Task<List<Role>>GetAllRoles();
        Task<Role?> GetSingleRole(Expression<Func<Role, bool>> expression);
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
            
    }
}
