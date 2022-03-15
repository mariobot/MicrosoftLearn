using BlazorMaterialUi.HttpRepository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorMaterialUi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped<IHttpClientRepository, HttpClientRepository>();

            builder.Services.AddScoped(sp => new HttpClient 
            { 
                BaseAddress = new Uri("https://localhost:5011/api/") 
            });

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
