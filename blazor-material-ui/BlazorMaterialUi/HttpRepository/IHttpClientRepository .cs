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
        Task<string> UploadImage(MultipartFormDataContent content);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
        Task AddReview(Review review);
        Task AddQuestion(QA qa);
        Task AddDeclaration(Declaration declaration);
        Task<Declaration> GetDeclaration(Guid declarationId);
        Task UpdateDeclaration(Declaration declaration);
        Task DeleteDeclaration(Guid declarationId);
    }
}
