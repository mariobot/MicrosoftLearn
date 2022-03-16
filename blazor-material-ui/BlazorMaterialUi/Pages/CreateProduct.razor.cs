using BlazorMaterialUi.HttpRepository;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorMaterialUi.Pages
{
    public partial class CreateProduct
    {
        private Product _product = new Product();
        private DateTime? _date = DateTime.Today;
        [Inject]
        public IHttpClientRepository Repository { get; set; }
        private async Task Create()
        {
            _product.ManufactureDate = (DateTime)_date;
            await Repository.CreateProduct(_product);
        }
    }
}
