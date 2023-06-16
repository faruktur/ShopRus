using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ShopRus.UserService.Extensions
{
    public static class JwtExtensions
    {
        public static void AddJwtAuthentication(this IServiceCollection services,IConfiguration configuration)
        {
            var secret = Encoding.ASCII.GetBytes(configuration.GetSection("Jwt").GetValue<string>("Secret"));

            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Audience = "ShopRus";
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        IssuerSigningKey=new SymmetricSecurityKey(secret),
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

        }
    }
}
