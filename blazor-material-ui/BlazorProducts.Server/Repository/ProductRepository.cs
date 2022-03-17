using BlazorProducts.Server.Context;
using BlazorProducts.Server.Paging;
using BlazorProducts.Server.Repository.RepositoryExtensions;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public class ProductRepository : IProductRepository
	{
		private readonly ProductContext _context;

		public ProductRepository(ProductContext context)
		{
			_context = context;
		}

		public async Task<PagedList<Product>> GetProducts(ProductParameters productParameters)
		{
			var products = await _context.Products
				.Search(productParameters.SearchTerm)
				.Sort(productParameters.OrderBy)
				.ToListAsync();

			return PagedList<Product>
				.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
		}

		public async Task<Product> GetProduct(Guid id) =>
			await _context.Products
			.Include(r => r.Reviews)
			.Include(q => q.QAs)
			.Include(d => d.Declaration)
			.SingleOrDefaultAsync(p => p.Id.Equals(id));

		public async Task InsertProduct(Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();		
		}

		public async Task UpdateProduct(Product product)
		{
			var originalProduct = await GetProduct(product.Id);
			originalProduct.ImageUrl = product.ImageUrl;
			originalProduct.ManufactureDate = product.ManufactureDate;
			originalProduct.Name = product.Name;
			originalProduct.Price = product.Price;
			originalProduct.Supplier = product.Supplier;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteProduct(Guid id)
		{
			var product = await GetProduct(id);
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
		}
	}
}
