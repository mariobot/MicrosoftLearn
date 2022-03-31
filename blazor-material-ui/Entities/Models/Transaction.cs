using System;

namespace Entities.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int BeforeQty { get; set; }
        public int SoldQty { get; set; }
        public string CashierName { get; set; }
        public Product Product { get; set; }
    }
}
