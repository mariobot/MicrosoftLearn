﻿using System;
using System.Threading.Tasks;
using BlazorProducts.Server.Repository;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorProducts.Server.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository _repo;

		public ProductsController(IProductRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] ProductParameters productParameters)
		{
			var products = await _repo.GetProducts(productParameters);
			Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct(Guid id)
		{
			var product = await _repo.GetProduct(id);
			return Ok(product);
		}

		[HttpPost]
		public async Task<IActionResult> InsertProduct(Product product)
		{
			await _repo.InsertProduct(product);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProduct(Product product)
		{
			await _repo.UpdateProduct(product);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(Guid id)
		{
			await _repo.DeleteProduct(id);
			return Ok();		
		}
	}
}