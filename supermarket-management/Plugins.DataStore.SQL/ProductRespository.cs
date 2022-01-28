using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductRespository : IProductRepository
    {
        private readonly MarketContext db;

        public ProductRespository(MarketContext db)
        {
            this.db = db;
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null) return;

            db.Products.Remove(product);
            db.SaveChanges();
        }

        public IEnumerable<Product> GetProductByCategory(int categoryId)
        {
            return db.Products.Where(c => c.CategoryId == categoryId).ToList();
        }

        public Product GetProductById(int productId)
        {
            return db.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            var prod = db.Products.Find(product.ProductId);
            prod.CategoryId = product.CategoryId;
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            db.SaveChanges();
        }
    }
}
