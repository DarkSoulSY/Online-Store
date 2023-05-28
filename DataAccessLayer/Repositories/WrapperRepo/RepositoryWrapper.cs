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
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _context;
        private IUserRepository? _user;
        private IRoleRepository? _role;
        private IPermissionRepository? _permission;
        private IUserRoleRepository? _userRole;
        private ICartRepository? _cart;
        private ICategoryRepository? _category;
        private IItemRepository? _item;
        private IOrderRepository? _order;
        private IPictureRepository? _picture;
        private IStatusRepository? _status;

        public RepositoryWrapper(ApplicationContext context)
        {
            _context = context;        
        }

        public IUserRoleRepository UserRole
        {
            get
            {
                if (_userRole == null)
                {
                    _userRole = new UserRoleRepository(_context);
                }
                return _userRole;
            }
        }

        public IPictureRepository Picture
        {
            get
            {
                if (_picture == null)
                {
                    _picture = new PictureRepository(_context);
                }
                return _picture;
            }
        }

        public ICartRepository Cart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new CartRepository(_context);
                }
                return _cart;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_context);
                }
                return _category;
            }
        }

        public IItemRepository Item
        {
            get
            {
                if (_item == null)
                {
                    _item = new ItemRepository(_context);
                }
                return _item;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_context);
                }
                return _order;
            }
        }        

        public IStatusRepository Status
        {
            get
            {
                if(_status == null)
                {
                    _status = new StatusRepository(_context);
                }
                return _status;
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
