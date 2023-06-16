using ShopRus.InvoiceService.Domain.Models;

namespace ShopRus.InvoiceService.Infrastructure
{
    public class SeedData
    {

        public static List<InvoiceModel> Invoices
        {
            get
            {
                return new List<InvoiceModel>()
                {
                    new InvoiceModel()
                    {
                        Products=GetRandomProducts(),
                        Customer=new CustomerModel()
                        {
                            Email="user1",
                            UserType=UserTypes.Member
                        },
                        InvoiceDate=DateTime.Now.AddYears(-3),
                        ShopType=ShopType.Online
                    },
                    new InvoiceModel()
                    {
                        Products=GetRandomProducts(),
                        Customer=new CustomerModel()
                        {
                            Email="user1",
                            UserType=UserTypes.Member
                        },
                        InvoiceDate=DateTime.Now.AddYears(-1),
                        ShopType=ShopType.Online
                    },
                    new InvoiceModel()
                    {
                        Products=GetRandomProducts(),
                        Customer=new CustomerModel()
                        {
                            Email="user2",
                            UserType=UserTypes.Employee
                        },
                        InvoiceDate=DateTime.Now.AddYears(-1),
                        ShopType=ShopType.Online
                    },
                    new InvoiceModel()
                    {
                        Products=GetRandomProducts(),
                        Customer=new CustomerModel()
                        {
                            Email="user3",
                            UserType=UserTypes.Employee
                        },
                        InvoiceDate=DateTime.Now.AddYears(-5),
                        ShopType=ShopType.Online
                    },
                };
            }
        }
        public static List<CustomerModel> Customers
        {
            get
            {
                return new List<CustomerModel>()
                {
                    new CustomerModel()
                    {
                        Email="user1",
                        UserType=UserTypes.Member
                    },
                    new CustomerModel()
                    {
                        Email="user2",
                        UserType=UserTypes.Employee
                    },new CustomerModel()
                    {
                        Email="user3",
                        UserType=UserTypes.Employee
                    }
                };
            }
        }

        private static List<ProductModel> GetRandomProducts()
        {
            var list = new List<ProductModel>();
            int count = new Random().Next(1, 10);
            for (int i = 0; i < count; i++)
            {
                list.Add(GenerateDummyProduct());
            }
            return list;
        }
        private static ProductModel GenerateDummyProduct()
        {
            return new ProductModel()
            {
                Name = $"Product {new Random().Next(0, 100)}",
                Price = new Random().NextInt64(2, 100),
                Quantity = new Random().Next(2, 100)
            };
        }

    }
}
