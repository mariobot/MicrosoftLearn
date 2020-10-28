using AspCore.DataAccess;
using AspCore.Domain.DTO;
using AspCore.Domain.Mapper;
using AspCore.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.Service.ProductRepo
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Create(ProductDTO product)
        {
            Product newProduct = product.MapTo<Product>();
            context.Add(newProduct);
            await context.SaveChangesAsync();
        }

        public void Update(ProductDTO product)
        {
            Product _product = product.MapTo<Product>();
            context.Entry(_product).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product _product = context.Products.FirstOrDefault(x => x.Id == id);
            context.Remove(_product);
            context.SaveChanges();
        }

        public ProductDTO GetById(int id)
        {
            Product _product = context.Products.FirstOrDefault(x => x.Id == id);
            return _product.MapTo<ProductDTO>();
        }

        public IEnumerable<ProductDTO> GetList()
        {
            List<Product> listProduct = context.Products.ToList();
            return listProduct.MapTo<List<ProductDTO>>();
        }
    }
}
