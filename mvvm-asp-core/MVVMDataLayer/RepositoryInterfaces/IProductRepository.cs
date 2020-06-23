using System.Collections.Generic;
using MVVMEntityLayer;

namespace MVVMDataLayer
{
    public interface IProductRepository
    {
        List<Product> Get();

        List<Product> Search(ProductSearch entity);
    }
}