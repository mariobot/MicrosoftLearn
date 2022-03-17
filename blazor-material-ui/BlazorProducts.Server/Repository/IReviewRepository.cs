using Entities.Models;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public interface IReviewRepository
    {
        Task AddReview(Review review);
    }
}
