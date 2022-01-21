using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public Product GetProductById(int productId);
    }
}
