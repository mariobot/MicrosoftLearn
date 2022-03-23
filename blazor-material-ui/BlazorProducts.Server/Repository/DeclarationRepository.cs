using BlazorProducts.Server.Context;
using Entities.Models;
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
    }
}
