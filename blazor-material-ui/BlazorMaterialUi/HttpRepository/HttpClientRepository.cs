﻿using BlazorMaterialUi.Features;
using Entities.Models;
using Entities.RequestFeatures;
using Entities.RequestParameters;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorMaterialUi.HttpRepository
{
    public class HttpClientRepository : IHttpClientRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public HttpClientRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<Product> GetProduct(Guid id)
        {
            var uri = $"products/{id}";

            using (var response = await _client.GetAsync(uri))
            {
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                var product = await JsonSerializer.DeserializeAsync<Product>(stream, _options);

                return product;
            }
        }

        public async Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = productParameters.PageNumber.ToString(),
                ["pageSize"] = productParameters.PageSize.ToString(),
                ["searchTerm"] = productParameters.SearchTerm ?? "",
                ["orderBy"] = productParameters.OrderBy ?? "name"
            };

            using (var response = await _client.GetAsync(QueryHelpers.AddQueryString("products", queryStringParam)))
            {
                response.EnsureSuccessStatusCode();

                var metaData = JsonSerializer
                    .Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options);

                var stream = await response.Content.ReadAsStreamAsync();

                var pagingResponse = new PagingResponse<Product>
                {
                    Items = await JsonSerializer.DeserializeAsync<List<Product>>(stream, _options),
                    MetaData = metaData
                };

                return pagingResponse;
            }
        }

        public async Task<string> UploadImage(MultipartFormDataContent content)
        {
            var postResult = await _client.PostAsync("upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            var imgUrl = Path.Combine("https://localhost:5011/", postContent);

            return imgUrl;
        }

        public async Task CreateProduct(Product product)
        {
            await _client.PostAsJsonAsync("products", product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _client.PutAsJsonAsync("products", product);
        }

        public async Task DeleteProduct(Guid id)
        {
            await _client.DeleteAsync($"products/{id}");
        }

        public async Task AddReview(Review review)
        {
            await _client.PostAsJsonAsync("reviews",review);
        }

        public async Task AddQuestion(QA qa)
        {
            await _client.PostAsJsonAsync("qas", qa);
        }

        public async Task AddDeclaration(Declaration declaration)
        {
            await _client.PostAsJsonAsync("declarations", declaration);
        }

        public async Task<Declaration> GetDeclaration(Guid declarationId)
        {
            var uri = $"declarations/{declarationId}";

            using (var response = await _client.GetAsync(uri))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                var declaration = await JsonSerializer.DeserializeAsync<Declaration>(stream, _options);
                return declaration;
            }
        }

        public async Task UpdateDeclaration(Declaration declaration)
        {
            await _client.PutAsJsonAsync("declarations", declaration);
        }

        public async Task DeleteDeclaration(Guid declarationId)
        {
            await _client.DeleteAsync($"declarations/{declarationId}");
        }

    }
}
