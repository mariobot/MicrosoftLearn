using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionRepository(MarketContext db)
        {
            this.db = db;
        }

        public IEnumerable<Transaction> Get(string casherName)
        {
            if (string.IsNullOrEmpty(casherName))
            {
                return db.Transactions.ToList();
            }
            else
            {
                return db.Transactions.Where(x => string.Equals(x.CashierName, casherName, StringComparison.OrdinalIgnoreCase)).ToList();

            }
        }

        public IEnumerable<Transaction> GetByDay(string casherName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(casherName))
            {
                return db.Transactions.Where(x => x.TimeStamp.Date == date).ToList();
            }
            else
            {
                return db.Transactions.Where(x =>
                    EF.Functions.Like(x.CashierName, $"%{casherName}%")
                    && x.TimeStamp.Date == date.Date).ToList();
            }
        }

        public IEnumerable<Transaction> GetByDayRange(string casherName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(casherName))
            {
                return db.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.AddDays(1).Date).ToList();
            }
            else
            {
                return db.Transactions.Where(x =>
                    EF.Functions.Like(x.CashierName, $"%{casherName}%")
                    && x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.AddDays(1).Date).ToList();
            }
        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            db.Transactions.Add(new Transaction()
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.UtcNow,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            });

            db.SaveChanges();
        }
    }
}
