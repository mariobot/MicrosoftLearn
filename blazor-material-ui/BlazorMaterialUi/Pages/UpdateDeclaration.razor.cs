using BlazorMaterialUi.HttpRepository;
using BlazorMaterialUi.Shared;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Threading.Tasks;

namespace BlazorMaterialUi.Pages
{
    public partial class UpdateDeclaration
    {
        [Parameter]
        public string declarationId { get; set; }

        public Declaration _declaration { get; set; } = new Declaration();

        [Inject]
        public IHttpClientRepository Repo { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Guid _declarationId;
            Guid.TryParse(declarationId, out _declarationId);
            _declaration = await Repo.GetDeclaration(_declarationId);
        }

        public async Task Update()
        {
            await Repo.UpdateDeclaration(_declaration);
            await ExecuteDialogAsync();
        }

        private async Task ExecuteDialogAsync()
        {
            var parameters = new DialogParameters
            {
                { "Content", "You have succesfully update declaration."},
                { "ButtonColor", Color.Primary },
                { "ButtonText", "OK" }
            };

            var dialog = Dialog.Show<DialogNotification>("Declaration updated", parameters);
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
