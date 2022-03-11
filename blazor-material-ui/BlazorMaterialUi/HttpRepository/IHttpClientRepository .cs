using BlazorMaterialUi.Features;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMaterialUi.HttpRepository
{
    public interface IHttpClientRepository
    {
        Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters);
    }
}
