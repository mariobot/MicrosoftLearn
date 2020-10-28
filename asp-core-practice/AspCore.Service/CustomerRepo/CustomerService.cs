using AspCore.DataAccess;
using AspCore.Domain.DTO;
using AspCore.Domain.Mapper;
using AspCore.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.Service.CustomerRepo
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Create(CustomerDTO customer)
        {
            Customer newCustomer = customer.MapTo<Customer>();
            context.Add(newCustomer);
            await context.SaveChangesAsync();
        }

        public void Update(CustomerDTO customer)
        {
            Customer _customer = customer.MapTo<Customer>();
            context.Entry(_customer).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Customer _customer = context.Customers.FirstOrDefault(x => x.Id == id);
            context.Remove(_customer);
            context.SaveChanges();
        }

        public CustomerDTO GetById(int id)
        {
            Customer _customer = context.Customers.FirstOrDefault(x => x.Id == id);
            return _customer.MapTo<CustomerDTO>();
        }

        public IEnumerable<CustomerDTO> GetList()
        {
            List<Customer> listCustomer = context.Customers.ToList();
            return listCustomer.MapTo<List<CustomerDTO>>();
        }
    }
}
