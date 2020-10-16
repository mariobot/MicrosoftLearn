using BlazorCommerce.CoreBusiness.Models;

namespace BlazorCommerce.UseCases.SearchProduct
{
    public interface IViewProduct
    {
        Product Execute(int id);
    }
}