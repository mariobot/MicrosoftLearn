using BlazorCommerce.CoreBusiness.Models;
using BlazorCommerce.UseCases.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCommerce.UseCases.SearchProduct
{
    public class OrderView : IOrderView
    {
        private readonly IProductRepository productRepository;

        public OrderView(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return productRepository.GetOrders();
        }
    }
}
