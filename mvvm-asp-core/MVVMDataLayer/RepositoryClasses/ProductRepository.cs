using System;
using System.Collections.Generic;
using System.Linq;
using MVVMEntityLayer;
using MVVMDataLayer.RepositoryInterfaces;

namespace MVVMDataLayer.RepositoryClasses
{
    public class ProductRepository : IProductRepository 
    {
        public ProductRepository(AdvWorksDbContext context)    
        {      
            DbContext = context;    
        }
        
        private AdvWorksDbContext DbContext { get; set; }
        
        public List<Product> Get()
        {
            return DbContext.Products.ToList();
        } 
    }
}