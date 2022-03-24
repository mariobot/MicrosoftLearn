using Entities.Models;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public interface IDeclarationRepository
    {
        Task AddDeclaration(Declaration declaration);
    }
}
