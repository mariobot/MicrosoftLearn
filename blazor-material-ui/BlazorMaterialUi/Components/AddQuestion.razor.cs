using BlazorMaterialUi.HttpRepository;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorMaterialUi.Components
{
    public partial class AddQuestion
    {
        public QA _qa { get; set; } = new QA();
        [Parameter]
        public string productId { get; set; }
        [Parameter]
        public EventCallback<bool> OnAddQuestion { get; set; }

        [Inject]
        private IHttpClientRepository Repository { get; set; }

        private async Task CreateQuestion()
        {
            Guid _productId;
            Guid.TryParse(productId, out _productId);
            _qa.ProductId = _productId;
            await Repository.AddQuestion(_qa);
            await this.OnAddQuestion.InvokeAsync(true);
        }
    }
}
