using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;

        public ProductInMemoryRepository()
        {
            //Init with default values
            products = new List<Product>()
            {
                new Product(){ ProductId = 1, CategoryId = 1, Name = "Coca Cola", Price = 3000, Quantity = 20  },
                new Product(){ ProductId = 2, CategoryId = 1, Name = "Cerveza", Price = 5000, Quantity = 30  },
                new Product(){ ProductId = 3, CategoryId = 1, Name = "Agua", Price = 1500, Quantity = 50  },
                new Product(){ ProductId = 4, CategoryId = 2, Name = "Pan Tenza", Price = 6500, Quantity = 15  },
                new Product(){ ProductId = 5, CategoryId = 2, Name = "Tostadas Integrales", Price = 3500, Quantity = 25  },
                new Product(){ ProductId = 6, CategoryId = 2, Name = "Pan Frances", Price = 4500, Quantity = 32  },
                new Product(){ ProductId = 7, CategoryId = 3, Name = "Biffe Chorizo", Price = 10500, Quantity = 10  },
                new Product(){ ProductId = 8, CategoryId = 3, Name = "Solomo", Price = 11000, Quantity = 12  },
                new Product(){ ProductId = 9, CategoryId = 3, Name = "Baby Beaf", Price = 12000, Quantity = 15  }
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
        }

        public Product GetProductById(int productId)
        {
            return products?.FirstOrDefault(x => x.ProductId == productId);        
        }

        public void DeleteProduct(int productId)
        {
            products?.Remove(GetProductById(productId));
        }

        public IEnumerable<Product> GetProductByCategory(int categoryId)
        {
            return products?.Where(x => x.CategoryId == categoryId);
        }
    }
}
