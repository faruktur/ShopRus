using ShopRus.UserService.Domain.Models;

namespace ShopRus.UserService.Infrastructure.Services.Interface
{
    public interface IUserLoginService
    {
        SignInResponseModel SignIn(string email, string password);
    }
}
