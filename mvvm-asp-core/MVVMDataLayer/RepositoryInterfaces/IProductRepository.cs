using System.Collections.Generic;
using MVVMEntityLayer;

namespace MVVMDataLayer.RepositoryInterfaces
{
    public interface IProductRepository
    {
        List<Product> Get();
    }
}