using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Picture> Pictures => Set<Picture>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Size> Sizes => Set<Size>();
        public DbSet<ItemSizePrice> ItemSizePrices => Set<ItemSizePrice>();
        public DbSet<ItemSizePriceOrder> ItemSizePriceOrders => Set<ItemSizePriceOrder>();
        
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Status> Statuses=> Set<Status>();
        public DbSet<UserRole> UserRoleEntities => Set<UserRole>();
    }
}
