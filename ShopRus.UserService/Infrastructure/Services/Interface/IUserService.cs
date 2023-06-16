using ShopRus.UserService.Domain.Entities;
using ShopRus.UserService.Domain.Models;

namespace ShopRus.UserService.Infrastructure.Services.Interface
{
    public interface IUserService
    {
        
        UserEntity GetUserByEmailAndPassword(string email, string password);

        RegistrationResponseModel Register(RegisterViewModel register);
    }
}
