using ShopRus.InvoiceService.Domain.Models;
using ShopRus.InvoiceService.Infrastructure.Interface;

namespace ShopRus.InvoiceService.Infrastructure
{
    public class UserService : IUserService
    {
        
        public UserService()
        {
            
        }
        public CustomerModel GetUserByEmailAddress(string email)
        {
            return SeedData.Customers.FirstOrDefault(u => u.Email == email);
        }
    }
}
