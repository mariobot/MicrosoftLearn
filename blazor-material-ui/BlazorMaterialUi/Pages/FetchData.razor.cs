using BlazorMaterialUi.HttpRepository;
using BlazorMaterialUi.Shared;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMaterialUi.Pages
{
    public partial class FetchData
    {
        private MudTable<Product> _table;
        private ProductParameters _productParameters = new ProductParameters();
        private readonly int[] _pageSizeOption = { 4, 6, 10 };
        public List<Product> Products { get; set; } = new List<Product>();

        [Inject]
        public IHttpClientRepository Repository { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }

        private async Task<TableData<Product>> GetServerData(TableState state)
        {
            _productParameters.PageSize = state.PageSize;
            _productParameters.PageNumber = state.Page + 1;

            _productParameters.OrderBy = state.SortDirection == SortDirection.Descending ?
                state.SortLabel + " desc" :
                state.SortLabel;

            var response = await Repository.GetProducts(_productParameters);

            return new TableData<Product>
            {
                Items = response.Items,
                TotalItems = response.MetaData.TotalCount
            };
        }

        private void OnSearch(string searchTerm)
        {
            _productParameters.SearchTerm = searchTerm;
            _table.ReloadServerData();
        }

        private async Task RemoveDialogAsync(Guid productId)
        {
            var parameters = new DialogParameters
            {
                { "Content", "Are you sure to delete this product?"},
                { "ButtonColor", Color.Error },
                { "ButtonText", "Delete" }
            };

            var dialog = Dialog.Show<DialogNotification>("Remove product", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Repository.DeleteProduct(productId);
                bool.TryParse(result.Data.ToString(), out bool shouldNavigate);
                if (shouldNavigate)
                    Nav.NavigateTo("/fetchdata", true);
            }
        }
    }
}
