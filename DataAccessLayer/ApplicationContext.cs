using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace DataAccessLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Status)
                .WithOne(s => s.Order)
                .HasForeignKey<Status>(s => s.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Status>()
                .Property(s => s.Submitted)
                .HasDefaultValue(false);


            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Cart)
                .HasForeignKey(o => o.CartId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.Username, u.PhoneNumber })
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PhoneNumber)
                .IsRequired();            

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }


        public DbSet<User> Users => Set<User>();
        public DbSet<Cart> Cart => Set<Cart>();
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
