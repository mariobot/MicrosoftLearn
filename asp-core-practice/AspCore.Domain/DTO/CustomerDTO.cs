using System;
using System.Collections.Generic;
using System.Text;

namespace AspCore.Domain.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateOrProvinceAbbr { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
