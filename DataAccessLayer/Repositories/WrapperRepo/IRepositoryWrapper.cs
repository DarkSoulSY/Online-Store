using DataAccessLayer.Repositories.CartRepo;
using DataAccessLayer.Repositories.CategoryRepo;
using DataAccessLayer.Repositories.ItemRepo;
using DataAccessLayer.Repositories.ItemSizePriceOrderRepo;
using DataAccessLayer.Repositories.ItemSizePriceRepo;
using DataAccessLayer.Repositories.OrderRepo;
using DataAccessLayer.Repositories.PermissionRepo;
using DataAccessLayer.Repositories.PictureRepo;
using DataAccessLayer.Repositories.RolePermissionRepo;
using DataAccessLayer.Repositories.RoleRepo;
using DataAccessLayer.Repositories.SizeRepo;
using DataAccessLayer.Repositories.StatusRepo;
using DataAccessLayer.Repositories.UserRepo;

namespace DataAccessLayer.Repositories.WrapperRepo
{
    public interface IRepositoryWrapper
    {
        ICartRepository Cart { get; }
        ICategoryRepository Category { get; }
        IItemRepository Item { get; }
        IItemSizePriceRepository ItemSizePrice { get; }
        IItemSizePriceOrderRepository ItemSizePriceOrder { get; }
        IOrderRepository Order { get; }
        IPermissionRepository Permission { get; }
        IPictureRepository Picture { get; }
        IRoleRepository Role { get; }
        ISizeRepository Size { get; }
        IStatusRepository Status { get; }
        IUserRepository User { get; }                
        IUserRoleRepository UserRole { get; }                                       
        
        Task SaveAsync();

    }
}
