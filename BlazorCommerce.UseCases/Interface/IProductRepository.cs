using BlazorCommerce.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCommerce.UseCases.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(string filter);
        Product GetProduct(int id);
        void AddProduct(int Id, int Quantity);
        IEnumerable<Order> GetOrders();
    }
}
