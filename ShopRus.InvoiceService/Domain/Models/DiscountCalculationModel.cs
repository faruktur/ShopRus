namespace ShopRus.InvoiceService.Domain.Models
{
    public class DiscountCalculationModel
    {
        public DiscountCalculationModel()
        {
            Discounts = new List<DiscountModel>();
        }
        public List<DiscountModel> Discounts { get;}
        public void AddDiscount(DiscountModel discount)
        {
            if(discount.Type!= DiscountType.Percentage || !Discounts.Any(d => d.Type == DiscountType.Percentage))
            {
                Discounts.Add(discount);
            }
        }
    }
}
