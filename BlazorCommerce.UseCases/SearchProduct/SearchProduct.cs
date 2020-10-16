using BlazorCommerce.CoreBusiness.Models;
using BlazorCommerce.UseCases.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCommerce.UseCases.SearchProduct
{
    public class SearchProduct : ISearchProduct
    {
        private readonly IProductRepository productRepository;

        public SearchProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(string filter)
        {
            return productRepository.GetProducts(filter);
        }
    }
}
