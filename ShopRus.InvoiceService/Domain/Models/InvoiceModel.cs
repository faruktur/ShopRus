namespace ShopRus.InvoiceService.Domain.Models
{
    public class InvoiceModel
    {
        public CustomerModel Customer { get; set; }
        public List<ProductModel> Products { get; set; }

        public DateTime InvoiceDate { get; set; }

        public ShopType ShopType { get; set; }
    }
}
