using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVVMDataLayer;
using MVVMViewModelLayer;

namespace MVVMSample.Controllers
{
    public class ProductController : Controller 
    {
        private readonly IProductRepository _repo;    
        private readonly ProductViewModel _viewModel;
        
        public ProductController(IProductRepository repo, ProductViewModel vm)    
        {      
            _repo = repo;      
            _viewModel = vm;
        }
        
        public IActionResult Products()
        {
            // Load products
            _viewModel.HandleRequest();
            return View(_viewModel);    
        }          
    }
}