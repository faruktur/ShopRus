using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopRus.InvoiceService.Domain.Models;
using ShopRus.InvoiceService.Infrastructure.Interface;

namespace ShopRus.InvoiceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ILogger _logger;
        public DiscountController(IDiscountService discountService, ILogger logger)
        {
            _discountService = discountService;
            _logger = logger;   
        }
        public IActionResult Calculate(InvoiceModel invoiceModel)
        {
            try
            {
                var discount = _discountService.CalculateDiscount(invoiceModel);
                
                return Ok(discount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest("An error occured");
            }
            
        }

    }
}
