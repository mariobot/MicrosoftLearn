using BlazorProducts.Server.Context;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DatabaseContext _context;

        public TransactionRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddTransaction(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions.OrderBy(x => x.TimeStamp).ToList();
        }
    }
}
