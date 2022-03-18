using BlazorProducts.Server.Repository;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : Controller
    {
        private IReviewRepository _repo;
        public ReviewController(IReviewRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(Review review)
        {
            await _repo.AddReview(review);
            return Ok();
        }
    }
}
