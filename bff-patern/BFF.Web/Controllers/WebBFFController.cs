using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BFF.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebBFFController : ControllerBase
    {
        [HttpGet("GetAllProducts")]
        public async Task<List<ProductDTO>> GetAllProducts()
        {
            return await GetAllProductsInternal();
        }

        private async Task<List<ProductDTO>>
        GetAllProductsInternal()
        {
            string baseURL = "https://localhost:44347/api/";
            string url = baseURL + "Product/GetAllProducts";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync(url))
                {
                    using (HttpContent content = responseMessage.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        return JsonSerializer.Deserialize<List<ProductDTO>>(data, options);
                    }
                }
            }
        }
    }
}
