using BlazorMaterialUi.HttpRepository;
using BlazorMaterialUi.Shared;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Threading.Tasks;

namespace BlazorMaterialUi.Pages
{
    public partial class UpdateProduct
    {
        [Parameter]
        public string productId { get; set; }

        private Product _product = new Product();
        private DateTime? _date = DateTime.Today;
        
        [Inject]
        public IHttpClientRepository Repository { get; set; }
        [Inject]
        public IDialogService Dialog { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Guid id;
            Guid.TryParse(productId, out id);
            _product = await Repository.GetProduct(id);
        }

        private async Task Update()
        {
            _product.ManufactureDate = (DateTime)_date;
            await Repository.UpdateProduct(_product);
            await ExecuteDialogAsync();
        }

        private async Task ExecuteDialogAsync()
        {
            var parameters = new DialogParameters
            {
                { "Content", "You have succesfully update the product."},
                { "ButtonColor", Color.Primary },
                { "ButtonText", "OK" }
            };

            var dialog = Dialog.Show<DialogNotification>("Product updated", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                bool.TryParse(result.Data.ToString(), out bool shouldNavigate);
                if (shouldNavigate)
                    NavigationManager.NavigateTo("/fetchdata");
            }
        }

        public void SetImgUrl(string imgUrl) => _product.ImageUrl = imgUrl;

        private async Task ExecuteDeleteDeclarationAsync()
        {
            var parameters = new DialogParameters
            {
                { "Content", "You sure what to delete declaration information."},
                { "ButtonColor", Color.Error },
                { "ButtonText", "Delete" }
            };

            var dialog = Dialog.Show<DialogNotification>("Delete declaration", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Repository.DeleteDeclaration(_product.Declaration.Id);
                bool.TryParse(result.Data.ToString(), out bool shouldNavigate);
                if (shouldNavigate)
                    NavigationManager.NavigateTo("/fetchdata");
            }
        }
    }
}
