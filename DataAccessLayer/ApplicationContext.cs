using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRoleEntity> UserRoleEntities => Set<UserRoleEntity>();
    }
}
