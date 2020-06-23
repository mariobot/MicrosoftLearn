using System;
using System.Collections.Generic;
using System.Linq;
using MVVMDataLayer;
using MVVMEntityLayer;

namespace MVVMViewModelLayer
{
   public class ProductViewModel : ViewModelBase  
    {   
        // property to hold the search fields
        public ProductSearch SearchEntity { get; set; }

        /// <summary>
        /// NOTE: You need a parameterless     
        /// constructor for post-backs in MVC    
        /// </summary>
        public ProductViewModel() : base()
        { 
            SearchEntity = new ProductSearch();
        }
        
        public ProductViewModel(IProductRepository repository) : base()    
        {      
            Repository = repository;
            SearchEntity = new ProductSearch();    
        }
        
        public IProductRepository Repository { get; set; }    
        public List<Product> Products { get; set; }
        
        public override void HandleRequest()    
        {
            switch (EventCommand.ToLower()) 
            {    
                case "search":
                    SearchProducts();
                    break;
                default:
                    LoadProducts();
                    break;
            }                  
        }
        
        protected virtual void LoadProducts()    
        {
            if(Repository == null) 
            {
                throw new ApplicationException("Must set the Repository property.");      
            }      
            else
            {        
                Products = Repository.Get().OrderBy(p => p.Name).ToList();      
            }   
        }

        public virtual void SearchProducts()
        {
            if (Repository == null)
            {
                throw new ApplicationException("Must set the Repository property.");  
            }  
            else 
            {    
                Products = Repository.Search(SearchEntity).OrderBy(p => p.Name).ToList();
            }
        }  
    }
}