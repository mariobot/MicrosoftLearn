using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVVMDataLayer;
using MVVMViewModelLayer;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using MVVMEntityLayer;
using Newtonsoft.Json;

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
            _viewModel.SortExpression = "Name";
            _viewModel.EventCommand = "sort";
            _viewModel.Pager.PageSize = 5;
            _viewModel.HandleRequest();
            HttpContext.Session.SetString("Products", JsonConvert.SerializeObject(_viewModel.AllProducts));
            return View(_viewModel);
        }

        [HttpPost]
        public IActionResult Products(ProductViewModel vm)
        {
            vm.Repository = _repo;
            vm.Pager.PageSize = 5;
            vm.HandleRequest();
            vm.AllProducts = JsonConvert.DeserializeObject<List<Product>>(HttpContext.Session.GetString("Products"));
            ModelState.Clear();
            return View(vm);
        }
    }
}