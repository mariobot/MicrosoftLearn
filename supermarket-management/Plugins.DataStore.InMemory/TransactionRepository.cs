using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> transactions;

        public TransactionRepository()
        {
            transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> GetByDay(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Save(string cashierName,int productId, double price, int qty)
        {
            int maxId;
            if (transactions != null && transactions.Count > 0)
            {
                maxId = transactions.Max(x => x.TransactionId);
                maxId = maxId + 1;
            }
            else {
                maxId = 1;
            }

            transactions.Add(new Transaction()
            {
                TransactionId = maxId,
                ProductId = productId,
                TimeStamp = DateTime.UtcNow,
                Price = price,
                Qty = qty,
                CashierName = cashierName
            });
        }
    }
}
