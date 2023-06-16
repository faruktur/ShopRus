using ShopRus.InvoiceService.Domain.Models;
using ShopRus.InvoiceService.Infrastructure.Interface;

namespace ShopRus.InvoiceService.Infrastructure
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUserService _userService;
        public InvoiceService(IUserService userService)
        {
            _userService = userService;
        }
        public List<InvoiceModel> GetInvoicesByCustomer(CustomerModel customer)
        {
            var _customer = _userService.GetUserByEmailAddress(customer.Email);
            var invoices =  SeedData.Invoices.Where(i => i.Customer.Email == _customer.Email).ToList();
            return invoices;
        }
    }
}
