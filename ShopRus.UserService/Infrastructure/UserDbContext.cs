using Microsoft.EntityFrameworkCore;
using ShopRus.UserService.Domain.Entities;
using ShopRus.UserService.Infrastructure.EntityConfigurations;

namespace ShopRus.UserService.Infrastructure
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserTypeEntity> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
