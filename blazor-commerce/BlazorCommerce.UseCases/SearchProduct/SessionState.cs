using BlazorCommerce.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCommerce.UseCases.SearchProduct
{
    public class SessionState
    {
        public List<Order> orders { get; set; }
    }
}
