using BlazorProducts.Server.Context;
using Entities.Models;
using System;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public class DeclarationRepository : IDeclarationRepository
    {
        private readonly DatabaseContext _context;

        public DeclarationRepository(DatabaseContext context)
        {
            this._context = context;
        }

        public async Task AddDeclaration(Declaration declaration)
        {
            await _context.Declarations.AddAsync(declaration);
            await _context.SaveChangesAsync();
        }

        public async Task<Declaration> GetDeclaration(Guid declarationId)
        {
            return await _context.Declarations.FindAsync(declarationId);
        }

        public async Task UpdateDeclaration(Declaration declaration)
        {
            var originalDeclaration = await GetDeclaration(declaration.Id);
            originalDeclaration.Model = declaration.Model;
            originalDeclaration.Origin = declaration.Origin;
            originalDeclaration.CustomerRights = declaration.CustomerRights;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDeclaration(Guid declarationId)
        {
            var declaration = await GetDeclaration(declarationId);
            _context.Declarations.Remove(declaration);
            await _context.SaveChangesAsync();
        }
    }
}
