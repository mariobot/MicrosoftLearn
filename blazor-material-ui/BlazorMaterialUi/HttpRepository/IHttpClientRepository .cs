using BlazorMaterialUi.Features;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorMaterialUi.HttpRepository
{
    public interface IHttpClientRepository
    {
        Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters);
        Task<Product> GetProduct(Guid id);
        Task CreateProduct(Product product);
        Task<string> UploadImage(MultipartFormDataContent content);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
