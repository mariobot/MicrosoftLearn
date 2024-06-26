using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plugins.DataStore.InMemory;
using UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using UseCases;
using Plugins.DataStore.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            var enableInMemory = Configuration.GetValue<bool>("EnableInMemory");

            if (enableInMemory)
            {
                // Dependency Injection for InMemory Data store
                services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
                services.AddScoped<IProductRepository, ProductInMemoryRepository>();
                services.AddScoped<ITransactionRepository, TransactionInMemoryRepository>();

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("AdminOnly", p => p.RequireAssertion(_ => true));
                    options.AddPolicy("CashierOnly", p => p.RequireAssertion(_ => true));
                });
            }
            else
            {
                services.AddDbContext<MarketContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });

                // Dependency Injection for ef core Data store for SQL
                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddScoped<IProductRepository, ProductRespository>();
                services.AddScoped<ITransactionRepository, TransactionRepository>();

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
                    options.AddPolicy("CashierOnly", p => p.RequireClaim("Position", "Cashier"));
                });
            }

            // Dependency Injection for Use Cases
            services.AddScoped<IViewCategoriesUseCase, ViewCategoriesUseCase>();
            services.AddScoped<IAddCategoryUseCase, AddCategoryUseCase>();
            services.AddScoped<IEditCategoryUseCase, EditCategoryUseCase>();
            services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            services.AddScoped<IViewProductsUseCase, ViewProductsUseCase>();
            services.AddScoped<IAddProductUseCase, AddProductUseCase>();
            services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddScoped<IEditProductUseCase, EditProductUseCase>();
            services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddScoped<IViewProductByCategoryId, ViewProductByCategoryId>();
            services.AddScoped<ISellProductUseCase, SellProductUseCase>();
            services.AddScoped<IRecordTransactionUseCase, RecordTransactionUseCase>();
            services.AddScoped<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
            services.AddScoped<IGetTransactionsUseCase, GetTransactionsUseCase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
