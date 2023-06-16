namespace ShopRus.UserService.Domain.Models
{
    public class UserSignedInViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime RegistrationDate { get; set; }

        public UserTypeSignedInViewModel UserType { get; set; }
    }
    public class UserTypeSignedInViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SignInResponseModel
    {
        public SignInResponseModel()
        {
            Errors = new List<string>();
        }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; }

        public string AccessToken { get; set; }
        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
    public class SignInRequestModel 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
