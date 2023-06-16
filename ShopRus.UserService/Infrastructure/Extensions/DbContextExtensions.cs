using Microsoft.EntityFrameworkCore;

namespace ShopRus.UserService.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static void AddUserDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
            {
                string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                string connectionString = configuration.GetConnectionString(environment);

                options.UseSqlServer(connectionString);
            });
        }
        public static void InitializeUsers(this IApplicationBuilder app, IConfiguration configuration)
        {
            // TODO DB Initializer Dummy Data
        }
    }
}
