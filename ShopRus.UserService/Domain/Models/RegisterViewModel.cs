using ShopRus.UserService.Domain.Entities;

namespace ShopRus.UserService.Domain.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
    public class RegistrationResponseModel
    {
        public RegistrationResponseModel()
        {
            Errors = new List<string>();
        }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get;}

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
