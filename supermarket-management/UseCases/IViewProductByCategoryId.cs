using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewProductByCategoryId
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}