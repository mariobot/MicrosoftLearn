using System;
using System.Collections.Generic;
using System.Linq;
using MVVMDataLayer;
using MVVMEntityLayer;
using CommonLibrary.PagerClasses;

namespace MVVMViewModelLayer
{
   public class ProductViewModel : ViewModelBase  
    {   
        // property to hold the search fields
        public ProductSearch SearchEntity { get; set; }
        public int TotalProducts { get; set; }
        public List<Product> AllProducts { get; set; }

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
                    Pager.PageIndex = 0;
                    SortProducts();
                    PageProducts();
                    break;
                case "sort":
                case "page":
                    SortProducts();
                    PageProducts();
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
            if (AllProducts == null)
            {
                if (Repository == null)
                {
                    throw new ApplicationException("Must set the Repository property.");
                }
                else
                {
                    // Get data from Repository
                    AllProducts = Repository.Search(SearchEntity).OrderBy(p => p.Name).ToList();
                }
            }

            // Get data for the Products collection  
            Products = AllProducts.Where(p => (SearchEntity.Name == null || p.Name.StartsWith(SearchEntity.Name)) && p.ListPrice >= SearchEntity.ListPrice).ToList();
        }

        protected virtual void SortProducts()
        {
            // Search for Products  
            SearchProducts();

            if (EventCommand == "sort")
            {
                // Set sort direction
                SetSortDirection();
            }

            // Determine sort direction  
            bool isAscending = SortDirection == "asc";

            // What field should we sort on?  
            switch (SortExpression.ToLower())
            {
                case "name":
                    if (isAscending)
                    {
                        Products = Products.OrderBy(p => p.Name).ToList();
                    }
                    else
                    {
                        Products = Products.OrderByDescending(p => p.Name).ToList();
                    }
                    break;

                case "productnumber":
                    if (isAscending)
                    {
                        Products = Products.OrderBy(p => p.ProductNumber).ToList();
                    }
                    else
                    {
                        Products = Products.OrderByDescending(p => p.ProductNumber).ToList();
                    }
                    break;

                case "standardcost":
                    if (isAscending)
                    {
                        Products = Products.OrderBy(p => p.StandardCost).ToList();
                    }
                    else
                    {
                        Products = Products.OrderByDescending(p => p.StandardCost).ToList();
                    }
                    break;

                case "listprice":
                    if (isAscending)
                    {
                        Products = Products.OrderBy(p => p.ListPrice).ToList();
                    }
                    else
                    {
                        Products = Products.OrderByDescending(p => p.ListPrice).ToList();
                    }
                    break;
            }
        }
        protected virtual void PageProducts()
        {
            TotalProducts = Products.Count;
            base.SetPagerObject(TotalProducts);
            Products = Products.Skip(base.Pager.PageIndex * base.Pager.PageSize).Take(base.Pager.PageSize).ToList();
        }

    }
}