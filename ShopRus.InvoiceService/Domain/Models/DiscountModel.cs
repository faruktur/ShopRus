namespace ShopRus.InvoiceService.Domain.Models
{
    public class DiscountModel
    {
        public decimal Discount { get; set; }
        public DiscountType Type { get; set; } 
    }
    public enum DiscountType 
    {
        Percentage,
        TotalPrice
    }
}
