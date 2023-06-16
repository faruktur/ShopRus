using ShopRus.InvoiceService.Domain.Models;

namespace ShopRus.InvoiceService.Infrastructure.Interface
{
    public interface IInvoiceService
    {
        List<InvoiceModel> GetInvoicesByCustomer(CustomerModel customer);
    }
}
