using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderProcessing.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers = new List<Customer>();

        public CustomerRepository()
        {
            customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = "Joydip",
                LastName = "Kanjilal",
                Address = "Hyderabad, India",
                Phone = "9999999999",
                EmailAddress = "joydipkanjilal@yahoo.com"
            });

            customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Smith",
                Address = "Calgary, Canada",
                Phone = "1111111111",
                EmailAddress = "jsmith@gmail.com"
            });
        }

        public Task<List<Customer>> GetAllCustomers()
        {
            return Task.FromResult(customers);
        }
    }
}
