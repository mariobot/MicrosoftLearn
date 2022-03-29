using BlazorProducts.Server.Repository;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Controllers
{
    [Route("api/declarations")]
    [ApiController]
    public class DeclarationsController : Controller
    {
        private readonly IDeclarationRepository _repo;

        public DeclarationsController(IDeclarationRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{declarationId}")]
        public async Task<IActionResult> GetDeclaration(Guid declarationId)
        {
            var declaration = await _repo.GetDeclaration(declarationId);            
            return Ok(declaration);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeclaration(Declaration declaration)
        {
            await _repo.AddDeclaration(declaration);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDeclaration(Declaration declaration)
        {
            await _repo.UpdateDeclaration(declaration);
            return Ok();
        }

        [HttpDelete("{declarationId}")]
        public async Task<IActionResult> UpdateDeclaration(Guid declarationId)
        {
            await _repo.DeleteDeclaration(declarationId);
            return Ok();
        }
    }
}
