using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions;

        public TransactionInMemoryRepository()
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
                return transactions.Where(x => string.Equals(x.CashierName, casherName, StringComparison.OrdinalIgnoreCase)).ToList();
                
            }
        }

        public IEnumerable<Transaction> GetByDay(string casherName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(casherName))
            {
                return transactions.Where(x => x.TimeStamp.Date == date).ToList();
            }
            else
            {
                return transactions.Where(x =>
                    string.Equals(x.CashierName, casherName, StringComparison.OrdinalIgnoreCase)
                    && x.TimeStamp.Date == date.Date).ToList();
            }
        }

        public IEnumerable<Transaction> GetByDayRange(string casherName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(casherName))
            {
                return transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.AddDays(1).Date).ToList();
            }
            else
            {
                return transactions.Where(x =>
                    string.Equals(x.CashierName, casherName, StringComparison.OrdinalIgnoreCase)
                    && x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.AddDays(1).Date).ToList();
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
