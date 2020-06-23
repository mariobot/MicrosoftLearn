using System;
using System.Collections.Generic;
using System.Linq;
using MVVMEntityLayer;
using MVVMDataLayer;

namespace MVVMDataLayer
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

        public List<Product> Search(ProductSearch entity) 
        {
            List<Product> ret;
    
            // Perform Searching  
            ret = DbContext.Products.Where(p => 
                (entity.Name == null || p.Name.StartsWith(entity.Name)) && 
                p.ListPrice >= entity.ListPrice).ToList();
            return ret;
        }
    }
}