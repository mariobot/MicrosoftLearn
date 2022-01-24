using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> Get(string casherName);
        public IEnumerable<Transaction> GetByDay(string casherName,DateTime date);
        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty);
    }
}
