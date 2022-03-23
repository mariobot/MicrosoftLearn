using Entities.Models;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    interface IDeclarationRepository
    {
        Task AddDeclaration(Declaration declaration);
    }
}
