using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCommerce.CoreBusiness.Models
{
    public class Order
    {
        public int IdProduct { get; set; }

        public int Quantity { get; set; }

        public double Total { get; set; }

        public Product Product { get; set; }
    }
}
