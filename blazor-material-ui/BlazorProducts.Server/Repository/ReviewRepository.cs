using BlazorProducts.Server.Context;
using Entities.Models;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DatabaseContext _context;

        public ReviewRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }
    }
}
