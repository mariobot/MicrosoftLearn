using Entities.Models;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public interface IQARepository
    {
        Task AddQuestion(QA qa);
    }
}
