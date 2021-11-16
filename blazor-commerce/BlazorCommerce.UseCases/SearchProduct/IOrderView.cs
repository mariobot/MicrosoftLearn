using BlazorCommerce.CoreBusiness.Models;
using System.Collections.Generic;

namespace BlazorCommerce.UseCases.SearchProduct
{
    public interface IOrderView
    {
        IEnumerable<Order> Execute();
    }
}