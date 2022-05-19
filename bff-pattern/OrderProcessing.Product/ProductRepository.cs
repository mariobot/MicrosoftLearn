using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderProcessing.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>();

        public ProductRepository()
        {
            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Mobile",
                Quantity = 25,
                Price = 90000
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Motorola Mobile",
                Quantity = 50,
                Price = 65000
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = "OnePlus Mobile",
                Quantity = 15,
                Price = 55000
            });
        }

        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(products);
        }
    }
}
