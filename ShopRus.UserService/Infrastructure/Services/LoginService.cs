using Microsoft.IdentityModel.Tokens;
using ShopRus.UserService.Domain.Entities;
using ShopRus.UserService.Domain.Models;
using ShopRus.UserService.Infrastructure.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopRus.UserService.Infrastructure.Services
{
    public class LoginService : IUserLoginService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public LoginService(IUserService userService,IConfiguration configuration)
        {
            _userService = userService;
            _configuration= configuration;
        }
        public SignInResponseModel SignIn(string email, string password)
        {
            var user = _userService.GetUserByEmailAndPassword(email, password);
            var response= new SignInResponseModel()
            {
                Succeeded = false
            };
            if (user != null)
            {
                var accessToken = GetAccessToken(user);
                response.AccessToken = accessToken;
                response.Succeeded = true;
                return response;
            }
            else
            {
                response.AddError("You have entered an invalid username or password.");
                response.Succeeded = false;
            }
            return response;
        }
        private string GetAccessToken(UserEntity user)
        {
            var secret = _configuration["Jwt:Secret"];
            var secretBytes = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
               
             }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = "ShopRus",
                Audience = "ShopRus",
                SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(secretBytes),
            SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
