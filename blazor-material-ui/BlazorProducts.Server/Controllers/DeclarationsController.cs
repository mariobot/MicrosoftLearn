using BlazorProducts.Server.Repository;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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
            this._repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddDeclaration(Declaration declaration)
        {
            await this._repo.AddDeclaration(declaration);
            return Ok();
        }
    }
}
