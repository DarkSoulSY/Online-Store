using DataAccessLayer.Repositories.CartRepo;
using DataAccessLayer.Repositories.CategoryRepo;
using DataAccessLayer.Repositories.ItemRepo;
using DataAccessLayer.Repositories.OrderRepo;
using DataAccessLayer.Repositories.PermissionRepo;
using DataAccessLayer.Repositories.PictureRepo;
using DataAccessLayer.Repositories.RolePermissionRepo;
using DataAccessLayer.Repositories.RoleRepo;
using DataAccessLayer.Repositories.StatusRepo;
using DataAccessLayer.Repositories.UserRepo;

namespace DataAccessLayer.Repositories.WrapperRepo
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        IPermissionRepository Permission { get; }
        IUserRoleRepository UserRole { get; }
        ICartRepository Cart { get; }
        ICategoryRepository Category { get; }
        IItemRepository Item { get; }
        IOrderRepository Order { get; }
        IPictureRepository Picture { get; }
        IStatusRepository Status { get; }
        Task SaveAsync();

    }
}
