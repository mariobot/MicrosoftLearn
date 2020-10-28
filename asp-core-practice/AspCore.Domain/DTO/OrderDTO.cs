using System;
using System.Collections.Generic;
using System.Text;

namespace AspCore.Domain.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
