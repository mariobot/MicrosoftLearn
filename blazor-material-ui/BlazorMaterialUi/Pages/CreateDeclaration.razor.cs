using BlazorMaterialUi.HttpRepository;
using BlazorMaterialUi.Shared;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Threading.Tasks;

namespace BlazorMaterialUi.Pages
{
    public partial class CreateDeclaration
    {
        public Declaration _declaration { get; set; } = new Declaration();

        [Parameter]
        public string productId { get; set; }

        [Inject]
        public IHttpClientRepository Repository { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async Task Create()
        {
            Guid _productId;
            Guid.TryParse(productId, out _productId);
            _declaration.ProductId = _productId;
            await Repository.AddDeclaration(_declaration);
            await ExecuteDialogAsync();
        }

        private async Task ExecuteDialogAsync()
        {
            var parameters = new DialogParameters
            {
                { "Content", "You have succesfully created declaration."},
                { "ButtonColor", Color.Primary },
                { "ButtonText", "OK" }
            };

            var dialog = Dialog.Show<DialogNotification>("Declaration created", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                bool.TryParse(result.Data.ToString(), out bool shouldNavigate);
                if (shouldNavigate)
                    NavigationManager.NavigateTo("/fetchdata");
            }
        }
    }
}
