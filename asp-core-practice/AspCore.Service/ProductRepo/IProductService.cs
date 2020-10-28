using AspCore.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspCore.Service.ProductRepo
{
    public interface IProductService
    {
        Task Create(ProductDTO product);
        void Delete(int id);
        ProductDTO GetById(int id);
        IEnumerable<ProductDTO> GetList();
        void Update(ProductDTO product);
    }
}