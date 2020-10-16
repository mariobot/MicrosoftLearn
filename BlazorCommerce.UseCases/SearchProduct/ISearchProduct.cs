using BlazorCommerce.CoreBusiness.Models;
using System.Collections.Generic;

namespace BlazorCommerce.UseCases.SearchProduct
{
    public interface ISearchProduct
    {
        IEnumerable<Product> Execute(string filter);
    }
}