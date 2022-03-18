using BlazorMaterialUi.HttpRepository;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorMaterialUi.Components
{
    public partial class AddReviewBox
    {
        public Review _review { get; set; } = new Review();
        [Parameter]
        public string productId { get; set; }
        [Parameter]
        public EventCallback<bool> OnAddReview { get; set; }

        [Inject]
        private IHttpClientRepository Repository { get; set; }


        protected override void OnInitialized()
        {   
            _review.Rate = 0;
            base.OnInitialized();
        }

        private async Task Create()
        {
            Guid id;
            Guid.TryParse(productId, out id);
            _review.ProductId = id;
            await Repository.AddReview(_review);
            await OnAddReview.InvokeAsync(true);
        }

        private void RatingValueChanged(int value) => _review.Rate = value;
    }
}
