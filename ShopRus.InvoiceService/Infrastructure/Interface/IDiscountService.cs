using ShopRus.InvoiceService.Domain.Models;

namespace ShopRus.InvoiceService.Infrastructure.Interface
{
    public interface IDiscountService
    {
        decimal CalculateDiscount(InvoiceModel invoice);
    }
}
