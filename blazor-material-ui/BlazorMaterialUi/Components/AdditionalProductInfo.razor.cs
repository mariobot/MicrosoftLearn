using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorMaterialUi.Components
{
    public partial class AdditionalProductInfo
    {
        [Parameter]
        public Product Product { get; set; }
        [Parameter]
        public int ReviewCount { get; set; }
        [Parameter]
        public int QuestionCount { get; set; }
    }
}
