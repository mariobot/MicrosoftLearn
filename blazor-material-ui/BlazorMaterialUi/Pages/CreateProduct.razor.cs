using BlazorMaterialUi.HttpRepository;
using BlazorMaterialUi.Shared;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
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
        [Inject]
        public IDialogService Dialog { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private async Task Create()
        {
            _product.ManufactureDate = (DateTime)_date;
            await Repository.CreateProduct(_product);
            await ExecuteDialogAsync();
        }

        private async Task ExecuteDialogAsync()
        {
            var parameters = new DialogParameters
            {
                { "Content", "You have succesfully created a new product."},
                { "ButtonColor", Color.Primary },
                { "ButtonText", "OK" }
            };

            var dialog = Dialog.Show<DialogNotification>("Product created", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                bool.TryParse(result.Data.ToString(), out bool shouldNavigate);
                if (shouldNavigate)
                    NavigationManager.NavigateTo("/fetchdata");
            }

        }

        public void SetImgUrl(string imgUrl) => _product.ImageUrl = imgUrl;
    }
}
