using ShopRus.InvoiceService.Domain.Models;

namespace ShopRus.InvoiceService.Infrastructure.Interface
{
    public interface IUserService
    {
        CustomerModel GetUserByEmailAddress(string email);
    }
}
