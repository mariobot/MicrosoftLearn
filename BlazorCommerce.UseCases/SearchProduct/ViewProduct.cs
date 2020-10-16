using BlazorCommerce.CoreBusiness.Models;
using BlazorCommerce.UseCases.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCommerce.UseCases.SearchProduct
{
    public class ViewProduct : IViewProduct
    {
        private readonly IProductRepository productRepository;

        public ViewProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Execute(int id)
        {
            return productRepository.GetProduct(id);
        }
    }
}
