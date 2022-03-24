using Entities.Models;
using System;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public interface IDeclarationRepository
    {
        Task AddDeclaration(Declaration declaration);
        Task<Declaration> GetDeclaration(Guid declarationId);
        Task UpdateDeclaration(Declaration declaration);
        Task DeleteDeclaration(Guid declarationId);
    }
}
