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

        public IEnumerable<Transaction> Get(string casherName)
        {
            if (string.IsNullOrEmpty(casherName))
            {
                return transactions;
            }
            else 
            {
                return transactions.Where(x => string.Equals(x.CashierName, casherName, StringComparison.OrdinalIgnoreCase));
                
            }
        }

        public IEnumerable<Transaction> GetByDay(string casherName, DateTime date)
        {
            if (string.IsNullOrEmpty(casherName))
            {
                return transactions.Where(x => x.TimeStamp.Date == date);
            }
            else
            {
                return transactions.Where(x => 
                    string.Equals(x.CashierName, casherName, StringComparison.OrdinalIgnoreCase) 
                    && x.TimeStamp.Date == date);

            }
        }

        public void Save(string cashierName,int productId, string productName, double price, int beforeQty, int soldQty)
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
                ProductName = productName,
                TimeStamp = DateTime.UtcNow,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            });
        }
    }
}
