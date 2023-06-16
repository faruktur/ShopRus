using ShopRus.InvoiceService.Domain.Models;
using ShopRus.InvoiceService.Infrastructure.Interface;

namespace ShopRus.InvoiceService.Infrastructure
{
    public class DiscountService : IDiscountService
    {
        private readonly IUserService _userService;
        private readonly IInvoiceService _invoiceService;
        public DiscountService(IUserService userService,IInvoiceService invoiceService)
        {
            _userService = userService; 
            _invoiceService = invoiceService;   
        }
        public decimal CalculateDiscount(InvoiceModel invoice)
        {
            decimal totalDiscount = 0;

            if (invoice.ShopType != ShopType.Market)
            {
                var customerInfo = _userService.GetUserByEmailAddress(invoice.Customer.Email);

                if (customerInfo.UserType == UserTypes.Employee)
                {
                    totalDiscount += 0.3m;
                }

                if (IsCustomerForYears(invoice.Customer, 2))
                {
                    totalDiscount += 0.1m;
                }

                if (customerInfo.UserType == UserTypes.Member)
                {
                    totalDiscount += 0.05m;
                }
            }

            decimal totalPrice = invoice.Products.Sum(p => GetTotalPriceByProduct(p));
            decimal finalDiscount = totalPrice * totalDiscount;

            return finalDiscount;
        }
        private decimal GetTotalPriceByProduct(ProductModel product)
        {
            return product.Quantity * product.Price;
        }
        private bool IsCustomerForYears(CustomerModel customer,int year)
        {
            var customerInvoices = _invoiceService.GetInvoicesByCustomer(customer).ToList();
            bool isCustomer =  customerInvoices.FirstOrDefault(ci => ci.InvoiceDate < DateTime.Now.AddYears(-year)) != null;
            return isCustomer;
        }
    }
}
