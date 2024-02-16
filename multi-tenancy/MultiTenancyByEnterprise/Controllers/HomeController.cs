using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenancyByEnterprise.Data;
using MultiTenancyByEnterprise.Entities;
using MultiTenancyByEnterprise.Models;
using System.Diagnostics;

namespace MultiTenancyByEnterprise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await ConstructModelHome();
            return View(model);
        }

        private async Task<HomeIndexViewModel> ConstructModelHome()
        {
            var products = await context.Products.ToListAsync();
            var countries = await context.Countries.ToListAsync();

            var model = new HomeIndexViewModel()
            {
                prodructs = products,
                contries = countries,
            };

            return model;
        }

        [HttpPost]
        public async Task<IActionResult> Index(Product product)
        {
            context.Add(product);
            await context.SaveChangesAsync();

            var model = await ConstructModelHome();
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}