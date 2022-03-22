using BlazorProducts.Server.Context;
using Entities.Models;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public class QARepository : IQARepository
    {
        private readonly DatabaseContext _context;

        public QARepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddQuestion(QA qa)
        {
            await _context.QAs.AddAsync(qa);
            await _context.SaveChangesAsync();
        }
    }
}
