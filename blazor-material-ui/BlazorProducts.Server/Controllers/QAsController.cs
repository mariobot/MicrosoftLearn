using BlazorProducts.Server.Repository;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Controllers
{
    [Route("api/qas")]
    [ApiController]
    public class QAsController : Controller
    {
        private IQARepository _repo;

        public QAsController(IQARepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(QA qa)
        {
            await _repo.AddQuestion(qa);
            return Ok();
        }
    }
}
