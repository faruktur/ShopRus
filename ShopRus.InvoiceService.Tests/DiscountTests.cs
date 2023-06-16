using NSubstitute;
using ShopRus.InvoiceService.Domain.Models;
using ShopRus.InvoiceService.Infrastructure;
using ShopRus.InvoiceService.Infrastructure.Interface;

namespace ShopRus.InvoiceService.Tests
{
    public class Tests
    {
        


       

        [Test]
        public void UserIsMember_DiscountCalculation()
        {
            //arrange
            var request = new InvoiceModel()
            {
                Customer=new CustomerModel()
                {
                    Email="someEmail",
                    UserType="Member"
                },
                Products=new List<ProductModel>()
                {
                    new ProductModel()
                    {
                        Name="some product name",
                        Price=1,
                        Quantity=1
                    },
                    new ProductModel()
                    {
                        Name="some product name",
                        Price=2,
                        Quantity=2
                    }
                },
                ShopType=ShopType.Online
            };
            var userServiceStub = Substitute.For<IUserService>();
            var invoiceServiceStub = Substitute.For<IInvoiceService>();
            var target = new DiscountService(userServiceStub, invoiceServiceStub);

            userServiceStub.GetUserByEmailAddress(Arg.Any<string>()).Returns(new CustomerModel()
            {
                Email = "someUser",
                // TODO : User Types Static - get from provider
                UserType="Member"
            });
            invoiceServiceStub.GetInvoicesByCustomer(request.Customer).Returns(new List<InvoiceModel>()
            {
                
            });

            //act
            var result = target.CalculateDiscount(request);

            //assert
            var expectedDiscount = ((1 * 1) + (2 * 2))*0.05m; 
            Assert.AreEqual(expectedDiscount,result);
        }
        [Test]
        public void UserIsOldCostumer_DiscountCalculation()
        {
            //arrange
            var request = new InvoiceModel()
            {
                Customer = new CustomerModel()
                {
                    Email = "someEmail",
                    UserType = "Member"
                },
                Products = new List<ProductModel>()
                {
                    new ProductModel()
                    {
                        Name="some product name",
                        Price=1,
                        Quantity=1
                    },
                    new ProductModel()
                    {
                        Name="some product name",
                        Price=2,
                        Quantity=2
                    }
                },
                ShopType = ShopType.Online
            };
            var userServiceStub = Substitute.For<IUserService>();
            var invoiceServiceStub = Substitute.For<IInvoiceService>();
            var target = new DiscountService(userServiceStub, invoiceServiceStub);

            userServiceStub.GetUserByEmailAddress(Arg.Any<string>()).Returns(new CustomerModel()
            {
                Email = "someUser",
                // TODO : User Types Static - get from provider
                UserType = "Member"
            });
            invoiceServiceStub.GetInvoicesByCustomer(Arg.Any<CustomerModel>()).Returns(new List<InvoiceModel>()
            {
                new InvoiceModel()
                {
                    InvoiceDate=DateTime.Now.AddYears(-5)
                }
            });

            //act
            var result = target.CalculateDiscount(request);

            //assert
            var expectedDiscount = ((1 * 1) + (2 * 2)) * 0.1m;
            Assert.AreEqual(expectedDiscount, result);
        }
    }
}