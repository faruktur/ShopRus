using ShopRus.UserService.Domain.Entities;
using ShopRus.UserService.Domain.Models;
using ShopRus.UserService.Infrastructure.Services.Interface;

namespace ShopRus.UserService.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _userDbContext;
        public UserService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public UserEntity GetUserByEmailAndPassword(string email, string password)
        {
            UserEntity user = _userDbContext.Users.FirstOrDefault(user => user.Email == email && user.Password==password);
            bool userFound = user != null;
            if (!userFound)
            {
                throw new Exception("User not found");
            }
            return user;
        }
        public RegistrationResponseModel Register(RegisterViewModel register)
        {
            var response = new RegistrationResponseModel()
            {
                IsSuccess = false
            };

            if (IsUserExist(register))
            {
                string error = "This email is already registered for an account";
                response.AddError(error);
                response.IsSuccess = false;
                return response;
            }
            UserTypeEntity userType = _userDbContext.UserTypes.FirstOrDefault(ut => ut.Name== UserTypes.Member);
            UserEntity registerUser = new UserEntity()
            {
                Email = register.Email,
                Name = register.Name,
                Surname = register.Surname,
                Password = register.Password,
                IsMailConfirmed=false,
                ValidationKey=Guid.NewGuid().ToString(),
                CreateDate=DateTime.Now,
                UserTypeId=userType.Id,
                UserType= userType
            };
            _userDbContext.Users.Add(registerUser);
            try
            {
                bool isSuccess = _userDbContext.SaveChanges() > 0;
                response.IsSuccess = isSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }
        private bool IsUserExist(RegisterViewModel register)
        {
            UserEntity user = _userDbContext.Users.FirstOrDefault(user => user.Email == register.Email);
            bool userExist = user != null;
            return userExist;
        }
    }
}
